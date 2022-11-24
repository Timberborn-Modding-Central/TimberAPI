using System.IO;
using System.Reflection;
using BepInEx;
using Bindito.Core;
using HarmonyLib;
using TimberApi.Common.LoggingSystem;
using Timberborn.Bootstrapper;
using Timberborn.Core;

namespace TimberApi.BepInExPlugin.Loader
{
    [BepInPlugin("timberapi.bepinex.entrypoint", "TimberAPI BepInEx Entrypoint", "1.0.0")]
    public class TimberApiPluginEntrypoint : BaseUnityPlugin
    {
        private static readonly string TimberApiRootPath =
            Directory.GetParent(Assembly.GetExecutingAssembly().Location)!.Parent.ToString();

        public void Awake()
        {
            var harmony = new Harmony("TimberApi.BepInExEntry");

            harmony.Patch(AccessTools.Method(typeof(BootstrapperConfigurator), "Configure"),
                new HarmonyMethod(AccessTools.Method(typeof(TimberApiPluginEntrypoint),
                    nameof(BootstrapperConfiguratorPatch))));

            harmony.Patch(AccessTools.Method(typeof(GameStartLogger), "Log"),
                new HarmonyMethod(
                    AccessTools.Method(typeof(TimberApiPluginEntrypoint), nameof(GameStartLoggerLogPatch))));
        }

        public static void GameStartLoggerLogPatch()
        {
            BepInExStartupLoader.Run(TimberApiRootPath);
        }

        public static void BootstrapperConfiguratorPatch(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<ILogListener>().To<BepInExConsoleListener>().AsSingleton();
        }
    }
}