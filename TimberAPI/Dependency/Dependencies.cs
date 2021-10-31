using System.Collections.Generic;
using Bindito.Core;
using HarmonyLib;
using Timberborn.MasterScene;
using UnityEngine;

namespace TimberbornAPI.Dependency {

    [HarmonyPatch]
    public class Dependencies {
        private static List<IConfigurator> configurators = new();

        /**
         * Install a Configurator into a scene to allow dependency injection
         * The class must implement IConfigurator and can use Bind<>() to inject dependencies
         */
        public void AddConfigurator(IConfigurator configurator) {
            configurators.Add(configurator);
        }

        /**
         * Inject configurators into MasterScene
         */
        [HarmonyPostfix]
        [HarmonyPatch(typeof(MasterSceneConfigurator), "Configure")]
        static void InjectMasterScene(IContainerDefinition containerDefinition) {
            foreach (IConfigurator configurator in configurators) {
                containerDefinition.Install(configurator);
            }
            Debug.Log("Initialized configurators");
        }

    }
}