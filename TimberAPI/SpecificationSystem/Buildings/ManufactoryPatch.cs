using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timberborn.EntitySystem;
using Timberborn.Goods;
using Timberborn.PreviewSystem;
using Timberborn.Warehouses;
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
    /// Changing building costs here just works. Costs are then updated on ToolButton
    /// and on the construction site
    /// </summary>
    [HarmonyPatch(typeof(PreviewFactory), nameof(PreviewFactory.Create))]
    public static class PreviewFactoryPatch
    {
        public static void Prefix(ref GameObject prefab)
        {
            if(!prefab.TryGetComponent<Timberborn.Buildings.Building>(out var buildingComponent))
            {
                return;
            }
            var specificationService = TimberAPI.DependencyContainer.GetInstance<BuildingSpecificationService>();
            var building = specificationService.GetBuildingByBuilding(buildingComponent);
            if (building == null)
            {
                return;
            }

            buildingComponent._scienceCost = building.ScienceCost;
            buildingComponent._buildingCost = building.BuildingCost
                                                      .Select(x => new GoodAmountSpecification(x.GoodId, x.Amount))
                                                      .ToArray();
        }
    }
}
