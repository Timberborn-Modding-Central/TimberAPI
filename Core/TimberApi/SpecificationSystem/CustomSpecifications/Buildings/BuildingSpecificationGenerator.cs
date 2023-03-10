using System.Collections.Generic;
using TimberApi.Common.SingletonSystem;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Buildings
{
    internal class BuildingSpecificationGenerator : ITimberApiLoadableSingleton
    {
        private static readonly string BuildingsPath = "Buildings";

        private static readonly string SpecificationName = "BuildingSpecification";

        private readonly SpecificationRepository _specificationRepository;

        public BuildingSpecificationGenerator(SpecificationRepository specificationRepository)
        {
            _specificationRepository = specificationRepository;
        }

        public void Load()
        {
            _specificationRepository.AddRange(GenerateSpecifications());
        }

        private static IEnumerable<ISpecification> GenerateSpecifications()
        {
            return new List<ISpecification>();

            // var buildingComponents = Resources.LoadAll<Building>(BuildingsPath);
            //
            // foreach (var component in buildingComponents)
            // {
            //     var buildingId = component.GetComponent<Prefab>().PrefabName;
            //     IEnumerable<string> recipeIds = Array.Empty<string>();
            //     var scienceCost = component.ScienceCost;
            //     var buildingCosts = component.BuildingCost.Select(x => new BuildingCost(x.GoodId, x.Amount));
            //     int? powerInput = null;
            //     int? powerOutput = null;
            //
            //     if (component.TryGetComponent(out Manufactory manufactory))
            //     {
            //         recipeIds = manufactory.ProductionRecipeIds;
            //     }
            //
            //     if (component.TryGetComponent(out MechanicalNodeSpecification mechanicalNodeSpecification))
            //     {
            //         powerInput = mechanicalNodeSpecification.PowerInput;
            //         powerOutput = mechanicalNodeSpecification.PowerOutput;
            //     }
            //
            //     var buildingSpec = new BuildingSpecification(buildingId, scienceCost, powerInput, powerOutput, recipeIds, buildingCosts);
            //
            //     var jsonSerializerSettings = new JsonSerializerSettings {DefaultValueHandling = DefaultValueHandling.Ignore};
            //     var buildingSpecificationJson = JsonConvert.SerializeObject(buildingSpec, Formatting.Indented, jsonSerializerSettings);
            //
            //     yield return new GeneratedSpecification(buildingSpecificationJson, component.name, SpecificationName);
            // }
        }
    }
}