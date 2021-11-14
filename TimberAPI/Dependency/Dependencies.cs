using System.Collections.Generic;
using Bindito.Core;
using HarmonyLib;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;
using Timberborn.MasterScene;
using TimberbornAPI.Common;
using UnityEngine;

namespace TimberbornAPI.Dependency {
    [HarmonyPatch]
    public class Dependencies : IDependencies {
        private static Dictionary<SceneEntryPoint, List<IConfigurator>> configuratorsByEntryPoint = new();

        /**
         * Install a Configurator into a scene to allow dependency injection
         * The class must implement IConfigurator and can use Bind<>() to inject dependencies
         */
        public void AddConfigurator(IConfigurator configurator, SceneEntryPoint entryPoint = SceneEntryPoint.InGame) {
            if (entryPoint == SceneEntryPoint.Global) {
                Debug.Log("Global is currently unsupported");
                return;
            }
            if (configuratorsByEntryPoint.TryGetValue(entryPoint, out var configurators)) {
                configurators.Add(configurator);
            } else {
                configuratorsByEntryPoint.Add(entryPoint, new() { configurator });
            }
        }

        /**
         * Inject configurators into MasterScene (InGame)
         */
        [HarmonyPostfix]
        [HarmonyPatch(typeof(MasterSceneConfigurator), "Configure")]
        static void InjectMasterScene(IContainerDefinition containerDefinition) {
            InstallAll(containerDefinition, SceneEntryPoint.InGame);
        }

        /**
         * Inject configurators into MainMenuScene
         */
        [HarmonyPostfix]
        [HarmonyPatch(typeof(MainMenuSceneConfigurator), "Configure")]
        static void InjectMainMenuScene(IContainerDefinition containerDefinition) {
            InstallAll(containerDefinition, SceneEntryPoint.MainMenu);
        }

        /**
         * Inject configurators into MapEditorScene
         */
        [HarmonyPostfix]
        [HarmonyPatch(typeof(MapEditorSceneConfigurator), "Configure")]
        static void InjectMapEditorScene(IContainerDefinition containerDefinition) {
            InstallAll(containerDefinition, SceneEntryPoint.MapEditor);
        }

        /**
         * Install all the configurators for the given entryPoint
         */
        private static void InstallAll(IContainerDefinition containerDefinition, SceneEntryPoint entryPoint) {
            List<IConfigurator> configurators =
                configuratorsByEntryPoint.GetValueOrDefault(entryPoint, new());
            foreach (IConfigurator configurator in configurators) {
                containerDefinition.Install(configurator);
            }
            Debug.Log("Initialized configurators for " + entryPoint.ToString());
        }
    }
}