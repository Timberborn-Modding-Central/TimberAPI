using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using Bindito.Core;
using HarmonyLib;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.Common;
using TimberbornAPI.EntityActionSystem;
using TimberbornAPI.PluginSystem;
using TimberbornAPI.SpecificationSystem;
using TimberbornAPI.EntityLinkerSystem;
using TimberbornAPI.SpecificationSystem.Fixes.CustomSpecifications.Golems;
using TimberbornAPI.UIBuilderSystem;
using TimberbornAPI.SpecificationSystem.Buildings;

namespace TimberbornAPI.Internal
{

    [BepInPlugin("com.timberapi.timberapi", "TimberAPI", "0.4.3")]
    public class TimberAPIPlugin : BaseUnityPlugin
    {
        public static string Guid = "com.timberapi.timberapi";
        internal static ManualLogSource Log;

        public void Awake()
        {
            Log = Logger;

            new Harmony("com.timberapi.plugin").PatchAll();

            InstallConfigurators();
            
            TimberAPI.AssetRegistry.AddSceneAssets("timberApi", SceneEntryPoint.Global);
            
            Log.LogInfo("TimberAPI is loaded!");
        }

        /// <summary>
        /// Installs UI Builder configurators into the scenes in game, main menu & map editor
        /// </summary>
        public void InstallConfigurators()
        {
            TimberAPI.DependencyRegistry.AddConfigurator(new SpecificationConfigurator(), SceneEntryPoint.Global);
            TimberAPI.DependencyRegistry.AddConfigurator(new PluginConfigurator(), SceneEntryPoint.Global);
            TimberAPI.DependencyRegistry.AddConfiguratorBeforeLoad(new AssetConfigurator(), SceneEntryPoint.Global);
            TimberAPI.DependencyRegistry.AddConfiguratorBeforeLoad(new GolemFactionConfigurator(), SceneEntryPoint.InGame);
            TimberAPI.DependencyRegistry.AddConfigurator(new UIBuilderConfigurator(), SceneEntryPoint.Global);

            TimberAPI.DependencyRegistry.AddConfiguratorBeforeLoad(new BuildingSpecificationConfigurator(), SceneEntryPoint.InGame);
            TimberAPI.DependencyRegistry.AddConfiguratorBeforeLoad(new BuildingSpecificationConfigurator(), SceneEntryPoint.MapEditor);

            TimberAPI.DependencyRegistry.AddConfigurator(new EntityActionConfigurator(), SceneEntryPoint.MapEditor);
            TimberAPI.DependencyRegistry.AddConfigurators(new List<IConfigurator>
            {
                new EntityActionConfigurator(),
                new EntityLinkerConfigurator(),
            }, SceneEntryPoint.InGame);
        }
    }
}
