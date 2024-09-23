using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum AlignSelf
{
    Auto,
    FlexStart,
    FlexEnd,
    Center,
    Stretch
}

public static class AlignSelfExtension
{
    private static readonly Dictionary<AlignSelf, string> EnumValueMapper = new()
    {
        { AlignSelf.Auto, "auto" },
        { AlignSelf.FlexStart, "flex-start" },
        { AlignSelf.FlexEnd, "flex-end" },
        { AlignSelf.Center, "center" },
        { AlignSelf.Stretch, "stretch" },
    };
    
    public static string ToUnityString(this AlignSelf alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}