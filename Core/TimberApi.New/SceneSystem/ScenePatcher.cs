﻿using Bindito.Core;
using HarmonyLib;
using TimberApi.Common.SingletonSystem.Singletons;
using TimberApi.New.ConfiguratorSystem;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;
using Timberborn.MasterScene;

namespace TimberApi.New.SceneSystem
{
    internal class SceneListener : ITimberApiLoadableSingleton
    {
        public void Load()
        {
            Harmony harmony = new Harmony("TimberApi.SceneListener");
            harmony.Patch(
                original: AccessTools.Method(typeof(MasterSceneConfigurator), "Configure"),
                prefix:  new HarmonyMethod(AccessTools.Method(typeof(SceneListener), nameof(PatchMasterSceneConfigurator)))
            );

            harmony.Patch(
                original: AccessTools.Method(typeof(MainMenuSceneConfigurator), "Configure"),
                prefix:  new HarmonyMethod(AccessTools.Method(typeof(SceneListener), nameof(PatchMainMenuSceneConfigurator)))
            );

            harmony.Patch(
                original: AccessTools.Method(typeof(MapEditorSceneConfigurator), "Configure"),
                prefix: new HarmonyMethod(AccessTools.Method(typeof(SceneListener), nameof(PatchMapEditorSceneConfigurator)))
            );
        }

        private static void PatchMasterSceneConfigurator(IContainerDefinition containerDefinition)
        {
            ConfiguratorInstaller.Install(containerDefinition, SceneEntrypoint.InGame);
        }

        private static void PatchMainMenuSceneConfigurator(IContainerDefinition containerDefinition)
        {
            ConfiguratorInstaller.Install(containerDefinition, SceneEntrypoint.MainMenu);
        }

        private static void PatchMapEditorSceneConfigurator(IContainerDefinition containerDefinition)
        {
            ConfiguratorInstaller.Install(containerDefinition, SceneEntrypoint.MapEditor);
        }
    }
}