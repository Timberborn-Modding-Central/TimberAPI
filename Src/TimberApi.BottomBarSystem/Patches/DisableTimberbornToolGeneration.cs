using HarmonyLib;
using TimberApi.HarmonySystem;

namespace TimberApi.BottomBarSystem.Patches;

public class DisableTimberbornToolGeneration
{
    public static void Patch(Harmony harmony)
    {
            // harmony.Patch(
            //     harmony.GetMethodInfo<Timberborn.BottomBarSystem.BottomBarSystemConfigurator>(
            //         nameof(Timberborn.BottomBarSystem.BottomBarSystemConfigurator.Configure)),
            //     harmony.GetHarmonyMethod<BottomBarConfiguratorPatcher>(nameof(DisableBottomBarSystemConfigurator))
            // );
    }
}