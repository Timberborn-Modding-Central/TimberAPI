using HarmonyLib;
using TimberApi.HarmonySystem;
using Timberborn.ToolSystem;

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
}