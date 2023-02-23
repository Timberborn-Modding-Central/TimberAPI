using HarmonyLib;
using TimberApi.HarmonyPatcherSystem;

namespace TimberApi.BottomBarSystem.Patchers
{
    public class BottomBarConfiguratorPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberApi.BottomBarConfigurator";

        public override void Apply(Harmony harmony)
        {
            // harmony.Patch(
            //     GetMethodInfo<Timberborn.BottomBarSystem.BottomBarSystemConfigurator>(
            //         nameof(Timberborn.BottomBarSystem.BottomBarSystemConfigurator.Configure)),
            //     GetHarmonyMethod(nameof(ConfiguratorPatch))
            // );
        }

        public static bool ConfiguratorPatch()
        {
            return false;
        }
    }
}