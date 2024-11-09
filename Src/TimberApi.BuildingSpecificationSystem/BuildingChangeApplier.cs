using System.Collections.Generic;
using System.Linq;
using TimberApi.SingletonSystem;
using Timberborn.Buildings;
using Timberborn.Goods;
using Timberborn.MechanicalSystem;
using Timberborn.PrefabSystem;
using Timberborn.Workshops;

namespace TimberApi.BuildingSpecificationSystem;

internal class BuildingChangeApplier(
    PrefabService prefabService,
    BuildingSpecificationService buildingSpecificationService)
    : IEarlyLoadableSingleton
{
    public void EarlyLoad()
    {
        foreach (var building in prefabService.GetAll<Building>())
        {
            var buildingSpecification = buildingSpecificationService.GetBuildingSpecificationByBuilding(building);

            if (buildingSpecification == null)
            {
                continue;
            }
            
            ChangeBuildingProperties(building, buildingSpecification);
            


            if (building.TryGetComponentFast(out ManufactorySpec manufactorySpec))
            {
                ChangeManufactoryRecipes(manufactorySpec, buildingSpecification);
            }

            if (building.TryGetComponentFast(out MechanicalNodeSpecification mechanicalNodeSpecification))
            {
                ChangeMechanicalNodeSpecification(mechanicalNodeSpecification, buildingSpecification);
            }
        }
    }

    private static void ChangeMechanicalNodeSpecification(MechanicalNodeSpecification mechanicalNodeSpecification, BuildingSpecification buildingSpecification)
    {
        if (buildingSpecification.PowerOutput != null)
        {
            mechanicalNodeSpecification._powerOutput = (int) buildingSpecification.PowerOutput;
        }

        if (buildingSpecification.PowerInput != null)
        {
            mechanicalNodeSpecification._powerInput = (int) buildingSpecification.PowerInput;
        }
    }

    private static void ChangeManufactoryRecipes(ManufactorySpec manufactorySpec, BuildingSpecification buildingSpecification)
    {
        manufactorySpec._productionRecipeIds = buildingSpecification.RecipeIds.Distinct().ToList();
    }

    private static void ChangeBuildingProperties(Building building, BuildingSpecification buildingSpecification)
    {
        if (buildingSpecification.ScienceCost != null)
        {
            building._scienceCost = (int) buildingSpecification.ScienceCost;
        }

        List<BuildingCost> reverseList = new(buildingSpecification.BuildingCosts);
        reverseList.Reverse();

        building._buildingCost = reverseList.Select(x => new GoodAmountSpecification(x.GoodId, x.Amount)).Distinct(new GoodAmountSpecificationComparer()).ToArray();
    }
}