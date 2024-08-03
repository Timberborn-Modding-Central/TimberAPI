using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum UnityTextOverflowPosition
{
    Start,
    Middle,
    End,
}

public static class UnityTextOverflowPositionExtension
{
    private static readonly Dictionary<UnityTextOverflowPosition, string> EnumValueMapper = new()
    {
        { UnityTextOverflowPosition.Start, "start" },
        { UnityTextOverflowPosition.Middle, "middle" },
        { UnityTextOverflowPosition.End, "end" },
    };
    
    public static string ToUnityString(this UnityTextOverflowPosition alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}