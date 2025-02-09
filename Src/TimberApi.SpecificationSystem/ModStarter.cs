using System;
using HarmonyLib;
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

            EarlyLoadPatcher.Patch(harmony);
        }
        catch (Exception e)
        {
            Debug.LogError("TimberApi.SpecificationSystem failed to apply patches");
            Debug.LogError(e);
        }
    }
}