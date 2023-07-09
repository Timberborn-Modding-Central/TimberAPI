using HarmonyLib;
using TimberApi.HarmonyPatcherSystem;
using Timberborn.Workshops;
using UnityEngine;

namespace TimberApi.SpecificationSystem
{
    public class Patch : BaseHarmonyPatcher
    {
        public override string UniqueId => "Test.Test";
        
        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<ManufactoryInventoryInitializer>(nameof(ManufactoryInventoryInitializer.Initialize)),
                GetHarmonyMethod(nameof(Test))
            );
        }
        
        public static void Test()
        {
            Debug.LogWarning("HELP ME!!!!!!");
        }
    }
}