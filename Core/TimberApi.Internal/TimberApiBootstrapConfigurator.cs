using System;
using System.IO;
using Bindito.Core;
using Bindito.Unity;
using HarmonyLib;
using TimberApi.Internal.Common;
using TimberApi.Internal.DependencyContainerSystem;
using TimberApi.Internal.LoggingSystem;
using TimberApi.Internal.ModLoaderSystem;
using TimberApi.Internal.TimberApiVisualizer;
using Timberborn.Bootstrapper;
using Timberborn.SceneLoading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TimberApi.Internal
{
    internal class TimberApiBootstrapConfigurator : PrefabConfigurator
    {
        private static TimberApiBootstrapConfigurator _instance = null!;

        /// <summary>
        /// TimberApi bootstrapConfigurator
        /// </summary>
        public override void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Install(new DependencyContainerConfigurator());
            containerDefinition.Install(GetInstanceFromPrefab<LoggingConfigurator>());
            containerDefinition.Bind<TimberApiGameStartLogger>().AsSingleton();

            containerDefinition.Bind<Visualizer>().AsSingleton();

            containerDefinition.Install(new ModLoaderConfigurator());
        }

        /// <summary>
        /// Register prefabConfigurators
        /// </summary>
        private void AddPrefabConfigurators()
        {
            LoggingConfigurator.Prefab(gameObject);
        }

        private void Test()
        {

        }

        /// <summary>
        /// The first active monoBehaviour of TimberApi
        /// </summary>
        private void Awake()
        {
            try
            {
                _instance = this;
                AddPrefabConfigurators();
                HarmonyPatches();
            }
            catch (Exception e)
            {
                File.WriteAllText(Path.Combine(Paths.Logs, $"TimberApiLoadException-{DateTime.Now:yyyy-MM-dd-HH\\hmm\\mss\\s}.log"), e.ToString());
                throw;
            }
        }

        private static void HarmonyPatches()
        {
            try
            {
                var harmony = new Harmony("timberApi.bootstrapper");

                harmony.Patch(
                    original: AccessTools.Method(typeof(BootstrapperConfigurator), "Configure"),
                    prefix: new HarmonyMethod(AccessTools.Method(typeof(TimberApiBootstrapConfigurator), nameof(BootstrapPatch)))
                );
            }
            catch (Exception e)
            {
                File.WriteAllText(Path.Combine(Paths.Logs, $"HarmonyException-{DateTime.Now:yyyy-MM-dd-HH\\hmm\\mss\\s}.log"), e.ToString());
                throw;
            }
        }

        /// <summary>
        /// Prefixes bootstrapper to install itself into bindito
        /// </summary>
        /// <param name="containerDefinition"></param>
        private static void BootstrapPatch(IContainerDefinition containerDefinition)
        {
            containerDefinition.Install(_instance);
        }
    }
}