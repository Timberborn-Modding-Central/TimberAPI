using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timberborn.AssetSystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;
using Timberborn.Workshops;
using Timberborn.WorldSerialization;
using TimberbornAPI.Internal;
using TimberbornAPI.PluginSystem;
using TimberbornAPI.SpecificationSystem.Fixes.CustomSpecifications.Buildings;
using UnityEngine;

namespace TimberbornAPI.SpecificationSystem
{
    public class TimberApiSpecificationService : ILoadableSingleton, ISpecificationService
    {
        private static readonly string SpecificationPath = "Specifications";
        private readonly string _buildingsPath = "Buildings";

        private readonly PluginLocationService _pluginLocationService;

        private readonly JsonMergeSettings _jsonMergeSettings;

        private readonly ObjectSaveReaderWriter _objectSaveReaderWriter;

        private readonly IResourceAssetLoader _resourceAssetLoader;

        private ISpecification[] _specifications;


        public TimberApiSpecificationService(
            ObjectSaveReaderWriter objectSaveReaderWriter,
            IResourceAssetLoader resourceAssetLoader,
            PluginLocationService pluginLocationService)
        {
            _objectSaveReaderWriter = objectSaveReaderWriter;
            _resourceAssetLoader = resourceAssetLoader;
            _pluginLocationService = pluginLocationService;
            _jsonMergeSettings = new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Union
            };
        }

        public void Load()
        {
            List<ISpecification> specifications = new();

            specifications.AddRange(_pluginLocationService.GetDependentPluginFiles(
                    TimberAPIPlugin.Guid,
                    new[] { SpecificationPath },
                    true,
                    new[] { ".json" },
                    true)
                .Select(filePath => new PluginSpecification(filePath)));

            specifications.AddRange(GenerateBuildingSpecifications().Select(asset => new TimberbornSpecification(asset)));

            specifications.AddRange(_resourceAssetLoader.LoadAll<TextAsset>(SpecificationPath).Select(asset => new TimberbornSpecification(asset)));

            _specifications = specifications.ToArray();
        }

        public IEnumerable<T> GetSpecifications<T>(IObjectSerializer<T> serializer)
        {
            string specificationType = typeof(T).Name;
            IEnumerable<ISpecification> typeSpecification = _specifications.Where(specification => specificationType.ToLower().Equals(specification.SpecificationName)).ToArray();


            foreach (ISpecification originalSpecification in typeSpecification.Where(specification => specification.IsOriginal))
            {
                IEnumerable<ISpecification> mergeSpecifications = typeSpecification.Where(specification => originalSpecification != specification && specification.FullName.Equals(originalSpecification.FullName));
                string mergedJson = Wrap(MergeSpecifications(originalSpecification, mergeSpecifications), specificationType);
                yield return ObjectLoader.CreateBasicLoader(_objectSaveReaderWriter.ReadJson(mergedJson)).Get(new PropertyKey<T>(specificationType), serializer);
            }
        }

        /// <summary>
        /// TODO: Should probably be in its own class?
        /// Generates Custom original BuildingSpecification jsons for
        /// all buildings in the game
        /// </summary>
        /// <returns></returns>
        private IEnumerable<TextAsset> GenerateBuildingSpecifications()
        {
            var buildings = new List<TextAsset>();
            var buildingComponents = Resources.LoadAll<Timberborn.Buildings.Building>(_buildingsPath);

            foreach (var component in buildingComponents)
            {
                var manufactory = component.GetComponent<Manufactory>();
                List<Recipe> recipes = new List<Recipe>();
                if (manufactory != null)
                {
                    recipes = manufactory.ProductionRecipeIds
                                         .Select(x => new Recipe(x))
                                         .ToList();
                }
                var build = new Building(component.ScienceCost,
                                         component.BuildingCost
                                                  .Select(x => new BuildingCost(x.GoodId, x.Amount))
                                                  .ToList());
                var mechanicalNode = component.GetComponent<Timberborn.MechanicalSystem.MechanicalNodeSpecification>();
                MechanicalNode mechNode = null;
                if (mechanicalNode != null)
                {
                    mechNode = new MechanicalNode(mechanicalNode.PowerInput, mechanicalNode.PowerOutput);
                }

                var buildingSpec = new BuildingSpecification(component.name,
                                                             recipes,
                                                             build,
                                                             mechNode);

                var serializer = new JsonSerializer();
                serializer.DefaultValueHandling = DefaultValueHandling.Ignore;
                using var sw = new StringWriter();
                serializer.Serialize(sw, buildingSpec);

                var jsonText = sw.ToString();
                var specificationAsset = new TextAsset(jsonText)
                {
                    name = $"BuildingSpecification.{component.name}"
                };

                // HACK: Uncomment to create BuildingSpecs files
                //var file = File.CreateText($".\\{specificationAsset.name}.json");
                //file.Write(JToken.Parse(jsonText).ToString(Formatting.Indented));
                //file.Close();

                buildings.Add(specificationAsset);
            }

            return buildings;
        }

        private JObject MergeSpecification(JObject originalSpecification, ISpecification mergeSpecification)
        {
            originalSpecification.Merge(JObject.Parse(mergeSpecification.LoadJson()), _jsonMergeSettings);
            return originalSpecification;
        }

        private string MergeSpecifications(ISpecification originalSpecification, IEnumerable<ISpecification> mergeSpecifications)
        {
            JObject json = JObject.Parse(originalSpecification.LoadJson());
            return mergeSpecifications.Aggregate(json, MergeSpecification).ToString();
        }

        private static string Wrap(string assetText, string type) => "{\"" + type + "\":" + assetText + "}";
    }
}