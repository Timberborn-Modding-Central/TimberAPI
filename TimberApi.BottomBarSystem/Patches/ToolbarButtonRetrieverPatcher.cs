using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using TimberApi.HarmonySystem;
using Timberborn.ToolSystem;

namespace TimberApi.BottomBarSystem.Patches;

public class ToolbarButtonRetrieverPatcher
{
    public static void Patch(Harmony harmony)
    {
        harmony.Patch(
            harmony.GetMethodInfo<ToolbarButtonRetriever>(nameof(ToolbarButtonRetriever.TryGetPreviousVisibleButton)),
            harmony.GetHarmonyMethod<ToolbarButtonRetrieverPatcher>(nameof(TryGetPreviousVisibleButtonPatch))
        );
    }

    public static bool TryGetPreviousVisibleButtonPatch(IEnumerable<IToolbarButton> buttons,
        out IToolbarButton? previousButton)
    {
        previousButton = null;
        return buttons.Any(button => button.IsVisible);
    }
}