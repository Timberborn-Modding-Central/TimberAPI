using BepInEx;
using HarmonyLib;
using TimberbornAPI.Dependency;
using TimberbornAPI.UIBuilderSystem;

namespace TimberbornAPI.Internal {

    [BepInPlugin("com.timberapi.timberapi", "TimberAPI", "0.1.0")]
    public class TimberAPIPlugin : BaseUnityPlugin {

        public void Awake() {
            var harmony = new Harmony("com.timberapi.plugin");
            harmony.PatchAll();
            
            InstallUIBuilderConfigurators();
            Logger.LogInfo("TimberAPI is loaded!");
        }
        
        public void InstallUIBuilderConfigurators()
        {
            TimberAPI.Dependencies.AddConfigurator(new UIBuilderConfigurator(), EntryPoint.InGame);
            TimberAPI.Dependencies.AddConfigurator(new UIBuilderConfigurator(), EntryPoint.MainMenu);
            TimberAPI.Dependencies.AddConfigurator(new UIBuilderConfigurator(), EntryPoint.MapEditor);
        }
    }
}
