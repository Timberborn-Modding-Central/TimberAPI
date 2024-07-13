using System;
using HarmonyLib;
using TimberApi.HarmonySystem;
using Timberborn.TutorialSystem;
using Timberborn.TutorialSystemInitialization;
using UnityEngine;

namespace TimberApi.BottomBarSystem.Patches;

public class BottomBarConfiguratorPatcher
{
    public static void Patch(Harmony harmony)
    {
        try
        {
            harmony.Patch(
                harmony.GetMethodInfo<Timberborn.BottomBarSystem.BottomBarSystemConfigurator>(nameof(Timberborn.BottomBarSystem.BottomBarSystemConfigurator.Configure)),
                harmony.GetHarmonyMethod<BottomBarConfiguratorPatcher>(nameof(DisableBottomBarSystemConfigurator))
            );
            
            harmony.Patch(
                harmony.GetMethodInfo<TutorialConfigurationProvider>(nameof(TutorialConfigurationProvider.CreateFolktailsConfiguration)),
                harmony.GetHarmonyMethod<BottomBarConfiguratorPatcher>(nameof(CreateFolktailsConfigurationPatch))
            );
        }
        catch (Exception e)
        {
            Debug.LogError("TimberApi.BottomBar failed to apply patches");
            Debug.LogError($"TimberApi.BottomBar {e}");
        }
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