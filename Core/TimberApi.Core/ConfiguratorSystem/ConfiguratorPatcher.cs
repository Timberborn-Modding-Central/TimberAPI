﻿using Bindito.Core;
using HarmonyLib;
using TimberApi.HarmonyPatcherSystem;
using TimberApi.SceneSystem;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;
using Timberborn.MasterScene;

namespace TimberApi.Core.ConfiguratorSystem
{
    public class ConfiguratorPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberApi.SceneListener";

        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<MasterSceneConfigurator>("Configure"),
                GetHarmonyMethod(nameof(PatchMasterSceneConfigurator))
            );

            harmony.Patch(
                GetMethodInfo<MainMenuSceneConfigurator>("Configure"),
                GetHarmonyMethod(nameof(PatchMainMenuSceneConfigurator))
            );

            harmony.Patch(
                GetMethodInfo<MapEditorSceneConfigurator>("Configure"),
                GetHarmonyMethod(nameof(PatchMapEditorSceneConfigurator))
            );
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