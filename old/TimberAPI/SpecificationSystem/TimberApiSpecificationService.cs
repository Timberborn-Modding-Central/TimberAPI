using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Timberborn.AssetSystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;
using Timberborn.WorldSerialization;
using TimberbornAPI.Internal;
using TimberbornAPI.PluginSystem;
using UnityEngine;

namespace TimberbornAPI.SpecificationSystem
{
    public class TimberApiSpecificationService : ILoadableSingleton, ISpecificationService
    {
        private static readonly string SpecificationPath = "Specifications";

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
                    new[] {SpecificationPath},
                    true,
                    new []{ ".json" },
                    true)
                .Select(filePath => new PluginSpecification(filePath)));

            specifications.AddRange(_resourceAssetLoader.LoadAll<TextAsset>(SpecificationPath).Select(asset => new TimberbornSpecification(asset)));

            _specifications = specifications.ToArray();
        }

        public IEnumerable<T> GetSpecifications<T>(IObjectSerializer<T> serializer)
        {
            string specificationType = typeof (T).Name;
            IEnumerable<ISpecification> typeSpecification = _specifications.Where(specification => specificationType.ToLower().Equals(specification.SpecificationName)).ToArray();


            foreach (ISpecification originalSpecification in typeSpecification.Where(specification => specification.IsOriginal))
            {
                IEnumerable<ISpecification> mergeSpecifications = typeSpecification.Where(specification => originalSpecification != specification && specification.FullName.Equals(originalSpecification.FullName));
                string mergedJson = Wrap(MergeSpecifications(originalSpecification, mergeSpecifications), specificationType);
                yield return ObjectLoader.CreateBasicLoader(_objectSaveReaderWriter.ReadJson(mergedJson)).Get(new PropertyKey<T>(specificationType), serializer);
            }
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