using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum Flex
{
    None,
    Grow,
    Shrink,
    Basis,
}

public static class FlexExtension
{
    private static readonly Dictionary<Flex, string> EnumValueMapper = new()
    {
        { Flex.None, "none" },
        { Flex.Grow, "grow" },
        { Flex.Shrink, "shrink" },
        { Flex.Basis, "basis" },
    };
    
    public static string ToUnityString(this Flex alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}