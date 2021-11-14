using BepInEx;
using HarmonyLib;
using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem;

namespace TimberbornAPI.Internal {

    [BepInPlugin("com.timberapi.timberapi", "TimberAPI", "0.1.0")]
    public class TimberAPIPlugin : BaseUnityPlugin {
        public static string Guid = "com.timberapi.timberapi";

        public void Awake() {
            var harmony = new Harmony("com.timberapi.plugin");
            harmony.PatchAll();
            
            InstallUIBuilderConfigurators();
            Logger.LogInfo("TimberAPI is loaded!");
        }
        
        /// <summary>
        /// Installs UI Builder configurators into the scenes in game, main menu & map editor
        /// </summary>
        public void InstallUIBuilderConfigurators()
        {
            TimberAPI.Dependencies.AddConfigurator(new UIBuilderConfigurator(), SceneEntryPoint.InGame);
            TimberAPI.Dependencies.AddConfigurator(new UIBuilderConfigurator(), SceneEntryPoint.MainMenu);
            TimberAPI.Dependencies.AddConfigurator(new UIBuilderConfigurator(), SceneEntryPoint.MapEditor);
        }
    }
}
