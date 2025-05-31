using HarmonyLib;
using TimberApi.HarmonySystem;
using Timberborn.BottomBarSystem;
using Timberborn.TutorialSystem;
using Timberborn.TutorialSystemInitialization;

namespace TimberApi.BottomBarSystem.Patches;

public class BottomBarConfiguratorPatcher
{
    public static void Patch(Harmony harmony)
    {
        harmony.Patch(
            harmony.GetMethodInfo<BottomBarSystemConfigurator>(nameof(BottomBarSystemConfigurator.Configure)),
            harmony.GetHarmonyMethod<BottomBarConfiguratorPatcher>(nameof(DisableBottomBarSystemConfigurator))
        );
        
        harmony.Patch(
            harmony.GetMethodInfo<TutorialConfigurationProvider>(nameof(TutorialConfigurationProvider.CreateStartingFactionConfiguration)),
            harmony.GetHarmonyMethod<BottomBarConfiguratorPatcher>(nameof(CreateFolktailsConfigurationPatch))
        );
        
        harmony.Patch(
            harmony.GetMethodInfo<TutorialConfigurationProvider>(nameof(TutorialConfigurationProvider.CreateStartingFactionConfiguration)),
            harmony.GetHarmonyMethod<BottomBarConfiguratorPatcher>(nameof(CreateFolktailsConfigurationPatch))
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