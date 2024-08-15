using System.Collections.Generic;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;

public static class PseudoClassSelectorExtensions
{
    private static readonly Dictionary<PseudoClass, string> PseudoClasses = new()
    {
        { PseudoClass.Hover, "hover" },
        { PseudoClass.Active, "active" },
        { PseudoClass.Inactive, "inactive" },
        { PseudoClass.Focus, "focus" },
        { PseudoClass.Selected, "selected" },
        { PseudoClass.Disabled, "disabled" },
        { PseudoClass.Enabled, "enabled" },
        { PseudoClass.Checked, "checked" }
    };

    private static string ToUnityString(this PseudoClass pseudoClass)
    {
        return PseudoClasses[pseudoClass];
    }

    private static StyleSelectorPart ToStyleSelectorPart(this PseudoClass pseudoClass)
    {
        return new StyleSelectorPart { value = pseudoClass.ToUnityString(), type = StyleSelectorType.PseudoClass };
    }

    public static IEnumerable<StyleSelectorPart> ToStyleSelectorParts(this PseudoClass[] pseudoClasses)
    {
        var parts = new StyleSelectorPart[pseudoClasses.Length];

        for (var i = 0; i < pseudoClasses.Length; i++) parts[i] = pseudoClasses[i].ToStyleSelectorPart();

        return parts;
    }
}