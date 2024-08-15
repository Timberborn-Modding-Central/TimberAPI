using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum TextOverflow
{
    Clip,
    Ellipsis,
}

public static class TextOverflowExtension
{
    private static readonly Dictionary<TextOverflow, string> EnumValueMapper = new()
    {
        { TextOverflow.Clip, "clip" },
        { TextOverflow.Ellipsis, "ellipsis" },
    };
    
    public static string ToUnityString(this TextOverflow alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}