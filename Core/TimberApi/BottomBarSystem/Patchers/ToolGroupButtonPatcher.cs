using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using TimberApi.Common.SingletonSystem;
using TimberApi.DependencyContainerSystem;
using TimberApi.HarmonyPatcherSystem;
using TimberApi.SceneSystem;
using TimberApi.ToolGroupSystem;
using TimberApi.ToolSystem;
using Timberborn.Common;
using Timberborn.CoreUI;
using Timberborn.CursorToolSystem;
using Timberborn.Debugging;
using Timberborn.ToolSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.BottomBarSystem.Patchers
{
    public class ToolGroupButtonPatcher : BaseHarmonyPatcher, ITimberApiLoadableSingleton
    {
        private static ToolGroupService _toolGroupService = null!;
        
        private static BottomBarService _bottomBarService = null!;

        private static DevModeManager _devModeManager = null!;

        private static readonly string ActiveClassName = "button--active";

        public override string UniqueId => "TimberApi.ToolGroupButton";

        public void Load()
        {
            _bottomBarService = DependencyContainer.GetInstance<BottomBarService>();
            _devModeManager = DependencyContainer.GetInstance<DevModeManager>();
            _toolGroupService = DependencyContainer.GetInstance<ToolGroupService>();
        }

        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<ToolButtonService>(nameof(ToolButtonService.Add), new Type[] { typeof(ToolButton) }),
                GetHarmonyMethod(nameof(AddPatch)));

            harmony.Patch(
                AccessTools.PropertyGetter(typeof(ToolButton), nameof(ToolButton.IsVisible)),
                postfix: GetHarmonyMethod(nameof(TestButtonPatch))
            );
            
            harmony.Patch(
                AccessTools.PropertyGetter(typeof(ToolGroupButton), nameof(ToolGroupButton.IsVisible)),
                GetHarmonyMethod(nameof(ContainsToolPatch))
            );

            harmony.Patch(
                GetMethodInfo<ToolGroupButton>(nameof(ToolGroupButton.OnToolGroupEntered)),
                GetHarmonyMethod(nameof(OnToolGroupEntered))
            );

            harmony.Patch(
                GetMethodInfo<ToolGroupButton>(nameof(ToolGroupButton.OnToolGroupExited)),
                GetHarmonyMethod(nameof(OnToolGroupExited))
            );
            
            harmony.Patch(
                GetMethodInfo<ToolbarButtonRetriever>(nameof(ToolbarButtonRetriever.GetActiveButtonIndex)),
                GetHarmonyMethod(nameof(TestPatch))
            );
        }
        
        public static void TestButtonPatch(ref bool __result, ToolButton __instance)
        {
            Debug.LogWarning(__result);
            
            Debug.LogWarning("ToolGroup: " + __instance.Tool.ToolGroup);
            Debug.LogWarning("Active toolgroup: " + __instance._toolGroupManager.ActiveToolGroup);
        }
        
        public static void TestPatch(IReadOnlyList<IToolbarButton> buttons, int __result)
        {

            
            var toolbarButton = buttons.LastOrDefault((Func<IToolbarButton, bool>) (button => button.IsActive));
            var index = buttons.IndexOf(toolbarButton);

            
            
            Debug.LogWarning(index);
            foreach (var button in buttons)
            {
                Debug.Log(button.IsVisible);
            }
            Debug.LogError(buttons.Count);




                
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
            
            
            if(toolButton.Tool?.Default == true)
            {
                __instance._toolButtons.Insert(0, toolButton);
            }
            else
            {
                __instance._toolButtons.Insert(__instance._toolButtons.Count > 0 ? 1 : 0, toolButton);
            }
            if (toolButton.Tool?.ToolGroup == null)
            {
                if (toolButton.Root.Q<VisualElement>("ToolImage")?.style.backgroundImage.ToString() != "Options (UnityEngine.Sprite)")
                {
                    if (toolButton.Tool?.Default == true)
                    {
                        __instance._rootButtons.Insert(0, toolButton);
                    }
                    else
                    {
                        __instance._rootButtons.Insert(1, toolButton);
                    }
                }
            }
            return false;
        }

        public override bool ShouldApply(SceneEntrypoint? sceneEntrypoint)
        {
            return sceneEntrypoint == SceneEntrypoint.InGame;
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
}