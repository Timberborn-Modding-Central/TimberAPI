using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum UnityBackgroundScaleMode
{
    StretchToFill,
    ScaleAndCrop,
    ScaleToFit,
}

public static class UnityBackgroundScaleModeExtension
{
    private static readonly Dictionary<UnityBackgroundScaleMode, string> EnumValueMapper = new()
    {
        { UnityBackgroundScaleMode.StretchToFill, "stretch-to-fill" },
        { UnityBackgroundScaleMode.ScaleAndCrop, "scale-and-crop" },
        { UnityBackgroundScaleMode.ScaleToFit, "scale-to-fit" },
    };
    
    public static string ToUnityString(this UnityBackgroundScaleMode alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}