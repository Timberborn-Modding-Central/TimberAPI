using TimberApi.UIBuilderSystem.CustomElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.ElementBuilders;

public class LocalizableLabelBuilder : LabelBuilder<LocalizableLabelBuilder, LocalizableLabel>
{
    protected override LocalizableLabelBuilder BuilderInstance => this;

    public LocalizableLabelBuilder SetLocKey(string key)
    {
        Root._textLocKey = key;
        return BuilderInstance;
    }
}

public class LabelBuilder : LabelBuilder<LabelBuilder, NineSliceLabel>
{
    protected override LabelBuilder BuilderInstance => this;

    public LabelBuilder SetText(string text)
    {
        Root.text = text;
        return BuilderInstance;
    }
}

public abstract class LabelBuilder<TBuilder, TElement> : BaseElementBuilder<TBuilder, TElement>
    where TBuilder : BaseElementBuilder<TBuilder, TElement>
    where TElement : Label, new()
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

    public TBuilder SetWhiteSpace(WhiteSpace whiteSpace)
    {
        Root.style.whiteSpace = whiteSpace;
        return BuilderInstance;
    }

    protected override TElement InitializeRoot()
    {
        return new TElement();
    }
}