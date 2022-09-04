using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using TimberApi.Internal;
using Timberborn.Common;
using UnityEngine;

namespace TimberApi.Internal.LocalizationSystem
{
    [HarmonyPatch]
    public class LocalizationPatcher
    {

        [HarmonyPatch]
        public static class LocalizationPatch
        {
            /// <summary>
            /// Set the target method using reflection
            /// </summary>
            /// <returns></returns>
            private static MethodInfo TargetMethod()
            {
                return AccessTools.TypeByName("Timberborn.Localization.LocalizationRepository").GetMethod("GetLocalization");
            }

            /// <summary>
            /// Adds custom localization
            /// Code localization, applies to all languages
            /// File localization, overwrites code localization, has any localization
            /// Missing file localization, defaults back to enUS, overwrites code localization
            /// </summary>
            private static void Postfix(string localizationKey, ref IDictionary<string, string> __result)
            {
                IDictionary<string, string> localization = LocalizationFetcher.GetLocalization(localizationKey);
                try
                {
                    __result.AddRange(localization);
                    TimberApiInternal.ConsoleWriter.Log($"Loaded {localization.Count} custom labels");
                }
                catch (Exception e)
                {
                    TimberApiInternal.ConsoleWriter.Log(e.ToString(), LogType.Error);
                    throw;
                }
            }
        }
    }
}
