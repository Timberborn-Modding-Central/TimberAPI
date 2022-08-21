using System;
using System.IO;
using Bindito.Core;
using HarmonyLib;
using TimberApi.Internal.Common;
using TimberApi.Internal.SingletonSystem;
using Timberborn.Bootstrapper;
using Timberborn.MasterScene;
using UnityEngine;

namespace TimberApi.Internal.BootstrapSystem
{
    public static class BootstrapPatch
    {
        public static void Apply()
        {
            try
            {
                var harmony = new Harmony("timberApi.bootstrapper");

                harmony.Patch(
                    original: AccessTools.Method(typeof(BootstrapperConfigurator), "Configure"),
                    prefix: new HarmonyMethod(AccessTools.Method(typeof(BootstrapPatch), nameof(BootstrapperConfiguratorPatch)))
                );

                harmony.Patch(
                    original: AccessTools.Method(typeof(MasterSceneConfigurator), "Configure"),
                    prefix: new HarmonyMethod(AccessTools.Method(typeof(BootstrapPatch), nameof(Pogs)))
                );
            }
            catch (Exception e)
            {
                File.WriteAllText(Path.Combine(Paths.Logs, $"HarmonyException-{DateTime.Now:yyyy-MM-dd-HH\\hmm\\mss\\s}.log"), e.ToString());
                throw;
            }
        }

        private static void Pogs()
        {
            throw new Exception("AAAA");
            Debug.Log("AAAA");
        }

        /// <summary>
        /// Prefixes bootstrapper to install itself into bindito
        /// </summary>
        /// <param name="containerDefinition"></param>
        private static void BootstrapperConfiguratorPatch(IContainerDefinition containerDefinition)
        {
            // Timberborns singleton system replicated
            containerDefinition.Bind<ISingletonRepository>().To<SingletonRepository>().AsSingleton();
            SingletonListener instance = new SingletonListener();
            containerDefinition.Bind<SingletonListener>().ToInstance(instance);
            containerDefinition.AddInjectionListener(instance);
            containerDefinition.AddProvisionListener(instance);

            containerDefinition.Install(TimberApiBootstrapConfigurator.Instance);

            containerDefinition.Bind<TimberApiRunner>().AsSingleton();
        }
    }
}