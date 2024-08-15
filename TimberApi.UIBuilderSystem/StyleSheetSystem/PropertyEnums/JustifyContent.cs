using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum JustifyContent
{
    FlexStart,
    FlexEnd,
    Center,
    SpaceBetween,
    SpaceAround,
}

public static class JustifyContentExtension
{
    private static readonly Dictionary<JustifyContent, string> EnumValueMapper = new()
    {
        { JustifyContent.FlexStart, "flex-start" },
        { JustifyContent.FlexEnd, "flex-end" },
        { JustifyContent.Center, "center" },
        { JustifyContent.SpaceBetween, "space-between" },
        { JustifyContent.SpaceAround, "space-around" },
    };
    
    public static string ToUnityString(this JustifyContent alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}