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
        private static Dictionary<SceneEntryPoint, List<IConfigurator>> configuratorsByEntryPoint = new();

        public void AddConfigurator(IConfigurator configurator, SceneEntryPoint entryPoint = SceneEntryPoint.InGame)
        {
            if (configuratorsByEntryPoint.TryGetValue(entryPoint, out var configurators))
            {
                configurators.Add(configurator);
            }
            else
            {
                configuratorsByEntryPoint.Add(entryPoint, new() { configurator });
            }
        }

        public void AddConfigurators(List<IConfigurator> configurators, SceneEntryPoint entryPoint = SceneEntryPoint.InGame)
        {
            foreach(IConfigurator configurator in configurators)
            {
                AddConfigurator(configurator, entryPoint);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MasterSceneConfigurator), "Configure")]
        static void InjectIntoMasterScene(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.InGame);
            InstallAll(containerDefinition, SceneEntryPoint.Global);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MainMenuSceneConfigurator), "Configure")]
        static void InjectIntoMainMenuScene(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.MainMenu);
            InstallAll(containerDefinition, SceneEntryPoint.Global);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MapEditorSceneConfigurator), "Configure")]
        static void InjectIntoMapEditorScene(IContainerDefinition containerDefinition)
        {
            InstallAll(containerDefinition, SceneEntryPoint.MapEditor);
            InstallAll(containerDefinition, SceneEntryPoint.Global);
        }

        [SuppressMessage("", "Harmony003")]
        private static void InstallAll(IContainerDefinition containerDefinition, SceneEntryPoint entryPoint)
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