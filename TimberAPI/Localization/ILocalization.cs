using System.Collections.Generic;

namespace TimberbornAPI.Localizations
{
    public interface ILocalization
    {

        /// <summary>
        /// Add a label into the current localization
        /// For use in DisplayNameLocKey, such as in ToolGroup
        /// </summary>
        /// <param name="key">The key to reference the label with later</param>
        /// <param name="value">The localized label</param>
        /// <example>
        /// CreativeMode.ToolGroups.MapEditor : "Map editor tools" 
        /// </example>
        void AddLabel(string key, string value);

        /// <summary>
        /// Add multiple labels into the current localization
        /// </summary>
        /// <param name="labels">Multiple key:value labels to add</param>
        void AddLabels(Dictionary<string, string> labels);
    }
}
