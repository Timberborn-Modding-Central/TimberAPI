using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using Timberborn.AssetSystem;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem;

public class PropertyBuilder
{
    private readonly IAssetLoader _assetLoader;
    private readonly UnityEngine.UIElements.StyleSheets.StyleSheetBuilder _builder;

    public PropertyBuilder(UnityEngine.UIElements.StyleSheets.StyleSheetBuilder builder, IAssetLoader assetLoader)
    {
        _builder = builder;
        _assetLoader = assetLoader;
    }

    public PropertyBuilder AddNineSlicedBackgroundImage(string path, float slice, float sliceScale)
    {
        Add(Property.NineSlicedBackgroundImage, path, StyleValueType.ResourcePath);
        Add(Property.BackgroundSlice, slice);
        Add(Property.BackgroundSliceScale, sliceScale);

        return this;
    }

    public PropertyBuilder AddNineSlicedBackgroundImage(string path, float sliceTop, float sliceRight,
        float sliceBottom, float sliceLeft, float sliceScale)
    {
        Add(Property.NineSlicedBackgroundImage, _assetLoader.Load<Sprite>(path));
        Add(Property.BackgroundSliceTop, sliceTop);
        Add(Property.BackgroundSliceRight, sliceRight);
        Add(Property.BackgroundSliceBottom, sliceBottom);
        Add(Property.BackgroundSliceLeft, sliceLeft);
        Add(Property.BackgroundSliceScale, sliceScale);

        return this;
    }

    public PropertyBuilder AddBackgroundImage(string path)
    {
        Add(Property.BackgroundImage, _assetLoader.Load<Sprite>(path));
        return this;
    }

    public PropertyBuilder AddBackgroundImage(Object path)
    {
        Add(Property.BackgroundImage, path);
        return this;
    }

    public PropertyBuilder Add(Property property, float value)
    {
        _builder.BeginProperty(property.ToUnityString(), 0);

        _builder.AddValue(value);

        _builder.EndProperty();

        return this;
    }

    public PropertyBuilder Add(Property property, Dimension value)
    {
        _builder.BeginProperty(property.ToUnityString(), 0);

        _builder.AddValue(value);

        _builder.EndProperty();

        return this;
    }

    public PropertyBuilder Add(Property property, StyleValueKeyword value)
    {
        _builder.BeginProperty(property.ToUnityString(), 0);

        _builder.AddValue(value);

        _builder.EndProperty();

        return this;
    }

    public PropertyBuilder Add(Property property, StyleValueFunction value)
    {
        _builder.BeginProperty(property.ToUnityString(), 0);

        _builder.AddValue(value);

        _builder.EndProperty();

        return this;
    }

    public PropertyBuilder Add(Property property, Object value)
    {
        _builder.BeginProperty(property.ToUnityString(), 0);

        _builder.AddValue(value);

        _builder.EndProperty();

        return this;
    }

    public PropertyBuilder Add(Property property, string value, StyleValueType type)
    {
        _builder.BeginProperty(property.ToUnityString(), 0);

        _builder.AddValue(value, type);

        _builder.EndProperty();

        return this;
    }
}