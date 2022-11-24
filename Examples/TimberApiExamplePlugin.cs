using HarmonyLib;
using TimberApi.ModSystem;
using TimberApi.ConsoleSystem;
using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberAPIExample.Examples.ConfigExample;

namespace TimberAPIExample
{
    /// <summary>
    /// Example TimberAPI.Old/BepInEx Plugin showing the power of the API
    /// </summary>
    [HarmonyPatch]
    public class TimberAPIExamplePlugin : IModEntrypoint
    {

        internal static IConsoleWriter Log;

        public ExampleConfig Config { get; set; }

        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            Log = consoleWriter;

            Config = mod.Configs.Get<ExampleConfig>();

            Log.LogInfo($"ConfigValue1: {Config.ConfigValue1}");
            Log.LogInfo($"ConfigValue2: {Config.ConfigValue2}");

            // Harmony patches
            new Harmony("com.timberapi.examples").PatchAll();

            Log.LogInfo("TimberAPIExample is loaded!");
        }
    }

    /**
     * DependencyRegistry
     * This is the heart of TimberAPI. Use Configurators to tell the game that your codes exists
     * Example IConfigurator for dependency injection
     * 1. Use Bind to inject the class, and 2. Add it with [Configurator] attribute
     */

    //[Configurator(SceneEntrypoint.InGame)]
    //public class ExampleConfigurator : IConfigurator
    //{
    //    public void Configure(IContainerDefinition containerDefinition)
    //    {
    //        containerDefinition.Bind<ExampleListener>().AsSingleton();
    //    }
    //}
}
