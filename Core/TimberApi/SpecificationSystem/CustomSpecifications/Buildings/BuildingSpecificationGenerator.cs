using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem.SpecificationTypes;
using Timberborn.Buildings;
using Timberborn.MechanicalSystem;
using Timberborn.PrefabSystem;
using Timberborn.Workshops;
using UnityEngine;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Buildings
{
    internal class BuildingSpecificationGenerator : ISpecificationGenerator
    {
        private static readonly string BuildingsPath = "Buildings";

        private static readonly string SpecificationName = "BuildingSpecification";

        public IEnumerable<ISpecification> Generate()
        {
            Building[] buildingComponents = Resources.LoadAll<Building>(BuildingsPath);

            foreach (Building component in buildingComponents)
            {
                string buildingId = component.GetComponent<Prefab>().PrefabName;
                IEnumerable<string> recipeIds = Array.Empty<string>();
                int scienceCost = component.ScienceCost;
                IEnumerable<BuildingCost> buildingCosts = component.BuildingCost.Select(x => new BuildingCost(x.GoodId, x.Amount));
                int? powerInput = null;
                int? powerOutput = null;

                if (component.TryGetComponent(out Manufactory manufactory))
                {
                    recipeIds = manufactory.ProductionRecipeIds;
                }

                if (component.TryGetComponent(out MechanicalNodeSpecification mechanicalNodeSpecification))
                {
                    powerInput = mechanicalNodeSpecification.PowerInput;
                    powerOutput = mechanicalNodeSpecification.PowerOutput;
                }

                var buildingSpec = new BuildingSpecification(buildingId, scienceCost, powerInput, powerOutput, recipeIds, buildingCosts);

                var jsonSerializerSettings = new JsonSerializerSettings {DefaultValueHandling = DefaultValueHandling.Ignore};
                string buildingSpecificationJson = JsonConvert.SerializeObject(buildingSpec, Formatting.Indented, jsonSerializerSettings);

                yield return new GeneratedSpecification(buildingSpecificationJson, component.name, SpecificationName);
            }
        }
    }
}