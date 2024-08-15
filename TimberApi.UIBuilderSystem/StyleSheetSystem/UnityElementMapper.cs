using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem;

public static class UnityElementMapper
{
    public static readonly Dictionary<StyleValueType, UnityEngine.UIElements.StyleValueType> UnityStyleValueType = new() {
        { StyleValueType.Invalid, UnityEngine.UIElements.StyleValueType.Invalid },
        { StyleValueType.Keyword, UnityEngine.UIElements.StyleValueType.Keyword },
        { StyleValueType.Float, UnityEngine.UIElements.StyleValueType.Float },
        { StyleValueType.Dimension, UnityEngine.UIElements.StyleValueType.Dimension },
        { StyleValueType.Color, UnityEngine.UIElements.StyleValueType.Color },
        { StyleValueType.ResourcePath, UnityEngine.UIElements.StyleValueType.ResourcePath },
        { StyleValueType.AssetReference, UnityEngine.UIElements.StyleValueType.AssetReference },
        { StyleValueType.Enum, UnityEngine.UIElements.StyleValueType.Enum },
        { StyleValueType.Variable, UnityEngine.UIElements.StyleValueType.Variable },
        { StyleValueType.String, UnityEngine.UIElements.StyleValueType.String },
        { StyleValueType.Function, UnityEngine.UIElements.StyleValueType.Function },
        { StyleValueType.CommaSeparator, UnityEngine.UIElements.StyleValueType.CommaSeparator },
        { StyleValueType.ScalableImage, UnityEngine.UIElements.StyleValueType.ScalableImage },
    };
    
    public static readonly Dictionary<StyleValueKeyword, UnityEngine.UIElements.StyleValueKeyword> UnityStyleValueKeyword = new() {
        { StyleValueKeyword.Inherit, UnityEngine.UIElements.StyleValueKeyword.Inherit },
        { StyleValueKeyword.Initial, UnityEngine.UIElements.StyleValueKeyword.Initial },
        { StyleValueKeyword.Auto, UnityEngine.UIElements.StyleValueKeyword.Auto },
        { StyleValueKeyword.Unset, UnityEngine.UIElements.StyleValueKeyword.Unset },
        { StyleValueKeyword.True, UnityEngine.UIElements.StyleValueKeyword.True },
        { StyleValueKeyword.False, UnityEngine.UIElements.StyleValueKeyword.False },
        { StyleValueKeyword.None, UnityEngine.UIElements.StyleValueKeyword.None },
    };
    
    public static readonly Dictionary<StyleValueFunction, UnityEngine.UIElements.StyleValueFunction> UnityStyleValueFunction = new() {
        { StyleValueFunction.Unknown, UnityEngine.UIElements.StyleValueFunction.Unknown },
        { StyleValueFunction.Var, UnityEngine.UIElements.StyleValueFunction.Var },
        { StyleValueFunction.Env, UnityEngine.UIElements.StyleValueFunction.Env },
        { StyleValueFunction.LinearGradient, UnityEngine.UIElements.StyleValueFunction.LinearGradient },
    };
}