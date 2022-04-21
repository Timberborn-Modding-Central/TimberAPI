using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.Common;
using TimberbornAPI.CustomObjectSystem;
using TimberbornAPI.EntityActionSystem;
using TimberbornAPI.EntityLinkerSystem;
using TimberbornAPI.UIBuilderSystem;

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
            TimberAPI.DependencyRegistry.AddConfiguratorBeforeLoad(new AssetConfigurator(), SceneEntryPoint.Global);
            TimberAPI.DependencyRegistry.AddConfigurator(new UIBuilderConfigurator(), SceneEntryPoint.Global);
            
            TimberAPI.DependencyRegistry.AddConfigurator(new EntityActionConfigurator(), SceneEntryPoint.MapEditor);

            TimberAPI.DependencyRegistry.AddConfigurators(new() {
                new EntityActionConfigurator(),
                new EntityLinkerConfigurator(),
                new ObjectCollectionSystemConfigurator()
            }, SceneEntryPoint.InGame);
        }
    }
}
