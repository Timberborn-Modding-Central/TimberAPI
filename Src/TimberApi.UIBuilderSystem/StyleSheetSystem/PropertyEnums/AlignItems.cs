using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum AlignItems
{
    Auto,
    FlexStart,
    FlexEnd,
    Center,
    Stretch,
}

public static class AlignItemsExtension
{
    private static readonly Dictionary<AlignItems, string> EnumValueMapper = new()
    {
        { AlignItems.Auto, "auto" },
        { AlignItems.FlexStart, "flex-start" },
        { AlignItems.FlexEnd, "flex-end" },
        { AlignItems.Center, "center" },
        { AlignItems.Stretch, "stretch" },
    };
    
    public static string ToUnityString(this AlignItems alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}