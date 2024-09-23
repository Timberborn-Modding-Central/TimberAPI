using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum FlexWrap
{
    NoWrap,
    Wrap,
    WrapReverse,
}

public static class FlexWrapExtension
{
    private static readonly Dictionary<FlexWrap, string> EnumValueMapper = new()
    {
        { FlexWrap.NoWrap, "nowrap" },
        { FlexWrap.Wrap, "wrap" },
        { FlexWrap.WrapReverse, "wrap-reverse" },
    };
    
    public static string ToUnityString(this FlexWrap alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}