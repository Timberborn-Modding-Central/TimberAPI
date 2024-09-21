using TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;
using UnityEngine;
using UnityEngine.UIElements.StyleSheets;
using static UnityEngine.UIElements.StyleSheets.Dimension.Unit;
using Display = TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums.Display;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;

public static class PropertyBuilderExtension
{
    public static PropertyBuilder AlignContent(this PropertyBuilder propertyBuilder, AlignContent alignContent)
    {
        return propertyBuilder.Add(Property.AlignContent, alignContent.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder AlignItems(this PropertyBuilder propertyBuilder, AlignItems alignItems)
    {
        return propertyBuilder.Add(Property.AlignItems, alignItems.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder AlignSelf(this PropertyBuilder propertyBuilder, AlignSelf alignSelf)
    {
        return propertyBuilder.Add(Property.AlignSelf, alignSelf.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder BackgroundColor(this PropertyBuilder propertyBuilder, Color color)
    {
        return propertyBuilder.Add(Property.BackgroundColor, color);
    }
    
    public static PropertyBuilder BorderColor(this PropertyBuilder propertyBuilder, Color color)
    {
        return propertyBuilder.Add(Property.BorderColor, color);
    }
    
    public static PropertyBuilder BorderLeftColor(this PropertyBuilder propertyBuilder, Color color)
    {
        return propertyBuilder.Add(Property.BorderLeftColor, color);
    }
    
    public static PropertyBuilder BorderTopColor(this PropertyBuilder propertyBuilder, Color color)
    {
        return propertyBuilder.Add(Property.BorderTopColor, color);
    }
    
    public static PropertyBuilder BorderRightColor(this PropertyBuilder propertyBuilder, Color color)
    {
        return propertyBuilder.Add(Property.BorderRightColor, color);
    }
    
    public static PropertyBuilder BorderBottomColor(this PropertyBuilder propertyBuilder, Color color)
    {
        return propertyBuilder.Add(Property.BorderBottomColor, color);
    }
    
    public static PropertyBuilder BorderRadius(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.BorderRadius, new Dimension(value, unit));
    }
    
    public static PropertyBuilder BorderTopLeftRadius(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.BorderTopLeftRadius, new Dimension(value, unit));
    }
    
    public static PropertyBuilder BorderTopRightRadius(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.BorderTopRightRadius, new Dimension(value, unit));
    }
    
    public static PropertyBuilder BorderBottomLeftRadius(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.BorderBottomLeftRadius, new Dimension(value, unit));
    }
    
    public static PropertyBuilder BorderBottomRightRadius(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.BorderBottomRightRadius, new Dimension(value, unit));
    }
    
    public static PropertyBuilder BorderWidth(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.BorderWidth, new Dimension(value, unit));
    }
    
    public static PropertyBuilder BorderLeftWidth(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.BorderLeftWidth, new Dimension(value, unit));
    }
    
    public static PropertyBuilder BorderTopWidth(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.BorderTopWidth, new Dimension(value, unit));
    }
    
    public static PropertyBuilder BorderRightWidth(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.BorderRightWidth, new Dimension(value, unit));
    }
    
    public static PropertyBuilder BorderBottomWidth(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.BorderBottomWidth, new Dimension(value, unit));
    }
    
    public static PropertyBuilder Position(this PropertyBuilder propertyBuilder, Position position)
    {
        return propertyBuilder.Add(Property.Position, position.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder Left(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.Left, new Dimension(value, unit));
    }
    
    public static PropertyBuilder Top(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.Top, new Dimension(value, unit));
    }
    
    public static PropertyBuilder Right(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.Right, new Dimension(value, unit));
    }
    
    public static PropertyBuilder Bottom(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.Bottom, new Dimension(value, unit));
    }
    
    public static PropertyBuilder Color(this PropertyBuilder propertyBuilder, Color color)
    {
        return propertyBuilder.Add(Property.Color, color);
    }
    
    public static PropertyBuilder Cursor(this PropertyBuilder propertyBuilder, string path)
    {
        return propertyBuilder.Add(Property.Cursor, path, StyleValueType.ResourcePath);
    }
    
    public static PropertyBuilder Display(this PropertyBuilder propertyBuilder, Display display)
    {
        return propertyBuilder.Add(Property.Display, display.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder Flex(this PropertyBuilder propertyBuilder, Flex flex)
    {
        return propertyBuilder.Add(Property.Flex, flex.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder FlexBasis(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.FlexBasis, new Dimension(value, unit));
    }
    
    public static PropertyBuilder FlexDirection(this PropertyBuilder propertyBuilder, FlexDirection flexDirection)
    {
        return propertyBuilder.Add(Property.FlexDirection, flexDirection.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder FlexGrow(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.FlexGrow, value);
    }
    
    public static PropertyBuilder FlexShrink(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.FlexShrink, value);
    }
    
    public static PropertyBuilder FlexWrap(this PropertyBuilder propertyBuilder, FlexWrap flexWrap)
    {
        return propertyBuilder.Add(Property.FlexWrap, flexWrap.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder FontSize(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.FontSize, new Dimension(value, unit));
    }
    
    public static PropertyBuilder Height(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.Height, new Dimension(value, unit));
    }
    
    public static PropertyBuilder Width(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.Width, new Dimension(value, unit));
    }
    
    public static PropertyBuilder JustifyContent(this PropertyBuilder propertyBuilder, JustifyContent justifyContent)
    {
        return propertyBuilder.Add(Property.JustifyContent, justifyContent.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder LetterSpacing(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.LetterSpacing, new Dimension(value, unit));
    }
    
    public static PropertyBuilder Margin(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.Margin, new Dimension(value, unit));
    }
    
    public static PropertyBuilder MarginLeft(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.MarginLeft, new Dimension(value, unit));
    }
    
    public static PropertyBuilder MarginTop(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.MarginTop, new Dimension(value, unit));
    }
    
    public static PropertyBuilder MarginRight(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.MarginRight, new Dimension(value, unit));
    }
    
    public static PropertyBuilder MarginBottom(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.MarginBottom, new Dimension(value, unit));
    }
    
    public static PropertyBuilder MaxHeight(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.MaxHeight, new Dimension(value, unit));
    }
    
    public static PropertyBuilder MaxWidth(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.MaxWidth, new Dimension(value, unit));
    }
    
    public static PropertyBuilder MinHeight(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.MinHeight, new Dimension(value, unit));
    }
    
    public static PropertyBuilder MinWidth(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.MinWidth, new Dimension(value, unit));
    }
    
    public static PropertyBuilder Opacity(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.Opacity, value);
    }
    
    public static PropertyBuilder Overflow(this PropertyBuilder propertyBuilder, Overflow overflow)
    {
        return propertyBuilder.Add(Property.Overflow, overflow.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder Padding(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.Padding, new Dimension(value, unit));
    }
    
    public static PropertyBuilder PaddingX(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        propertyBuilder.Add(Property.PaddingLeft, new Dimension(value, unit));
        return propertyBuilder.Add(Property.PaddingRight, new Dimension(value, unit));
    }
    
    public static PropertyBuilder PaddingY(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        propertyBuilder.Add(Property.PaddingTop, new Dimension(value, unit));
        return propertyBuilder.Add(Property.PaddingBottom, new Dimension(value, unit));
    }
    
    public static PropertyBuilder PaddingLeft(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.PaddingLeft, new Dimension(value, unit));
    }
    
    public static PropertyBuilder PaddingTop(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.PaddingTop, new Dimension(value, unit));
    }
    
    public static PropertyBuilder PaddingRight(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.PaddingRight, new Dimension(value, unit));
    }
    
    public static PropertyBuilder PaddingBottom(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.PaddingBottom, new Dimension(value, unit));
    }
    
    public static PropertyBuilder Rotate(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Degree)
    {
        return propertyBuilder.Add(Property.Rotate, new Dimension(value, unit));
    }
    
    public static PropertyBuilder TextOverflow(this PropertyBuilder propertyBuilder, TextOverflow textOverflow)
    {
        return propertyBuilder.Add(Property.TextOverflow, textOverflow.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder UnityBackgroundScaleMode(this PropertyBuilder propertyBuilder, UnityBackgroundScaleMode unityBackgroundScaleMode)
    {
        return propertyBuilder.Add(Property.UnityBackgroundScaleMode, unityBackgroundScaleMode.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder UnityFont(this PropertyBuilder propertyBuilder, string path)
    {
        return propertyBuilder.Add(Property.UnityFont, path, StyleValueType.ResourcePath);
    }
    
    public static PropertyBuilder UnityFontDefinition(this PropertyBuilder propertyBuilder, string path)
    {
        return propertyBuilder.Add(Property.UnityFontDefinition, path, StyleValueType.ResourcePath);
    }
    
    public static PropertyBuilder UnityFontStyle(this PropertyBuilder propertyBuilder, UnityFontStyle unityFontStyle)
    {
        return propertyBuilder.Add(Property.UnityFontStyle, unityFontStyle.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder UnityOverflowClipBox(this PropertyBuilder propertyBuilder, UnityOverflowClipBox unityOverflowClipBox)
    {
        return propertyBuilder.Add(Property.UnityOverflowClipBox, unityOverflowClipBox.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder UnityParagraphSpacing(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.UnityParagraphSpacing, new Dimension(value, unit));
    }
    
    public static PropertyBuilder UnitySliceLeft(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.UnitySliceLeft, value);
    }
    
    public static PropertyBuilder UnitySliceTop(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.UnitySliceTop, value);
    }
    
    public static PropertyBuilder UnitySliceRight(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.UnitySliceRight, value);
    }
    
    public static PropertyBuilder UnitySliceBottom(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.UnitySliceBottom, value);
    }
    
    public static PropertyBuilder UnitySliceScale(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.UnitySliceScale, new Dimension(value, unit));
    }
    
    public static PropertyBuilder UnityTextAlign(this PropertyBuilder propertyBuilder, UnityTextAlign unityTextAlign)
    {
        return propertyBuilder.Add(Property.UnityTextAlign, unityTextAlign.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder UnityTextOverflowPosition(this PropertyBuilder propertyBuilder, UnityTextOverflowPosition unityTextOverflowPosition)
    {
        return propertyBuilder.Add(Property.UnityTextOverflowPosition, unityTextOverflowPosition.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder UnityCursorColor(this PropertyBuilder propertyBuilder, Color color)
    {
        return propertyBuilder.Add(Property.UnityCursorColor, color);
    }
    
    public static PropertyBuilder UnitySelectionColor(this PropertyBuilder propertyBuilder, Color color)
    {
        return propertyBuilder.Add(Property.UnitySelectionColor, color);
    }
    
    public static PropertyBuilder Visibility(this PropertyBuilder propertyBuilder, Visibility visibility)
    {
        return propertyBuilder.Add(Property.Visibility, visibility.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder WhiteSpace(this PropertyBuilder propertyBuilder, WhiteSpace whiteSpace)
    {
        return propertyBuilder.Add(Property.WhiteSpace, whiteSpace.ToUnityString(), StyleValueType.Enum);
    }
    
    public static PropertyBuilder WordSpacing(this PropertyBuilder propertyBuilder, float value, Dimension.Unit unit = Pixel)
    {
        return propertyBuilder.Add(Property.WordSpacing, new Dimension(value, unit));
    }

    #region Timberborn properties
    
    public static PropertyBuilder ClickSound(this PropertyBuilder propertyBuilder, string soundId)
    {
        return propertyBuilder.Add(Property.ClickSound, soundId, StyleValueType.String);
    }

    public static PropertyBuilder NineSlicedBackgroundImage(this PropertyBuilder propertyBuilder, string path, float slice, float sliceScale)
    {
        propertyBuilder.Add(Property.NineSlicedBackgroundImage, path, StyleValueType.ResourcePath);
        propertyBuilder.BackgroundSlice(slice);
        propertyBuilder.BackgroundSliceScale(sliceScale);

        return propertyBuilder;
    }

    public static PropertyBuilder NineSlicedBackgroundImage(this PropertyBuilder propertyBuilder, string path, float sliceTop, float sliceRight, float sliceBottom, float sliceLeft, float sliceScale)
    {
        propertyBuilder.Add(Property.NineSlicedBackgroundImage, path, StyleValueType.ResourcePath);
        propertyBuilder.BackgroundSliceTop(sliceTop);
        propertyBuilder.BackgroundSliceRight(sliceRight);
        propertyBuilder.BackgroundSliceBottom(sliceBottom);
        propertyBuilder.BackgroundSliceLeft(sliceLeft);
        propertyBuilder.BackgroundSliceScale(sliceScale);

        return propertyBuilder;
    }

    public static PropertyBuilder BackgroundImage(this PropertyBuilder propertyBuilder, string path)
    {
        return propertyBuilder.Add(Property.BackgroundImage, path, StyleValueType.ResourcePath);
    }

    public static PropertyBuilder BackgroundImage(this PropertyBuilder propertyBuilder, Object path)
    {
        return propertyBuilder.Add(Property.BackgroundImage, path);
    }
    
    public static PropertyBuilder BackgroundSliceScale(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.BackgroundSliceScale, value);
    }
    
    public static PropertyBuilder BackgroundSlice(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.BackgroundSlice, value);
    }
    
    public static PropertyBuilder BackgroundSliceLeft(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.BackgroundSliceLeft, value);
    }
    
    public static PropertyBuilder BackgroundSliceTop(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.BackgroundSliceTop, value);
    }
    
    public static PropertyBuilder BackgroundSliceRight(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.BackgroundSliceRight, value);
    }
    
    public static PropertyBuilder BackgroundSliceBottom(this PropertyBuilder propertyBuilder, float value)
    {
        return propertyBuilder.Add(Property.BackgroundSliceBottom, value);
    }

    #endregion
}