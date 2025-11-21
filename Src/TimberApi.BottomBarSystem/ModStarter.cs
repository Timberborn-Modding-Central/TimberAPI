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

    public void StartMod(IModEnvironment modEnvironment)
    {
        _harmony = new Harmony("TimberApi.BottomBar");
        ContextManager.ContextChanged += SceneManagerOnContextChanged;
    }

    private void SceneManagerOnContextChanged(string previousscene, string currentscene)
    {
        if (currentscene != "Game")
        {
            _harmony.UnpatchAll("TimberApi.BottomBar");
            return;
        }

        if (previousscene == "Game")
        {
            return;
        }

        try
        {
            BottomBarConfiguratorPatcher.Patch(_harmony);
            ToolbarButtonRetrieverPatcher.Patch(_harmony);
            ToolButtonPatcher.Patch(_harmony);
            ToolGroupButtonPatcher.Patch(_harmony);
            ToolGroupManagerPatcher.Patch(_harmony);
        }
        catch (Exception e)
        {
            Debug.LogError("TimberApi.BottomBar failed to apply patches");
            Debug.LogError($"TimberApi.BottomBar {e}");
        }
    }
}