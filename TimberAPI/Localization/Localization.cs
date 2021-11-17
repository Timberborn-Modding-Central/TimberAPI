using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Timberborn.Common;

namespace TimberbornAPI.LocalizationSystem
{
    [HarmonyPatch]
    public class Localization : ILocalization
    {
        private static Dictionary<string, string> labelsToInject = new();

        /// <summary>
        /// Add a label into the current localization
        /// For use in DisplayNameLocKey, such as in ToolGroup
        /// </summary>
        /// <param name="key">The key to reference the label with later</param>
        /// <param name="value">The localized label</param>
        public void AddLabel(string key, string value)
        {
            labelsToInject.Add(key, value);
        }

        /// <summary>
        /// Add multiple labels into the current localization
        /// </summary>
        /// <param name="labels">Multiple key:value labels to add</param>
        public void AddLabels(Dictionary<string, string> labels)
        {
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
            private static void Postfix(string localizationKey, ref IDictionary<string, string> __result)
            {
                IDictionary<string, string> localization = new Dictionary<string, string>(labelsToInject);
                IDictionary<string, string> fileLocalization = LocalizationRepository.GetLocalization(localizationKey);

                foreach ((string locKey, string locValue) in fileLocalization)
                {
                    if (localization.ContainsKey(locKey))
                    {
                        localization[locKey] = locValue;
                    }
                    else
                    {
                        localization.Add(locKey, locValue);
                    }
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
