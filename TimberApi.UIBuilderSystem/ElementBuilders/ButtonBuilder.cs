using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.ElementBuilders;

public class LocalizableButtonBuilder : ButtonBuilder<LocalizableButtonBuilder, LocalizableButton>
{
    protected override LocalizableButtonBuilder BuilderInstance => this;

    public LocalizableButtonBuilder SetLocKey(string key)
    {
        Root._textLocKey = key;
        return BuilderInstance;
    }
}

public class ButtonBuilder : ButtonBuilder<ButtonBuilder, NineSliceButton>
{
    protected override ButtonBuilder BuilderInstance => this;

    public ButtonBuilder SetText(string text)
    {
        Root.text = text;
        return BuilderInstance;
    }
}

public abstract class ButtonBuilder<TBuilder, TElement> : BaseElementBuilder<TBuilder, TElement>
    where TBuilder : BaseElementBuilder<TBuilder, TElement>
    where TElement : Button, new()
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