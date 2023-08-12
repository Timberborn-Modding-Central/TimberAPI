using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using TimberApi.HarmonyPatcherSystem;
using TimberApi.SceneSystem;
using TimberApi.ToolGroupSystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.BottomBarSystem.Patchers
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ToolGroupManagerPatcher : BaseHarmonyPatcher
    {
        private static readonly ToolGroup ExitingToolGroup = new ExitingToolGroup();

        public override string UniqueId => "TimberApi.ToolGroupManager";

        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<ToolGroupManager>(nameof(ToolGroupManager.SwitchToolGroup)),
                GetHarmonyMethod(nameof(SwitchToolGroupPatch))
            );
        }
        
        public override bool ShouldApply(SceneEntrypoint? sceneEntrypoint)
        {
            return sceneEntrypoint == SceneEntrypoint.InGame;
        }

        public static void SwitchToolGroupPatch(ToolGroup? toolGroup, ToolGroupManager __instance, EventBus ____eventBus)
        {
            ToolButtonPatcher.ActiveToolButton?.Root.EnableInClassList("button--active", false);

            if(toolGroup != null)
            {
                return;
            }
            
            ____eventBus.Post(new ToolGroupExitedEvent(__instance.ActiveToolGroup));
            
            __instance.ActiveToolGroup = ExitingToolGroup;
        }
    }
}