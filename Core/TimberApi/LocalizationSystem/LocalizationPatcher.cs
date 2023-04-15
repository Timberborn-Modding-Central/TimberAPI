using System;
using System.Collections.Generic;
using HarmonyLib;
using TimberApi.HarmonyPatcherSystem;
using Timberborn.Common;
using UnityEngine;

namespace TimberApi.LocalizationSystem
{
    public class LocalizationPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberApi.Localization";

        public override void Apply(Harmony harmony)
        {
            // harmony.Patch(
            //     GetMethodInfo("Timberborn.Localization.LocalizationRepository", "GetLocalization"),
            //     postfix: GetHarmonyMethod(nameof(GetLocalizationPatch))
            // );
        }

        public static void GetLocalizationPatch(string localizationKey, ref IDictionary<string, string> __result)
        {
            IDictionary<string, string> localization = LocalizationFetcher.GetLocalization(localizationKey);
            try
            {
                __result.AddRange(localization);
                TimberApi.ConsoleWriter.Log($"Loaded {localization.Count} custom labels");
            }
            catch (Exception e)
            {
                TimberApi.ConsoleWriter.Log(e.ToString(), LogType.Error);
                throw;
            }
        }
    }
}