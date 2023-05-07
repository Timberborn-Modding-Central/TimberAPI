using Bindito.Core;
using HarmonyLib;
using TimberApi.HarmonyPatcherSystem;
using TimberApi.SceneSystem;
using Timberborn.GameScene;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;

namespace TimberApi.Core.ConfiguratorSystem
{
    public class ConfiguratorPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberApi.Core.Configurator";
        
        public override void Apply(Harmony harmony)
        {
            harmony.Patch(AccessTools.Method(typeof(GameSceneConfigurator), "Configure"), 
                new HarmonyMethod(AccessTools.Method(typeof(ConfiguratorPatcher), nameof(PatchMasterSceneConfigurator))));

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