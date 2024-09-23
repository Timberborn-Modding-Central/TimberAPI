using BepInEx;
using HarmonyLib;
using Timberborn.ModManagerSceneUI;

namespace AutoModStarter;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class AutoStarterPlugin : BaseUnityPlugin
{
    private void Awake()
    {
        Harmony.CreateAndPatchAll(typeof(ModManagerScenePanelPatch));
    }
}

internal class ModManagerScenePanelPatch
{
    [HarmonyPatch(typeof(ModManagerScenePanel), "Awake")]
    [HarmonyPrefix]
    private static bool Prefix(ModManagerScenePanel __instance)
    {
        __instance.LoadModsAndStartGame();
        return false;
    }
}