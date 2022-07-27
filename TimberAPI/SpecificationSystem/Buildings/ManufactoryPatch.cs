using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timberborn.EntitySystem;
using Timberborn.Goods;
using Timberborn.Warehouses;
using Timberborn.Workshops;

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
            //Console.WriteLine($"Initialize stack:\n{System.Environment.StackTrace}");
            Console.WriteLine($"manu: {subject}");
            Console.WriteLine($"ProductionRecipeIds count: {subject.ProductionRecipeIds.Count()}");
            Console.WriteLine($"ProductionRecipeIds: {subject.ProductionRecipeIds.Aggregate((foo, bar) => $"{foo}, {bar}")}");

            var specificationService = TimberAPI.DependencyContainer.GetInstance<BuildingRecipeService>();
            var recipes = specificationService.GetRecipesByManufactory(subject);
            if (recipes == null)
            {
                //Console.WriteLine("recipes null");
                return;
            }
            Console.WriteLine($"curr recipes");
            foreach (var item in subject.ProductionRecipeIds)
            {
                Console.WriteLine($"\tid: {item}");
            }

            subject._productionRecipeIds = recipes.Select(x => x.Id)
                                                  .ToArray();

            Console.WriteLine($"new recipes");
            foreach (var item in subject.ProductionRecipeIds)
            {
                Console.WriteLine($"\tid: {item}");
            }
        }
    }
}
