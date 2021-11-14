using System.Collections.Generic;

namespace TimberbornAPI.Localizations {
    public interface ILocalization {
        /**
         * Add a label into the current localization
         * 
         * Example: CreativeMode.ToolGroups.MapEditor : "Map editor tools" 
         * For use in DisplayNameLocKey, such as in ToolGroup
         */
        void AddLabel(string key, string value);

        /**
         * Add multiple labels into the current localization
         */
        void AddLabels(Dictionary<string, string> labels);
    }
}
