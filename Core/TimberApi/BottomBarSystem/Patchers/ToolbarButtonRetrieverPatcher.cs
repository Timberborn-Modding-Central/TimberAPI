using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using TimberApi.HarmonyPatcherSystem;
using Timberborn.ToolSystem;

namespace TimberApi.BottomBarSystem.Patchers
{
    public class ToolbarButtonRetrieverPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberApi.ToolButtonRetriever";
        
        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<ToolbarButtonRetriever>(nameof(ToolbarButtonRetriever.TryGetPreviousVisibleButton)),
                GetHarmonyMethod(nameof(TryGetPreviousVisibleButtonPatch))
            );
        }
        
        public static bool TryGetPreviousVisibleButtonPatch(IEnumerable<IToolbarButton> buttons, out IToolbarButton? previousButton)
        {
            previousButton = null;
            return buttons.Any(button => button.IsVisible);
        }
    }
}