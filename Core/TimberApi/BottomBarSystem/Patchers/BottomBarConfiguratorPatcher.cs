using HarmonyLib;
using TimberApi.HarmonyPatcherSystem;
using Timberborn.TutorialSystem;

namespace TimberApi.BottomBarSystem.Patchers
{
    public class BottomBarConfiguratorPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberApi.BottomBarConfigurator";

        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<Timberborn.BottomBarSystem.BottomBarSystemConfigurator>(
                    nameof(Timberborn.BottomBarSystem.BottomBarSystemConfigurator.Configure)),
                GetHarmonyMethod(nameof(ConfiguratorPatch))
            );

            harmony.Patch(
                GetMethodInfo("Timberborn.TutorialSystemInitialization.TutorialConfigurationProvider", "CreateFolktailsConfiguration"),
                GetHarmonyMethod(nameof(Test))
            );
        }

        public static bool ConfiguratorPatch()
        {
            return false;
        }

        public static bool Test(ref TutorialConfiguration __result)
        {
            __result = TutorialConfiguration.CreateEmpty();

            return false;
        }
    }
}