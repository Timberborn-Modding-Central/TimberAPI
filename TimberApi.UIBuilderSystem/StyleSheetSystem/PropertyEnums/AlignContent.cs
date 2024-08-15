using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum AlignContent
{
    FlexStart,
    FlexEnd,
    Center,
    Stretch,
}

public static class AlignContentExtension
{
    private static readonly Dictionary<AlignContent, string> EnumValueMapper = new()
    {
        { AlignContent.FlexStart, "flex-start" },
        { AlignContent.FlexEnd, "flex-end" },
        { AlignContent.Center, "center" },
        { AlignContent.Stretch, "stretch" },
    };
    
    public static string ToUnityString(this AlignContent alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}