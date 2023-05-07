using System;
using System.IO;
using Bindito.Core;
using HarmonyLib;
using TimberApi.Common;
using TimberApi.HarmonyPatcherSystem;
using Timberborn.Bootstrapper;

namespace TimberApi.Core.BootstrapSystem
{
    internal class BootstrapPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberApi.Bootstrapper";

        public override void Apply(Harmony harmony)
        {
            try
            {
                harmony.Patch(
                    GetMethodInfo<BootstrapperConfigurator>("Configure"),
                    GetHarmonyMethod(nameof(BootstrapperConfiguratorPatch))
                );
            }
            catch (Exception e)
            {
                File.WriteAllText(Path.Combine(Paths.Logs, $"HarmonyException-{DateTime.Now:yyyy-MM-dd-HH\\hmm\\mss\\s}.log"), e.ToString());
                throw;
            }
        }

        /// <summary>
        ///     Prefixes bootstrapper to install itself into bindito
        /// </summary>
        /// <param name="containerDefinition"></param>
        private static void BootstrapperConfiguratorPatch(IContainerDefinition containerDefinition)
        {
            containerDefinition.Install(TimberApiBootstrapSystemConfigurator.Instance);
        }
    }
}