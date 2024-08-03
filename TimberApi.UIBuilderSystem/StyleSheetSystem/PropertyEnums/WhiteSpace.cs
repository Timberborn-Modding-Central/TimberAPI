using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;

public enum WhiteSpace
{
    Normal,
    NoWrap,
}

public static class WhiteSpaceExtension
{
    private static readonly Dictionary<WhiteSpace, string> EnumValueMapper = new()
    {
        { WhiteSpace.Normal, "normal" },
        { WhiteSpace.NoWrap, "nowrap" },
    };
    
    public static string ToUnityString(this WhiteSpace alignContent)
    {
        return EnumValueMapper[alignContent];
    }
}