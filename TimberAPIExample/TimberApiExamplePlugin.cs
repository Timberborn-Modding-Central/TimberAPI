using BepInEx;
using BepInEx.Logging;
using Bindito.Core;
using HarmonyLib;
using TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel;
using TimberbornAPI;
using TimberbornAPI.Common;
using TimberAPIExample.Examples.EntityActionExample;
using TimberAPIExample.Examples.AssetLoaderExample;
using TimberAPIExample.Examples.UIBuilderExample;
using TimberAPIExample.Examples.CustomObjectRegistryExample;
using TimberAPIExample.Examples.EventListenerExample;

namespace TimberAPIExample
{
    /// <summary>
    /// Example TimberAPI/BepInEx Plugin showing the power of the API
    /// </summary>
    [BepInPlugin("com.timberapi.example", "TimberAPIExample", "0.3.0")]
    [BepInDependency("com.timberapi.timberapi")]
    [HarmonyPatch]
    public class TimberAPIExamplePlugin : BaseUnityPlugin
    {

        internal static ManualLogSource Log;

        public void Awake()
        {
            // Saves the logger instance
            Log = Logger;

            // DependencyRegistry
            // This is the heart of TimberAPI. Use Configurators to tell the game that your codes exists
            TimberAPI.DependencyRegistry.AddConfigurator(new ExampleConfigurator());

            // AssetRegistry
            // Adds in game assets with a prefix of TimberAPIExample, default folder is assets
            TimberAPI.AssetRegistry.AddSceneAssets("TimberAPIExample", SceneEntryPoint.InGame);

            // Localization
            // Add a label to localization directly. Alternatively, use lang files (enUS.txt)
            TimberAPI.Localization.AddLabel("ExampleMod.ToolGroups.ExampleToolGroup", "Example Label");

            // Bind all the other configurators we use in examples.
            // These could all live in one Configurator, but we use multiple for readability
            TimberAPI.DependencyRegistry.AddConfigurator(new UIBuilderPanelConfigurator(), SceneEntryPoint.Global);
            TimberAPI.DependencyRegistry.AddConfigurators(new()
            {
                new AssetLoaderExampleConfigurator(),
                new UIBuilderFragmentConfigurator(),
                new EntityActionExampleConfigurator()
            });

            // CustomObjectRegistry
            // Load this before anything else is bound
            TimberAPI.DependencyRegistry.AddConfiguratorBeforeLoad(new CustomObjectExampleConfigurator());

            // Harmony patches
            new Harmony("com.timberapi.examples").PatchAll();

            Logger.LogInfo("TimberAPIExample is loaded!");
        }
    }

    /**
     * DependencyRegistry
     * Example IConfigurator for dependency injection
     * 1. Use Bind to inject the class, and 2. Add it via TimberAPI.Dependencies.AddConfigurator
     */
    public class ExampleConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ExampleListener>().AsSingleton();
        }
    }
}
