using Bindito.Core;
using HarmonyLib;
using Timberborn.MainMenuScene;
using Timberborn.MapEditor;
using Timberborn.MasterScene;
using TimberbornAPI.AssetLoader.AssetSystem;

namespace TimberbornAPI.AssetLoader.Patches
{
    [HarmonyPatch(typeof(MasterSceneConfigurator), "Configure", typeof(IContainerDefinition))]
    public static class MasterSceneConfiguratorPatch
    {
        private static void Postfix(IContainerDefinition containerDefinition)
        {
            containerDefinition.Install(new AssetConfigurator());
        }
    }

    [HarmonyPatch(typeof(MainMenuSceneConfigurator), "Configure", typeof(IContainerDefinition))]
    public static class MainMenuSceneConfiguratorPatch
    {
        private static void Postfix(IContainerDefinition containerDefinition)
        {
            containerDefinition.Install(new AssetConfigurator());
        }
    }

    [HarmonyPatch(typeof(MapEditorConfigurator), "Configure", typeof(IContainerDefinition))]
    public static class MapEditorConfiguratorPatch
    {
        private static void Postfix(IContainerDefinition containerDefinition)
        {
            containerDefinition.Install(new AssetConfigurator());
        }
    }
}