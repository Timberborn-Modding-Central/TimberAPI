using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum Visibility
{
    Visible,
    Hidden,
}

public static class VisibilityExtension
{
    private static readonly Dictionary<Visibility, string> EnumValueMapper = new()
    {
        { Visibility.Visible, "visible" },
        { Visibility.Hidden, "hidden" },
    };
    
    public static string ToUnityString(this Visibility alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}