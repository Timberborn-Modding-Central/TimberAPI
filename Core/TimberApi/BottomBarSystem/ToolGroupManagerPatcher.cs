using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using TimberApi.Common.Extensions;
using TimberApi.HarmonyPatcherSystem;
using TimberApi.ToolGroupSystem;
using Timberborn.ToolSystem;

namespace TimberApi.BottomBarSystem
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ToolGroupManagerPatcher : BaseHarmonyPatcher
    {
        private static readonly ToolGroup ExitingToolGroup = new ExitingTool();

        public override string UniqueId => "TimberApi.ToolGroupManager";

        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<ToolGroupManager>(nameof(ToolGroupManager.SwitchToolGroup)),
                GetHarmonyMethod(nameof(SwitchToolGroupPatch))
            );
        }

        public static void SwitchToolGroupPatch(ToolGroup? toolGroup, ToolGroupManager __instance)
        {
            if (toolGroup != null)
            {
                return;
            }

            __instance.SetPrivateInstancePropertyValue("ActiveToolGroup", ExitingToolGroup);
        }
    }
}