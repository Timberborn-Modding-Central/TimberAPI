using System;
using HarmonyLib;
using TimberApi.HarmonySystem;
using TimberApi.SingletonSystem;
using Timberborn.ModManagerScene;
using Timberborn.SingletonSystem;
using UnityEngine;

namespace TimberApi;

public class ModStarter : IModStarter
{
    public void StartMod()
    {
        try
        {
            var harmony = new Harmony("TimberApi");

            SceneManager.Patch(harmony);

            harmony.Patch(
                harmony.GetMethodInfo<SingletonLifecycleService>(nameof(SingletonLifecycleService.LoadAll)),
                harmony.GetHarmonyMethod<SingletonLifecycleServicePatcher>(nameof(SingletonLifecycleServicePatcher
                    .LoadAllPrefix))
            );

            harmony.Patch(
                harmony.GetMethodInfo<SingletonLifecycleService>(nameof(SingletonLifecycleService.LoadSingletons)),
                harmony.GetHarmonyMethod<SingletonLifecycleServicePatcher>(nameof(SingletonLifecycleServicePatcher
                    .LoadSingletonsPrefix)),
                harmony.GetHarmonyMethod<SingletonLifecycleServicePatcher>(nameof(SingletonLifecycleServicePatcher
                    .LoadSingletonsPostfix))
            );
        }
        catch (Exception e)
        {
            Debug.LogError("TimberApi failed to apply patches");
            Debug.LogError($"TimberApi {e}");
        }
    }
}