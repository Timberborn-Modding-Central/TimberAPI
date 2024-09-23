using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum Display
{
    Flex,
    None,
}

public static class DisplayExtension
{
    private static readonly Dictionary<Display, string> EnumValueMapper = new()
    {
        { Display.Flex, "flex" },
        { Display.None, "none" },
    };
    
    public static string ToUnityString(this Display alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}