using HarmonyLib;
using System.Linq;
using Timberborn.Goods;
using Timberborn.MechanicalSystem;
using Timberborn.PreviewSystem;
using Timberborn.Workshops;
using UnityEngine;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    /// <summary>
    /// Patch recipes in ManufactoryInventoryInitializer.Initialize, so that the Manufactory
    /// Inventory get's initialized correctly too
    /// </summary>
    [HarmonyPatch(typeof(ManufactoryInventoryInitializer), nameof(ManufactoryInventoryInitializer.Initialize))]
    public static class ManufactoryInventoryInitializerPatch
    {
        public static void Prefix(Manufactory subject)
        {
            var specificationService = TimberAPI.DependencyContainer.GetInstance<BuildingSpecificationService>();
            var recipes = specificationService.GetRecipesByManufactory(subject);
            if (recipes == null)
            {
                return;
            }

            subject._productionRecipeIds = recipes.Select(x => x.Id)
                                                  .ToArray();
        }
    }

    /// <summary>
    /// Changing building component stuff here just works. 
    /// </summary>
    [HarmonyPatch(typeof(PreviewFactory), nameof(PreviewFactory.Create))]
    public static class PreviewFactoryPatch
    {
        public static void Prefix(ref GameObject prefab)
        {
            var specificationService = TimberAPI.DependencyContainer.GetInstance<BuildingSpecificationService>();
            if (prefab.TryGetComponent<Timberborn.Buildings.Building>(out var buildingComponent))
            {
                var building = specificationService.GetBuildingByBuilding(buildingComponent);
                if (building != null)
                {
                    buildingComponent._scienceCost = building.ScienceCost;
                    buildingComponent._buildingCost = building.BuildingCost
                                                              .Select(x => new GoodAmountSpecification(x.GoodId, x.Amount))
                                                              .ToArray();
                }
            }

            if(prefab.TryGetComponent<MechanicalNodeSpecification>(out var mechanicalNodeSpec))
            {

                var mechanicalNode = specificationService.GetMechanicalNodeByMechanicalNodeSpecification(mechanicalNodeSpec);
                if(mechanicalNode != null)
                {
                    mechanicalNodeSpec._powerInput = mechanicalNode.PowerInput;
                    mechanicalNodeSpec._powerOutput = mechanicalNode.PowerOutput;
                }
            }
        }
    }
}
