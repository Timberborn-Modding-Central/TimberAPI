using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Timberborn.ToolPanelSystem;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.Common;
using TimberbornAPI.CustomObjectSystem;
using TimberbornAPI.DependencySystem;
using TimberbornAPI.EntityActionSystem;
using TimberbornAPI.EntityLinkerSystem;
using TimberbornAPI.UIBuilderSystem;
using UnityEngine;

namespace TimberbornAPI.Internal
{

    [BepInPlugin("com.timberapi.timberapi", "TimberAPI", "0.3.0")]
    public class TimberAPIPlugin : BaseUnityPlugin
    {
        public static string Guid = "com.timberapi.timberapi";
        internal static ManualLogSource Log;

        public void Awake()
        {
            Log = Logger;

            var harmony = new Harmony("com.timberapi.plugin");
            harmony.PatchAll();

            InstallConfigurators();
            
            TimberAPI.AssetRegistry.AddSceneAssets("timberApi", SceneEntryPoint.Global, new []{ "assets" });
            
            Logger.LogInfo("TimberAPI is loaded!");
        }

        /// <summary>
        /// Installs UI Builder configurators into the scenes in game, main menu & map editor
        /// </summary>
        public void InstallConfigurators()
        {
            TimberAPI.DependencyRegistry.AddConfiguratorBeforeLoad(new AssetConfigurator(), SceneEntryPoint.Global);
            TimberAPI.DependencyRegistry.AddConfigurator(new UIBuilderConfigurator(), SceneEntryPoint.Global);
            
            TimberAPI.DependencyRegistry.AddConfigurator(new EntityActionConfigurator());
            TimberAPI.DependencyRegistry.AddConfigurator(new EntityActionConfigurator(), SceneEntryPoint.MapEditor);

            TimberAPI.DependencyRegistry.AddConfigurator(new EntityLinkerConfigurator(), SceneEntryPoint.InGame);
            TimberAPI.DependencyRegistry.AddConfigurator(new ObjectCollectionSystemConfigurator());
        }
    }
}
