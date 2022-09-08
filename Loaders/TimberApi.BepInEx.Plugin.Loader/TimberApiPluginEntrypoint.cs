using System.IO;
using System.Reflection;
using BepInEx;
using Bindito.Core;
using HarmonyLib;
using TimberApi.Common.LoggingSystem;
using Timberborn.Bootstrapper;

namespace TimberApi.BepInExPlugin.Loader
{
    [BepInPlugin("timberapi.bepinex.entrypoint", "TimberAPI BepInEx Entrypoint", "1.0.0")]
    public class TimberApiPluginEntrypoint : BaseUnityPlugin
    {
        private static readonly string TimberApiRootPath = Directory.GetParent(Assembly.GetExecutingAssembly().Location)!.Parent.ToString();

        public void Awake()
        {
            new Harmony("TimberApi.BepInExEntry").Patch(
                original: AccessTools.Method(typeof(BootstrapperConfigurator), "Configure"),
                prefix: new HarmonyMethod(AccessTools.Method(typeof(TimberApiPluginEntrypoint), nameof(BootstrapperConfiguratorPatch)))
            );

            BepInExStartupLoader.Run(TimberApiRootPath);
        }

        public static void BootstrapperConfiguratorPatch(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<ILogListener>().To<BepInExConsoleListener>().AsSingleton();
        }
    }
}