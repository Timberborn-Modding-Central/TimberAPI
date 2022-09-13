using System;
using System.Collections.Generic;
using HarmonyLib;
using TimberApi.Common.SingletonSystem.Singletons;
using Timberborn.Common;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace TimberApi.New.LocalizationSystem
{
    internal class LocalizationPatcher : ITimberApiLoadableSingleton
    {
        public void Load()
        {
            var harmony = new Harmony("TimberApi.Localization");

            harmony.Patch(AccessTools.TypeByName("Timberborn.Localization.LocalizationRepository").GetMethod("GetLocalization"),
                postfix: new HarmonyMethod(AccessTools.Method(typeof(LocalizationPatcher), nameof(GetLocalizationPatch))));
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