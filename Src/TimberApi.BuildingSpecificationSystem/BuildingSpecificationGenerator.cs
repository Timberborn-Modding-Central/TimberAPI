using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.BlueprintSystem;
using Timberborn.Buildings;
using Timberborn.CommandLine;
using Timberborn.GameStartup;
using Timberborn.MainMenuModdingUI;
using Timberborn.MechanicalSystem;
using Timberborn.PrefabSystem;
using Timberborn.Workshops;
using Timberborn.Modding;

namespace TimberApi.BuildingSpecificationSystem;

internal class BuildingSpecificationGenerator(
    PrefabService prefabService
) : ISpecGenerator
{
    private const string SpecificationName = "BuildingSpecification";

    public IEnumerable<GeneratedSpec> Generate()
    {
        var buildings = prefabService.GetAll<Timberborn.Buildings.BuildingSpec>();

        foreach (var building in buildings)
        {
            var buildingId = building.GetComponentFast<PrefabSpec>().PrefabName;

            IEnumerable<string> recipeIds = Array.Empty<string>();

            var scienceCost = building.ScienceCost;

            var buildingCosts = building.BuildingCost.Select(x => new BuildingCost(x.GoodId, x.Amount));
            int? powerInput = null;
            int? powerOutput = null;

            if (building.TryGetComponentFast(out ManufactorySpec manufactorySpec))
            {
                recipeIds = manufactorySpec.ProductionRecipeIds;
            }

            if (building.TryGetComponentFast(out MechanicalNodeSpec mechanicalNodeSpecification))
            {
                powerInput = mechanicalNodeSpecification.PowerInput;
                powerOutput = mechanicalNodeSpecification.PowerOutput;
            }

            var buildingSpec = new BuildingSpec(buildingId, scienceCost, powerInput, powerOutput, recipeIds, buildingCosts);


            var jsonSerializerSettings = new JsonSerializerSettings
                { DefaultValueHandling = DefaultValueHandling.Ignore };
            var buildingSpecificationJson =
                JsonConvert.SerializeObject(buildingSpec, Formatting.Indented, jsonSerializerSettings);
            
            yield return new GeneratedSpec("Buildings", $"{SpecificationName}.{building.name}", buildingSpecificationJson, true);
        }
    }
}