using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum Overflow
{
    Hidden,
    Visible,
}

public static class OverflowExtension
{
    private static readonly Dictionary<Overflow, string> EnumValueMapper = new()
    {
        { Overflow.Hidden, "hidden" },
        { Overflow.Visible, "visible" },
    };
    
    public static string ToUnityString(this Overflow alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}