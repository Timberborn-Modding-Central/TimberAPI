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

        public void AddConfigurators(List<IConfigurator> configurators, SceneEntryPoint entryPoint = SceneEntryPoint.InGame, bool first = false)
        {
            foreach(IConfigurator configurator in configurators)
            {
                AddConfigurator(configurator, entryPoint, first);
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MasterSceneConfigurator), "Configure")]
        static void InjectIntoMasterSceneFirst(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.Global, true);
            InstallAll(containerDefinition, SceneEntryPoint.InGame, true);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MainMenuSceneConfigurator), "Configure")]
        static void InjectIntoMainMenuSceneFirst(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.Global, true);
            InstallAll(containerDefinition, SceneEntryPoint.MainMenu, true);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MapEditorSceneConfigurator), "Configure")]
        static void InjectIntoMapEditorSceneFirst(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.Global, true);
            InstallAll(containerDefinition, SceneEntryPoint.MapEditor, true);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MasterSceneConfigurator), "Configure")]
        static void InjectIntoMasterSceneLast(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.Global, false);
            InstallAll(containerDefinition, SceneEntryPoint.InGame, false);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MainMenuSceneConfigurator), "Configure")]
        static void InjectIntoMainMenuSceneLast(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.Global, false);
            InstallAll(containerDefinition, SceneEntryPoint.MainMenu, false);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MapEditorSceneConfigurator), "Configure")]
        static void InjectIntoMapEditorSceneLast(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.Global, false);
            InstallAll(containerDefinition, SceneEntryPoint.MapEditor, false);
        }

        [SuppressMessage("", "Harmony003")]
        private static void InstallAll(IContainerDefinition containerDefinition, SceneEntryPoint entryPoint, bool first)
        {
            Dictionary<SceneEntryPoint, List<IConfigurator>> configuratorsByEntryPoint =
                first ? configuratorsByEntryPointFirst : configuratorsByEntryPointLast;
            List<IConfigurator> configurators =
                configuratorsByEntryPoint.GetValueOrDefault(entryPoint, new());
            foreach (IConfigurator configurator in configurators)
            {
                containerDefinition.Install(configurator);
            }
            Debug.Log($"Initialized configurators for {entryPoint.ToString()} ({(first ? "First" : "Last")})");
        }
    }
}