using BepInEx;
using Bindito.Core;
using HarmonyLib;
using TimberApi.Core.LoggingSystem;
using Timberborn.Bootstrapper;

namespace TimberApi.BepInExPlugin
{
    [BepInPlugin("timberapi.bepinex.entrypoint", "TimberAPI BepInEx Entrypoint", "1.0.0")]
    public class TimberApiPluginEntrypoint : BaseUnityPlugin
    {
        public void Awake()
        {
            Harmony harmony = new Harmony("TimberApi.BepInExEntry");

            harmony.Patch(
                original: AccessTools.Method(typeof(BootstrapperConfigurator), "Configure"),
                prefix: new HarmonyMethod(AccessTools.Method(typeof(TimberApiPluginEntrypoint), nameof(BootstrapperConfiguratorPatch)))
            );

            TimberApiLoader.Start();
        }

        public static void BootstrapperConfiguratorPatch(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<ILogListener>().To<BepInExConsoleListener>().AsSingleton();
        }
    }
}