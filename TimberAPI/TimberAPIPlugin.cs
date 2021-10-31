using BepInEx;
using HarmonyLib;

namespace TimberbornAPI.Internal {

    [BepInPlugin("com.timberapi.timberapi", "TimberAPI", "0.1.0")]
    public class TimberAPIPlugin : BaseUnityPlugin {

        public void Awake() {
            var harmony = new Harmony("com.timberapi.plugin");
            harmony.PatchAll();
            Logger.LogInfo("TimberAPI is loaded!");
        }
    }
}
