using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Timberborn.ToolPanelSystem;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.Common;
using TimberbornAPI.DependencySystem;
using TimberbornAPI.EntityActionSystem;
using TimberbornAPI.ObjectCollectionSystem;
using TimberbornAPI.UIBuilderSystem;
using UnityEngine;

namespace TimberbornAPI.Internal
{

    [BepInPlugin("com.timberapi.timberapi", "TimberAPI", "0.3.0")]
    public class TimberAPIPlugin : BaseUnityPlugin
    {
        public static string Guid = "com.timberapi.timberapi";
        
        public void Awake()
        {
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
            TimberAPI.DependencyRegistry.AddConfigurator(new AssetConfigurator(), SceneEntryPoint.Global, true);
            TimberAPI.DependencyRegistry.AddConfigurator(new UIBuilderConfigurator(), SceneEntryPoint.Global);
            
            TimberAPI.DependencyRegistry.AddConfigurator(new EntityActionConfigurator());
            TimberAPI.DependencyRegistry.AddConfigurator(new EntityActionConfigurator(), SceneEntryPoint.MapEditor);

            TimberAPI.DependencyRegistry.AddConfigurator(new ObjectCollectionSystemConfigurator());
        }
    }
}
