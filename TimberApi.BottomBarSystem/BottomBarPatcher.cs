using System;
using HarmonyLib;
using TimberApi.HarmonySystem;
using Timberborn.BottomBarSystem;
using Timberborn.ModManagerScene;
using UnityEngine;

namespace TimberApi.BottomBarSystem;

public class BottomBarPatcher : IModStarter
{
    public void StartMod()
    {
        // try
        // {
        //     var harmony = new Harmony("TimberApi.BottomBar");
        //
        //     harmony.Patch(
        //         harmony.GetMethodInfo<BottomBarSystemConfigurator>(nameof(BottomBarSystemConfigurator.Configure)),
        //         harmony.GetHarmonyMethod<BottomBarPatcher>(nameof(DisableBottomBarSystemConfigurator))
        //     );
        // }
        // catch (Exception e)
        // {
        //     Debug.LogError("TimberApi.BottomBar failed to apply patches");
        //     Debug.LogError($"TimberApi.BottomBar {e}");
        // }
    }

    public static bool DisableBottomBarSystemConfigurator()
    {
        return false;
    }
}