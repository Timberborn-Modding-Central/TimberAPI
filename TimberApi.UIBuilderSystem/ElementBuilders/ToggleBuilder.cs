using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.ElementBuilders;

public class LocalizableToggleBuilder : ToggleBuilder<LocalizableToggleBuilder, LocalizableToggle>
{
    protected override LocalizableToggleBuilder BuilderInstance => this;

    public LocalizableToggleBuilder SetLocKey(string key)
    {
        Root._textLocKey = key;
        return BuilderInstance;
    }
}

public class ToggleBuilder : ToggleBuilder<ToggleBuilder, Toggle>
{
    protected override ToggleBuilder BuilderInstance => this;

    public ToggleBuilder SetText(string text)
    {
        Root.text = text;
        return BuilderInstance;
    }
}

public abstract class ToggleBuilder<TBuilder, TElement> : BaseElementBuilder<TBuilder, TElement>
    where TBuilder : BaseElementBuilder<TBuilder, TElement>
    where TElement : Toggle, new()
{
    public TBuilder SetColor(StyleColor color)
    {
        Root.style.color = color;
        return BuilderInstance;
    }

    public TBuilder SetFontSize(Length size)
    {
        Root.style.fontSize = size;
        return BuilderInstance;
    }

    public TBuilder SetFontStyle(FontStyle style)
    {
        Root.style.unityFontStyleAndWeight = style;
        return BuilderInstance;
    }

    protected override TElement InitializeRoot()
    {
        return new TElement();
    }
}