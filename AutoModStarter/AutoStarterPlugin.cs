using System;
using System.Linq;
using BepInEx;
using HarmonyLib;
using Timberborn.Modding;
using Timberborn.ModdingAssets;
using Timberborn.ModManagerScene;
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

class ModManagerScenePanelPatch
{
    [HarmonyPatch(typeof(ModManagerScenePanel), "Awake")]
    [HarmonyPrefix]
    static bool Prefix()
    {
        ModManagerScenePanel.LoadModsAndStartGame();
        return false;
    }
}

