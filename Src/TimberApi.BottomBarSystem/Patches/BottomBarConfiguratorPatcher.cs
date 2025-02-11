using HarmonyLib;
using TimberApi.HarmonySystem;
using Timberborn.BottomBarSystem;
using Timberborn.TutorialSystem;

namespace TimberApi.BottomBarSystem.Patches;

public class BottomBarConfiguratorPatcher
{
    public static void Patch(Harmony harmony)
    {
        harmony.Patch(
            harmony.GetMethodInfo<BottomBarSystemConfigurator>(nameof(BottomBarSystemConfigurator.Configure)),
            harmony.GetHarmonyMethod<BottomBarConfiguratorPatcher>(nameof(DisableBottomBarSystemConfigurator))
        );
    }

    public static bool DisableBottomBarSystemConfigurator()
    {
        return false;
    }

    public static bool CreateFolktailsConfigurationPatch(ref TutorialConfiguration __result)
    {
        __result = TutorialConfiguration.CreateEmpty();

        return false;
    }
}