using Bindito.Core;
using HarmonyLib;
using TimberApi.Common.SingletonSystem.Singletons;
using TimberApi.ConfiguratorSystem;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;
using Timberborn.MasterScene;

namespace TimberApi.SceneSystem
{
    internal class SceneListener : ITimberApiLoadableSingleton
    {
        public void Load()
        {
            var harmony = new Harmony("TimberApi.SceneListener");
            harmony.Patch(AccessTools.Method(typeof(MasterSceneConfigurator), "Configure"), new HarmonyMethod(AccessTools.Method(typeof(SceneListener), nameof(PatchMasterSceneConfigurator))));

            harmony.Patch(AccessTools.Method(typeof(MainMenuSceneConfigurator), "Configure"), new HarmonyMethod(AccessTools.Method(typeof(SceneListener), nameof(PatchMainMenuSceneConfigurator))));

            harmony.Patch(AccessTools.Method(typeof(MapEditorSceneConfigurator), "Configure"), new HarmonyMethod(AccessTools.Method(typeof(SceneListener), nameof(PatchMapEditorSceneConfigurator))));
        }

        private static void PatchMasterSceneConfigurator(IContainerDefinition containerDefinition)
        {
            TimberApiSceneManager.ChangeScene(SceneEntrypoint.InGame);
            ConfiguratorInstaller.Install(containerDefinition, SceneEntrypoint.InGame);
        }

        private static void PatchMainMenuSceneConfigurator(IContainerDefinition containerDefinition)
        {
            TimberApiSceneManager.ChangeScene(SceneEntrypoint.MainMenu);
            ConfiguratorInstaller.Install(containerDefinition, SceneEntrypoint.MainMenu);
        }

        private static void PatchMapEditorSceneConfigurator(IContainerDefinition containerDefinition)
        {
            TimberApiSceneManager.ChangeScene(SceneEntrypoint.MapEditor);
            ConfiguratorInstaller.Install(containerDefinition, SceneEntrypoint.MapEditor);
        }
    }
}