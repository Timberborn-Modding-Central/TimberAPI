using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Timberborn.Common;

namespace TimberbornAPI.Localizations {
    [HarmonyPatch]
    public class Localization : ILocalization
    {
        private static Dictionary<string, string> labelsToInject = new();
        
        /**
         * Add a label into the current localization
         * 
         * Example: CreativeMode.ToolGroups.MapEditor : "Map editor tools" 
         * For use in DisplayNameLocKey, such as in ToolGroup
         */
        public void AddLabel(string key, string value) {
            labelsToInject.Add(key, value);
        }

        /**
         * Add multiple labels into the current localization
         */
        public void AddLabels(Dictionary<string, string> labels) {
            labelsToInject.AddRange(labels);
        }
        
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
            private static void Postfix(string localizationKey, IDictionary<string, string> __result)
            {
                IDictionary<string, string> localization = new Dictionary<string, string>();
                IDictionary<string, string> fileLocalization = LocalizationRepository.GetLocalization(localizationKey);
                foreach ((string locKey, string locValue) in labelsToInject)
                {
                    localization.Add(locKey, fileLocalization.ContainsKey(locKey) ? fileLocalization[locKey] : locValue);
                }

                try
                {
                    __result.AddRange(localization);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
