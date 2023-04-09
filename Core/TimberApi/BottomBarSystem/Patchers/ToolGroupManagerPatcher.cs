using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using TimberApi.Common.Extensions;
using TimberApi.Common.SingletonSystem;
using TimberApi.DependencyContainerSystem;
using TimberApi.HarmonyPatcherSystem;
using TimberApi.ToolGroupSystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.BottomBarSystem.Patchers
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ToolGroupManagerPatcher : BaseHarmonyPatcher, ITimberApiLoadableSingleton
    {
        private static readonly ToolGroup ExitingToolGroup = new ExitingTool();

        private static EventBus _eventBus = null!;

        public override string UniqueId => "TimberApi.ToolGroupManager";

        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<ToolGroupManager>(nameof(ToolGroupManager.SwitchToolGroup)),
                GetHarmonyMethod(nameof(SwitchToolGroupPatch))
            );
        }

        public void Load()
        {
            _eventBus = DependencyContainer.GetInstance<EventBus>();
        }

        public static void SwitchToolGroupPatch(ToolGroup? toolGroup, ToolGroupManager __instance)
        {
            ToolButtonPatcher.ActiveToolButton?.Root.EnableInClassList("button--active", false);

            if(toolGroup != null)
            {
                return;
            }

            __instance.SetPrivateInstancePropertyValue("ActiveToolGroup", ExitingToolGroup);
        }
    }
}