using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem.SpecificationTypes;
using Timberborn.Buildings;
using Timberborn.MechanicalSystem;
using Timberborn.PrefabSystem;
using Timberborn.Workshops;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Buildings
{
    internal class BuildingSpecificationGenerator : IObjectSpecificationGenerator
    {
        private static readonly string SpecificationName = "BuildingSpecification";
        
        public IEnumerable<ISpecification> Generate(ObjectCollectionService objectCollectionService)
        {
            var buildings = objectCollectionService.GetAllMonoBehaviours<Building>();

            foreach (var building in buildings)
            {
                var buildingId = building.GetComponentFast<Prefab>().PrefabName;
                
                IEnumerable<string> recipeIds = Array.Empty<string>();
                
                var scienceCost = building.ScienceCost;
                
                var buildingCosts = building.BuildingCost.Select(x => new BuildingCost(x.GoodId, x.Amount));
                int? powerInput = null;
                int? powerOutput = null;

                if (building.TryGetComponentFast(out Manufactory manufactory))
                {
                    recipeIds = manufactory.ProductionRecipeIds;
                }

                if (building.TryGetComponentFast(out MechanicalNodeSpecification mechanicalNodeSpecification))
                {
                    powerInput = mechanicalNodeSpecification.PowerInput;
                    powerOutput = mechanicalNodeSpecification.PowerOutput;
                }

                var buildingSpec = new BuildingSpecification(buildingId, scienceCost, powerInput, powerOutput, recipeIds, buildingCosts);

                var jsonSerializerSettings = new JsonSerializerSettings {DefaultValueHandling = DefaultValueHandling.Ignore};
                var buildingSpecificationJson = JsonConvert.SerializeObject(buildingSpec, Formatting.Indented, jsonSerializerSettings);

                yield return new GeneratedSpecification(buildingSpecificationJson, building.name, SpecificationName);
            }
        }
    }
}