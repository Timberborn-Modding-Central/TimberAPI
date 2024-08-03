using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum UnityTextAlign
{
    UpperLeft,
    MiddleLeft,
    LowerLeft,
    UpperCenter,
    MiddleCenter,
    LowerCenter,
    UpperRight,
    MiddleRight,
    LowerRight
}

public static class UnityTextAlignExtension
{
    private static readonly Dictionary<UnityTextAlign, string> EnumValueMapper = new()
    {
        { UnityTextAlign.UpperLeft, "upper-left" },
        { UnityTextAlign.MiddleLeft, "middle-left" },
        { UnityTextAlign.LowerLeft, "lower-left" },
        { UnityTextAlign.UpperCenter, "upper-center" },
        { UnityTextAlign.MiddleCenter, "middle-center" },
        { UnityTextAlign.LowerCenter, "lower-center" },
        { UnityTextAlign.UpperRight, "upper-right" },
        { UnityTextAlign.MiddleRight, "middle-right" },
        { UnityTextAlign.LowerRight, "lower-right" },
    };

    public static string ToUnityString(this UnityTextAlign alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}