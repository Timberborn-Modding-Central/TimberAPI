using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum Position
{
    Absolute,
    Relative
}

public static class PositionExtension
{
    private static readonly Dictionary<Position, string> EnumValueMapper = new()
    {
        { Position.Absolute, "absolute" },
        { Position.Relative, "relative" },
    };
    
    public static string ToUnityString(this Position alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}