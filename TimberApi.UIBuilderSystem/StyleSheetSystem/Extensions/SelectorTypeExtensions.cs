using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions
{
    public static class SelectorTypeExtensions
    {
        private static readonly Dictionary<SelectorType, string> SelectorTypes = new()
        {
            { SelectorType.Button, "Button" },
            { SelectorType.VisualElement, "VisualElement" },
        };
        
        public static string ToUnityString(this SelectorType selectorType)
        {
            return SelectorTypes[selectorType];
        }
    }
}