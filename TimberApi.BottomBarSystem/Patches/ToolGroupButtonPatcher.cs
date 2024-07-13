using System;
using System.Linq;
using HarmonyLib;
using TimberApi.HarmonySystem;
using TimberApi.SingletonSystem;
using TimberApi.Tools.ToolGroupSystem;
using TimberApi.Tools.ToolSystem;
using Timberborn.CoreUI;
using Timberborn.CursorToolSystem;
using Timberborn.ToolSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.BottomBarSystem.Patches;

public class ToolGroupButtonPatcher
{
    private static ToolGroupService _toolGroupService = null!;
        
    private static BottomBarService _bottomBarService = null!;

    private static readonly string ActiveClassName = "button--active";

    public ToolGroupButtonPatcher(BottomBarService bottomBarService, ToolGroupService toolGroupService)
    {
        _bottomBarService = bottomBarService;
        _toolGroupService = toolGroupService;
    }

    public static void Patch(Harmony harmony)
    {
        harmony.Patch(
            harmony.GetMethodInfo<ToolButtonService>(nameof(ToolButtonService.Add), new Type[] { typeof(ToolButton) }),
            harmony.GetHarmonyMethod<ToolGroupButtonPatcher>(nameof(AddPatch)));
            
        harmony.Patch(
            AccessTools.PropertyGetter(typeof(ToolGroupButton), nameof(ToolGroupButton.IsVisible)),
            harmony.GetHarmonyMethod<ToolGroupButtonPatcher>(nameof(ContainsToolPatch))
        );

        harmony.Patch(
            harmony.GetMethodInfo<ToolGroupButton>(nameof(ToolGroupButton.OnToolGroupEntered)),
            harmony.GetHarmonyMethod<ToolGroupButtonPatcher>(nameof(OnToolGroupEntered))
        );

        harmony.Patch(
            harmony.GetMethodInfo<ToolGroupButton>(nameof(ToolGroupButton.OnToolGroupExited)),
            harmony.GetHarmonyMethod<ToolGroupButtonPatcher>(nameof(OnToolGroupExited))
        );
    }

    public static bool AddPatch(ToolButton toolButton, ToolButtonService __instance)
    {
        __instance._toolButtons.Add(toolButton);
            
        if (toolButton.Tool.ToolGroup != null)
        {
            return false;
        }

        if (toolButton.Tool is not IUnselectableTool && toolButton.Tool is not CursorTool)
        {
            __instance._rootButtons.Add(toolButton);
        }

        return false;
    }

    public static bool ContainsToolPatch(ref bool __result, ToolGroup ____toolGroup, ToolGroupButton __instance)
    {
        if (____toolGroup is not IToolGroup apiToolGroup)
        {
            return false;
        }

        var hasActiveTool = __instance._toolButtons.Any<ToolButton>(button => button.ToolEnabled);

        if (hasActiveTool)
        {
            __result = true;
            return false;
        }

        __result = _toolGroupService
            .GetToolGroupButtonByGroupId(apiToolGroup.Id)
            .Any(button => button.IsVisible);

        return false;
    }

    public static bool OnToolGroupEntered(ToolGroupEnteredEvent toolGroupEnteredEvent, ToolGroupButton __instance, ToolGroup ____toolGroup, VisualElement ____toolGroupButtonWrapper)
    {
        if(toolGroupEnteredEvent.ToolGroup is not IToolGroup enteredToolGroup || ____toolGroup is not IToolGroup toolGroup) return false;

        var row = _bottomBarService.GetGroupRow(toolGroup.Id);
        var enteredRow = _bottomBarService.GetGroupRow(enteredToolGroup.Id);

        if(row >= enteredRow && toolGroupEnteredEvent.ToolGroup != ____toolGroup)
        {
            __instance.ToolButtonsElement.ToggleDisplayStyle(false);
            ____toolGroupButtonWrapper.RemoveFromClassList(ActiveClassName);
        }

        if(toolGroupEnteredEvent.ToolGroup != ____toolGroup) return false;

        __instance.ToolButtonsElement.ToggleDisplayStyle(true);
        ____toolGroupButtonWrapper.AddToClassList(ActiveClassName);

        return false;
    }

    public static bool OnToolGroupExited(ToolGroupExitedEvent toolGroupExitedEvent, ToolGroupButton __instance, VisualElement ____toolGroupButtonWrapper)
    {
        if(toolGroupExitedEvent.ToolGroup is not ExitingToolGroup) return false;

        __instance.ToolButtonsElement.ToggleDisplayStyle(false);
        ____toolGroupButtonWrapper.RemoveFromClassList(ActiveClassName);

        return false;
    }
}