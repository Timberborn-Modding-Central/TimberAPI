using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Timberborn.ToolPanelSystem;
using TimberbornAPI.Common;
using TimberbornAPI.EntityActionSystem;
using TimberbornAPI.UIBuilderSystem;
using UnityEngine;

namespace TimberbornAPI.Internal
{

    [BepInPlugin("com.timberapi.timberapi", "TimberAPI", "0.1.0")]
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
            TimberAPI.DependecyRegistry.AddConfigurator(new UIBuilderConfigurator(), SceneEntryPoint.InGame);
            TimberAPI.DependecyRegistry.AddConfigurator(new UIBuilderConfigurator(), SceneEntryPoint.MainMenu);
            TimberAPI.DependecyRegistry.AddConfigurator(new UIBuilderConfigurator(), SceneEntryPoint.MapEditor);
            
            TimberAPI.DependecyRegistry.AddConfigurator(new EntityActionConfigurator(), SceneEntryPoint.InGame);
            TimberAPI.DependecyRegistry.AddConfigurator(new EntityActionConfigurator(), SceneEntryPoint.MapEditor);
        }
    }
}
