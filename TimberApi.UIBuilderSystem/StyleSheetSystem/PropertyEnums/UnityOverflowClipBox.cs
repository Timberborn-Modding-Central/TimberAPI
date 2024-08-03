using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum UnityOverflowClipBox
{
    PaddedBox,
    ContentBox,
}

public static class UnityOverflowClipBoxExtension
{
    private static readonly Dictionary<UnityOverflowClipBox, string> EnumValueMapper = new()
    {
        { UnityOverflowClipBox.PaddedBox, "padded-box" },
        { UnityOverflowClipBox.ContentBox, "content-box" },
    };
    
    public static string ToUnityString(this UnityOverflowClipBox alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}