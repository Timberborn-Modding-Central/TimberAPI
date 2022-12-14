using HarmonyLib;
using TimberApi.DependencyContainerSystem;
using TimberApi.UiBuilderSystem;
using Timberborn.StockpilesUI;
using UnityEngine.UIElements;

namespace TimberAPIExample.Examples.DependencyContainerExample
{
    
    [HarmonyPatch(typeof(StockpileInventoryFragment), "InitializeFragment")]
    public static class StockpileVisualElementPatch
    {
        private static void Postfix(VisualElement __result)
        {
            // Finds the singleton from the dependency injection system (Can any class that's connected with Bindito DI) 
            UIBuilder builder = DependencyContainer.GetInstance<UIBuilder>();
            
            // Adds a new button to the stockpile inventory fragment
            __result.Add(builder.Presets().Buttons().ButtonGame(
                "preview.stockpile.inventory.button", 
                builder: buttonBuilder => buttonBuilder
                    .SetWidth(new Length(100, Length.Unit.Percent))
                    .SetHeight(new Length(25, Length.Unit.Pixel))
                    .BuildAndInitialize())
            );
        }
    }
}