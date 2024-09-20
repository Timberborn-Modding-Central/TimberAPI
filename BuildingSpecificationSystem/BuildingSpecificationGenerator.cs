using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.Buildings;
using Timberborn.MechanicalSystem;
using Timberborn.PrefabSystem;
using Timberborn.Workshops;
using UnityEngine;

namespace BuildingSpecificationSystem;

internal class BuildingSpecificationGenerator(
    PrefabService prefabService
) : ISpecificationGenerator
{
    private const string SpecificationName = "BuildingSpecification";

    public IEnumerable<GeneratedSpecification> Generate()
    {
        var buildings = prefabService.GetAll<Building>();

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

            var buildingSpec = new BuildingSpecification(buildingId, scienceCost, powerInput, powerOutput, recipeIds,
                buildingCosts);


            var jsonSerializerSettings = new JsonSerializerSettings
                { DefaultValueHandling = DefaultValueHandling.Ignore };
            var buildingSpecificationJson =
                JsonConvert.SerializeObject(buildingSpec, Formatting.Indented, jsonSerializerSettings);

            yield return new GeneratedSpecification(buildingSpecificationJson, building.name, SpecificationName);
        }
    }
}