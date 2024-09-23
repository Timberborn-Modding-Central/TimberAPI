using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine;
using UnityEngine.UIElements.StyleSheets;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem;

public class PropertyBuilder(UnityEngine.UIElements.StyleSheets.StyleSheetBuilder builder)
{
    public PropertyBuilder Add(Property property, float value)
    {
        builder.BeginProperty(property.ToUnityString(), 0);

        builder.AddValue(value);

        builder.EndProperty();

        return this;
    }

    public PropertyBuilder Add(Property property, Dimension value)
    {
        builder.BeginProperty(property.ToUnityString(), 0);

        builder.AddValue(value);

        builder.EndProperty();

        return this;
    }

    public PropertyBuilder Add(Property property, StyleValueKeyword value)
    {
        builder.BeginProperty(property.ToUnityString(), 0);

        builder.AddValue(UnityElementMapper.UnityStyleValueKeyword[value]);

        builder.EndProperty();

        return this;
    }

    public PropertyBuilder Add(Property property, StyleValueFunction value)
    {
        builder.BeginProperty(property.ToUnityString(), 0);

        builder.AddValue(UnityElementMapper.UnityStyleValueFunction[value]);

        builder.EndProperty();

        return this;
    }

    public PropertyBuilder Add(Property property, Object value)
    {
        builder.BeginProperty(property.ToUnityString(), 0);

        builder.AddValue(value);

        builder.EndProperty();

        return this;
    }

    public PropertyBuilder Add(Property property, string value, StyleValueType type)
    {
        builder.BeginProperty(property.ToUnityString(), 0);

        builder.AddValue(value, UnityElementMapper.UnityStyleValueType[type]);

        builder.EndProperty();

        return this;
    }
    
    public PropertyBuilder Add(Property property, Color color)
    {
        builder.BeginProperty(property.ToUnityString(), 0);

        builder.AddValue(color);

        builder.EndProperty();

        return this;
    }
}