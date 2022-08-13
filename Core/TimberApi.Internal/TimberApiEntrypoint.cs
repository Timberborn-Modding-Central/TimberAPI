using System.Reflection;
using HarmonyLib;
using TimberApi.Internal.Common;
using TimberApi.Internal.ConfiguratorSystem;
using TimberApi.LoaderInterfaces;
using Timberborn.Core;

namespace TimberApi.Internal
{
    internal class TimberApiEntrypoint : ITimberApiPatcher
    {
        public void Initialize()
        {
            TimberApiEnvironments.Load();
            ConfiguratorBootstrapper.Initialize();
            new Harmony("timberApi.patcher").PatchAll();
        }
    }

    // [HarmonyPatch(typeof(BootstrapperConfigurator), nameof(IContainerDefinition))]
    // internal class TimberApiInitialBootstrapperConfiguratorPatch
    // {
    //     public static void PostFix(IContainerDefinition containerDefinition)
    //     {
    //         containerDefinition.Install();
    //     }
    // }

    [HarmonyPatch]
    static class FixLag
    {
        private static MethodInfo TargetMethod() {
            return AccessTools.Method(typeof(GameStartLogger), "AppendDriveInfo");
        }

        private static bool Prefix()
        {
            return false;
        }
    }
}