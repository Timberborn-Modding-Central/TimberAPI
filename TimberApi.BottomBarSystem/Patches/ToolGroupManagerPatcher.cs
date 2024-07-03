using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using TimberApi.HarmonySystem;
using TimberApi.Tools.ToolGroupSystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.BottomBarSystem.Patches;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class ToolGroupManagerPatcher
{
    private static readonly ToolGroup ExitingToolGroup = new ExitingToolGroup();

    public static void Patch(Harmony harmony)
    {
        harmony.Patch(
            harmony.GetMethodInfo<ToolGroupManager>(nameof(ToolGroupManager.SwitchToolGroup)),
            harmony.GetHarmonyMethod<ToolGroupManagerPatcher>(nameof(SwitchToolGroupPatch))
        );
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