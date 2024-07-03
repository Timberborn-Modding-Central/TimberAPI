using System;
using HarmonyLib;
using TimberApi.BottomBarSystem.Patches;
using Timberborn.ModManagerScene;
using UnityEngine;

namespace TimberApi.BottomBarSystem;

public class ModStarter : IModStarter
{
    public void StartMod()
    {
        try
        {
            var harmony = new Harmony("TimberApi.BottomBar");

            BottomBarConfiguratorPatcher.Patch(harmony);
            ToolbarButtonRetrieverPatcher.Patch(harmony);
            ToolButtonPatcher.Patch(harmony);
            ToolGroupButtonPatcher.Patch(harmony);
            ToolGroupManagerPatcher.Patch(harmony);
        }
        catch (Exception e)
        {
            Debug.LogError("TimberApi.BottomBar failed to apply patches");
            Debug.LogError($"TimberApi.BottomBar {e}");
        }
    }
}