using System.Collections.Generic;
using HarmonyLib;
using Timberborn.Common;
using Timberborn.Localization;

namespace TimberbornAPI.Localizations {
    [HarmonyPatch]
    public class Localization : ILocalization {
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

        /**
         * Inject labels into the current localization
         */
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Loc), "Initialize")]
        static bool InjectLabels(ref Dictionary<string, string> localization) {
            localization.AddRange(labelsToInject);
            return true;
        }
    }
}
