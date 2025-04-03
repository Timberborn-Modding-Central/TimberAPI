using System.Collections.Generic;
using System.Linq;
using TimberApi.SingletonSystem;
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
        foreach (var building in prefabService.GetAll<Timberborn.Buildings.BuildingSpec>())
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

            if (building.TryGetComponentFast(out MechanicalNodeSpec mechanicalNodeSpecification))
            {
                ChangeMechanicalNodeSpecification(mechanicalNodeSpecification, buildingSpecification);
            }
        }
    }

    private static void ChangeMechanicalNodeSpecification(MechanicalNodeSpec mechanicalNodeSpecification, BuildingSpec buildingSpec)
    {
        if (buildingSpec.PowerOutput != null)
        {
            mechanicalNodeSpecification._powerOutput = (int) buildingSpec.PowerOutput;
        }

        if (buildingSpec.PowerInput != null)
        {
            mechanicalNodeSpecification._powerInput = (int) buildingSpec.PowerInput;
        }
    }

    private static void ChangeManufactoryRecipes(ManufactorySpec manufactorySpec, BuildingSpec buildingSpec)
    {
        manufactorySpec._productionRecipeIds = buildingSpec.RecipeIds.Distinct().ToList();
    }

    private static void ChangeBuildingProperties(Timberborn.Buildings.BuildingSpec building, BuildingSpec buildingSpec)
    {
        if (buildingSpec.ScienceCost != null)
        {
            building._scienceCost = (int) buildingSpec.ScienceCost;
        }

        List<BuildingCost> reverseList = new(buildingSpec.BuildingCosts);
        reverseList.Reverse();

        building._buildingCost = reverseList.Select(x => new GoodAmountSpec
        {
            _goodId = x.GoodId,
            _amount = x.Amount,
        }).Distinct(new GoodAmountSpecComparer()).ToArray();
    }
}