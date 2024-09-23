using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum UnityFontStyle
{
    Normal,
    Italic,
    Bold,
    BoldAndItalic,
}

public static class UnityFontStyleExtension
{
    private static readonly Dictionary<UnityFontStyle, string> EnumValueMapper = new()
    {
        { UnityFontStyle.Normal, "normal" },
        { UnityFontStyle.Italic, "italic" },
        { UnityFontStyle.Bold, "bold" },
        { UnityFontStyle.BoldAndItalic, "bold-and-italic" },
    };
    
    public static string ToUnityString(this UnityFontStyle alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}