﻿using System;
using System.IO;
using Bindito.Core;
using HarmonyLib;
using TimberApi.Core.Common;
using TimberApi.Core.SingletonSystem;
using TimberApi.Core2.Common;
using Timberborn.Bootstrapper;
using Timberborn.MasterScene;
using UnityEngine;

namespace TimberApi.Core.BootstrapSystem
{
    public static class BootstrapPatch
    {
        public static void Apply()
        {
            try
            {
                var harmony = new Harmony("TimberApi.bootstrapper");

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
            containerDefinition.Install(TimberApiBootstrapSystemConfigurator.Instance);
        }
    }
}