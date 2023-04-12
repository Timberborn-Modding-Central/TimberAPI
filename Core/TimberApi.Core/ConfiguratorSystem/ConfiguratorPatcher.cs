using Bindito.Core;
using HarmonyLib;
using TimberApi.SceneSystem;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;
using Timberborn.GameScene;

namespace TimberApi.Core.ConfiguratorSystem
{
    public static class ConfiguratorPatcher
    {
        public static void Patch()
        {
            var harmony = new Harmony("TimberApi.SceneListener");
            harmony.Patch(AccessTools.Method(typeof(GameSceneConfigurator), "Configure"), new HarmonyMethod(AccessTools.Method(typeof(ConfiguratorPatcher), nameof(PatchMasterSceneConfigurator))));

            harmony.Patch(AccessTools.Method(typeof(MainMenuSceneConfigurator), "Configure"),
                new HarmonyMethod(AccessTools.Method(typeof(ConfiguratorPatcher), nameof(PatchMainMenuSceneConfigurator))));

            harmony.Patch(AccessTools.Method(typeof(MapEditorSceneConfigurator), "Configure"),
                new HarmonyMethod(AccessTools.Method(typeof(ConfiguratorPatcher), nameof(PatchMapEditorSceneConfigurator))));
        }

        private static void PatchMasterSceneConfigurator(IContainerDefinition containerDefinition)
        {
            TimberApiSceneManager.ChangeScene(SceneEntrypoint.InGame, containerDefinition);
        }

        private static void PatchMainMenuSceneConfigurator(IContainerDefinition containerDefinition)
        {
            TimberApiSceneManager.ChangeScene(SceneEntrypoint.MainMenu, containerDefinition);
        }

        private static void PatchMapEditorSceneConfigurator(IContainerDefinition containerDefinition)
        {
            TimberApiSceneManager.ChangeScene(SceneEntrypoint.MapEditor, containerDefinition);
        }
    }
}