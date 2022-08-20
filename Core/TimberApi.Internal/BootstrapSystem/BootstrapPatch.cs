using System;
using System.IO;
using Bindito.Core;
using HarmonyLib;
using TimberApi.Internal.Common;
using Timberborn.Bootstrapper;

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
        private static void BootstrapperConfiguratorPatch(IContainerDefinition containerDefinition)
        {
            // When no hope is left, able to have a very specific loading order
            // containerDefinition.Bind<ISingletonRepository>().To<SingletonRepository>().AsSingleton();
            // SingletonListener instance = new SingletonListener();
            // containerDefinition.Bind<SingletonListener>().ToInstance(instance);
            // containerDefinition.AddInjectionListener(instance);
            // containerDefinition.AddProvisionListener(instance);

            containerDefinition.Install(TimberApiBootstrapConfigurator.Instance);
            containerDefinition.Bind<TimberApiRunner>().AsSingleton();
        }
    }
}