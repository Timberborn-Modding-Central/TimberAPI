using HarmonyLib;
using TimberApi.Common.SingletonSystem;
using TimberApi.DependencyContainerSystem;
using TimberApi.HarmonyPatcherSystem;
using TimberApi.ToolGroupSystem;
using Timberborn.CoreUI;
using Timberborn.ToolSystem;
using UnityEngine.UIElements;

namespace TimberApi.BottomBarSystem
{
    public class ToolGroupButtonPatcher : BaseHarmonyPatcher, ITimberApiLoadableSingleton
    {
        private static BottomBarService _bottomBarService = null!;

        private static readonly string ActiveClassName = "button--active";

        public void Load()
        {
            _bottomBarService = DependencyContainer.GetInstance<BottomBarService>();
        }

        public override string UniqueId => "TimberApi.ToolGroupButton";

        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<ToolGroupButton>("ContainsTool"),
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
        }

        public static bool ContainsToolPatch(ref bool __result, ToolGroupButton __instance)
        {
            __result = true;

            return false;
        }

        public static bool OnToolGroupEntered(ToolGroupEnteredEvent toolGroupEnteredEvent, ToolGroupButton __instance, ToolGroup ____toolGroup, VisualElement ____toolGroupButtonWrapper)
        {
            if (toolGroupEnteredEvent.ToolGroup is not BottomBarToolGroup enteredToolGroup || ____toolGroup is not BottomBarToolGroup toolGroup)
            {
                return false;
            }

            var row = _bottomBarService.GetRowNumber(toolGroup.Id);
            var enteredRow = _bottomBarService.GetRowNumber(enteredToolGroup.Id);

            if (row >= enteredRow && toolGroupEnteredEvent.ToolGroup != ____toolGroup)
            {
                __instance.ToolButtonsElement.ToggleDisplayStyle(false);
                ____toolGroupButtonWrapper.RemoveFromClassList(ActiveClassName);
            }

            if (toolGroupEnteredEvent.ToolGroup != ____toolGroup)
                return false;

            __instance.ToolButtonsElement.ToggleDisplayStyle(true);
            ____toolGroupButtonWrapper.AddToClassList(ActiveClassName);

            return false;
        }

        public static bool OnToolGroupExited(ToolGroupExitedEvent toolGroupExitedEvent, ToolGroupButton __instance, VisualElement ____toolGroupButtonWrapper)
        {
            if (toolGroupExitedEvent.ToolGroup is not ExitingTool)
            {
                return false;
            }

            __instance.ToolButtonsElement.ToggleDisplayStyle(false);
            ____toolGroupButtonWrapper.RemoveFromClassList(ActiveClassName);

            return false;
        }
    }
}