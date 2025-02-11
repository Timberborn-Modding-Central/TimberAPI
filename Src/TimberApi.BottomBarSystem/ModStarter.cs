using System;
using Bindito.Core;
using HarmonyLib;
using TimberApi.BottomBarSystem.Patches;
using Timberborn.ModManagerScene;
using UnityEngine;

namespace TimberApi.BottomBarSystem;

public class ModStarter : IModStarter
{
    private static Harmony _harmony = null!;

    public void StartMod()
    {
        _harmony = new Harmony("SWAGGERSWAGY");
        ContextManager.ContextChanged += SceneManagerOnContextChanged;
    }

    private void SceneManagerOnContextChanged(string previousscene, string currentscene)
    {
        if (currentscene != "Game")
        {
            Debug.LogWarning("REMOVE PATCHES");
            return;
        }

        if (previousscene == "Game")
        {
            Debug.LogWarning("It went from game to game");
            return;
        }

        try
        {
            BottomBarConfiguratorPatcher.Patch(_harmony);
            ToolbarButtonRetrieverPatcher.Patch(_harmony);
            ToolButtonPatcher.Patch(_harmony);
            ToolGroupButtonPatcher.Patch(_harmony);
            ToolGroupManagerPatcher.Patch(_harmony);
            DisableTimberbornToolGeneration.Patch(_harmony);
        }
        catch (Exception e)
        {
            Debug.LogError("TimberApi.BottomBar failed to apply patches");
            Debug.LogError($"TimberApi.BottomBar {e}");
        }
    }
}