using HarmonyLib;
using TimberApi.HarmonyPatcherSystem;
using TimberApi.SceneSystem;
using Timberborn.ToolSystem;

namespace TimberApi.BottomBarSystem.Patchers
{
    public class ToolButtonPatcher : BaseHarmonyPatcher
    {
        public static ToolButton? ActiveToolButton { get; set; }

        public override string UniqueId => "TimberApi.ToolButton";

        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<ToolButton>(nameof(ToolButton.Select)),
                prefix: GetHarmonyMethod(nameof(OnButtonClickedPatch))
            );
        }
        
        public override bool ShouldApply(SceneEntrypoint? sceneEntrypoint)
        {
            return sceneEntrypoint == SceneEntrypoint.InGame;
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
}