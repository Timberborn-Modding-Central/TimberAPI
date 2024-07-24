using System.Collections.Generic;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;

public static class PropertyExtensions
{
    private static readonly Dictionary<Property, string> Properties = new()
    {
        // Default Unity properties
        { Property.AlignContent, "align-content" },
        { Property.AlignItems, "align-items" },
        { Property.AlignSelf, "align-self" },
        { Property.All, "all" },
        { Property.BackgroundColor, "background-color" },
        { Property.BackgroundImage, "background-image" },
        { Property.BackgroundPosition, "background-position" },
        { Property.BackgroundPositionX, "background-position-x" },
        { Property.BackgroundPositionY, "background-position-y" },
        { Property.BackgroundRepeat, "background-repeat" },
        { Property.BackgroundSize, "background-size" },
        { Property.BorderBottomColor, "border-bottom-color" },
        { Property.BorderBottomLeftRadius, "border-bottom-left-radius" },
        { Property.BorderBottomRightRadius, "border-bottom-right-radius" },
        { Property.BorderBottomWidth, "border-bottom-width" },
        { Property.BorderColor, "border-color" },
        { Property.BorderLeftColor, "border-left-color" },
        { Property.BorderLeftWidth, "border-left-width" },
        { Property.BorderRadius, "border-radius" },
        { Property.BorderRightColor, "border-right-color" },
        { Property.BorderRightWidth, "border-right-width" },
        { Property.BorderTopColor, "border-top-color" },
        { Property.BorderTopLeftRadius, "border-top-left-radius" },
        { Property.BorderTopRightRadius, "border-top-right-radius" },
        { Property.BorderTopWidth, "border-top-width" },
        { Property.BorderWidth, "border-width" },
        { Property.Bottom, "bottom" },
        { Property.Color, "color" },
        { Property.Cursor, "cursor" },
        { Property.Display, "display" },
        { Property.Flex, "flex" },
        { Property.FlexBasis, "flex-basis" },
        { Property.FlexDirection, "flex-direction" },
        { Property.FlexGrow, "flex-grow" },
        { Property.FlexShrink, "flex-shrink" },
        { Property.FlexWrap, "flex-wrap" },
        { Property.FontSize, "font-size" },
        { Property.Height, "height" },
        { Property.JustifyContent, "justify-content" },
        { Property.Left, "left" },
        { Property.LetterSpacing, "letter-spacing" },
        { Property.Margin, "margin" },
        { Property.MarginBottom, "margin-bottom" },
        { Property.MarginLeft, "margin-left" },
        { Property.MarginRight, "margin-right" },
        { Property.MarginTop, "margin-top" },
        { Property.MaxHeight, "max-height" },
        { Property.MaxWidth, "max-width" },
        { Property.MinHeight, "min-height" },
        { Property.MinWidth, "min-width" },
        { Property.Opacity, "opacity" },
        { Property.Overflow, "overflow" },
        { Property.Padding, "padding" },
        { Property.PaddingBottom, "padding-bottom" },
        { Property.PaddingLeft, "padding-left" },
        { Property.PaddingRight, "padding-right" },
        { Property.PaddingTop, "padding-top" },
        { Property.Position, "position" },
        { Property.Right, "right" },
        { Property.Rotate, "rotate" },
        { Property.Scale, "scale" },
        { Property.TextOverflow, "text-overflow" },
        { Property.TextShadow, "text-shadow" },
        { Property.Top, "top" },
        { Property.TransformOrigin, "transform-origin" },
        { Property.Transition, "transition" },
        { Property.TransitionDelay, "transition-delay" },
        { Property.TransitionDuration, "transition-duration" },
        { Property.TransitionProperty, "transition-property" },
        { Property.TransitionTimingFunction, "transition-timing-function" },
        { Property.Translate, "translate" },
        { Property.UnityBackgroundImageTintColor, "-unity-background-image-tint-color" },
        { Property.UnityBackgroundScaleMode, "-unity-background-scale-mode" },
        { Property.UnityFont, "-unity-font" },
        { Property.UnityFontDefinition, "-unity-font-definition" },
        { Property.UnityFontStyle, "-unity-font-style" },
        { Property.UnityOverflowClipBox, "-unity-overflow-clip-box" },
        { Property.UnityParagraphSpacing, "-unity-paragraph-spacing" },
        { Property.UnitySliceBottom, "-unity-slice-bottom" },
        { Property.UnitySliceLeft, "-unity-slice-left" },
        { Property.UnitySliceRight, "-unity-slice-right" },
        { Property.UnitySliceScale, "-unity-slice-scale" },
        { Property.UnitySliceTop, "-unity-slice-top" },
        { Property.UnityTextAlign, "-unity-text-align" },
        { Property.UnityTextOutline, "-unity-text-outline" },
        { Property.UnityTextOutlineColor, "-unity-text-outline-color" },
        { Property.UnityTextOutlineWidth, "-unity-text-outline-width" },
        { Property.UnityTextOverflowPosition, "-unity-text-overflow-position" },
        { Property.Visibility, "visibility" },
        { Property.WhiteSpace, "white-space" },
        { Property.Width, "width" },
        { Property.WordSpacing, "word-spacing" },

        // Timberborn properties
        { Property.ClickSound, "--click-sound" },
        { Property.NineSlicedBackgroundImage, "--background-image" },
        { Property.BackgroundSliceScale, "--background-slice-scale" },
        { Property.BackgroundSlice, "--background-slice" },
        { Property.BackgroundSliceTop, "--background-slice-top" },
        { Property.BackgroundSliceRight, "--background-slice-right" },
        { Property.BackgroundSliceBottom, "--background-slice-bottom" },
        { Property.BackgroundSliceLeft, "--background-slice-left" }
    };

    public static string ToUnityString(this Property property)
    {
        return Properties[property];
    }
}