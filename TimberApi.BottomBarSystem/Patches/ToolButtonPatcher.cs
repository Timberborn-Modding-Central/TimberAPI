using HarmonyLib;
using TimberApi.HarmonySystem;
using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.BottomBarSystem.Patches;

public class ToolButtonPatcher
{
    public static ToolButton? ActiveToolButton { get; set; }

    public static void Patch(Harmony harmony)
    {
        harmony.Patch(
            harmony.GetMethodInfo<ToolButton>(nameof(ToolButton.Select)),
            prefix: harmony.GetHarmonyMethod<ToolButtonPatcher>(nameof(OnButtonClickedPatch))
        );
        
        harmony.Patch(
            harmony.GetMethodInfo<ToolButton>(nameof(ToolButton.OnToolEntered), new []{ typeof(ToolEnteredEvent)}),
            prefix: harmony.GetHarmonyMethod<ToolButtonPatcher>(nameof(OnToolEnteredPatch))
        );
    }

    public static void OnButtonClickedPatch(ToolButton __instance, ToolGroupManager ____toolGroupManager)
    {
        ActiveToolButton = __instance;

        if(__instance.Tool.ToolGroup == null)
        {
            return;
        }

        ____toolGroupManager.SwitchToolGroup(__instance.Tool.ToolGroup);
    }
    
    public static bool OnToolEnteredPatch(ToolEnteredEvent toolEnteredEvent)
    {
        return toolEnteredEvent.Tool is not IUnselectableTool;
    }
}