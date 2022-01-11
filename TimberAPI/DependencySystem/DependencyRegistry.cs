using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Bindito.Core;
using HarmonyLib;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;
using Timberborn.MasterScene;
using TimberbornAPI.Common;
using UnityEngine;

namespace TimberbornAPI.DependencySystem
{
    [HarmonyPatch]
    public class DependencyRegistry : IDependencyRegistry
    {
        private static Dictionary<SceneEntryPoint, List<IConfigurator>> configuratorsByEntryPointFirst = new();
        private static Dictionary<SceneEntryPoint, List<IConfigurator>> configuratorsByEntryPointLast = new();

        /// <summary>
        /// Install a Configurator into a scene to allow dependency injection
        /// The class must implement IConfigurator and can use Bind<>() to inject dependencies
        /// </summary>
        /// <param name="configurator">The configurator class to inject, which does the binding</param>
        /// <param name="entryPoint">Scene to bind to, defaults to InGame</param>
        /// <param name="first">Install before everything else is bound</param>
        public void AddConfigurator(IConfigurator configurator, SceneEntryPoint entryPoint = SceneEntryPoint.InGame, bool first = false)
        {
            Dictionary<SceneEntryPoint, List<IConfigurator>> configuratorsByEntryPoint =
                first ? configuratorsByEntryPointFirst : configuratorsByEntryPointLast;
            if (configuratorsByEntryPoint.TryGetValue(entryPoint, out var configurators))
            {
                configurators.Add(configurator);
            }
            else
            {
                configuratorsByEntryPoint.Add(entryPoint, new() { configurator });
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MasterSceneConfigurator), "Configure")]
        static void InjectIntoMasterSceneFirst(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.InGame, configuratorsByEntryPointFirst);
            InstallAll(containerDefinition, SceneEntryPoint.Global, configuratorsByEntryPointFirst);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MainMenuSceneConfigurator), "Configure")]
        static void InjectIntoMainMenuSceneFirst(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.MainMenu, configuratorsByEntryPointFirst);
            InstallAll(containerDefinition, SceneEntryPoint.Global, configuratorsByEntryPointFirst);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MapEditorSceneConfigurator), "Configure")]
        static void InjectIntoMapEditorSceneFirst(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.MapEditor, configuratorsByEntryPointFirst);
            InstallAll(containerDefinition, SceneEntryPoint.Global, configuratorsByEntryPointFirst);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MasterSceneConfigurator), "Configure")]
        static void InjectIntoMasterSceneLast(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.InGame, configuratorsByEntryPointLast);
            InstallAll(containerDefinition, SceneEntryPoint.Global, configuratorsByEntryPointLast);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MainMenuSceneConfigurator), "Configure")]
        static void InjectIntoMainMenuSceneLast(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.MainMenu, configuratorsByEntryPointLast);
            InstallAll(containerDefinition, SceneEntryPoint.Global, configuratorsByEntryPointLast);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MapEditorSceneConfigurator), "Configure")]
        static void InjectIntoMapEditorSceneLast(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.MapEditor, configuratorsByEntryPointLast);
            InstallAll(containerDefinition, SceneEntryPoint.Global, configuratorsByEntryPointLast);
        }

        [SuppressMessage("", "Harmony003")]
        private static void InstallAll(IContainerDefinition containerDefinition, SceneEntryPoint entryPoint,
            Dictionary<SceneEntryPoint, List<IConfigurator>> configuratorsByEntryPoint)
        {
            List<IConfigurator> configurators =
                configuratorsByEntryPoint.GetValueOrDefault(entryPoint, new());
            foreach (IConfigurator configurator in configurators)
            {
                containerDefinition.Install(configurator);
            }
            Debug.Log("Initialized configurators for " + entryPoint.ToString());
        }
    }
}