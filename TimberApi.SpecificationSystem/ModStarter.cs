using System;
using HarmonyLib;
using TimberApi.HarmonySystem;
using TimberApi.SpecificationSystem.EarlyPrefabCollectionPatches;
using Timberborn.ModManagerScene;
using UnityEngine;

namespace TimberApi.SpecificationSystem;

internal class ModStarter : IModStarter
{
    public void StartMod()
    {
        try
        {
            var harmony = new Harmony("TimberApi.SpecificationSystem");

            harmony.Patch(
                harmony.GetMethodInfo<Timberborn.Bootstrapper.BootstrapperConfigurator>(
                    nameof(Timberborn.Bootstrapper.BootstrapperConfigurator.Configure)),
                harmony.GetHarmonyMethod<BootstrapperConfigurator>(nameof(BootstrapperConfigurator.Patch))
            );

            EarlyLoadPatcher.Patch(harmony);
        }
        catch (Exception e)
        {
            Debug.LogError("TimberApi.SpecificationSystem failed to apply patches");
            Debug.LogError(e);
        }
    }
}