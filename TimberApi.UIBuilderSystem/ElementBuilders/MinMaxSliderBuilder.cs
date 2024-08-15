using TimberApi.UIBuilderSystem.CustomElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.ElementBuilders;

public class LocalizableMinMaxSliderBuilder : MinMaxSliderBuilder<LocalizableMinMaxSliderBuilder, LocalizableMinMaxSlider>
{
    protected override LocalizableMinMaxSliderBuilder BuilderInstance => this;

    public LocalizableMinMaxSliderBuilder SetLocKey(string key)
    {
        Root.TextLocKey = key;
        return BuilderInstance;
    }
}

public class MinMaxSliderBuilder : MinMaxSliderBuilder<MinMaxSliderBuilder, MinMaxSlider>
{
    protected override MinMaxSliderBuilder BuilderInstance => this;

    public MinMaxSliderBuilder SetLabel(string text)
    {
        Root.label = text;
        return BuilderInstance;
    }
}

public abstract class MinMaxSliderBuilder<TBuilder, TElement> : BaseElementBuilder<TBuilder, TElement>
    where TBuilder : BaseElementBuilder<TBuilder, TElement>
    where TElement : MinMaxSlider, new()
{
    public TBuilder SetLowLimit(float value)
    {
        Root.lowLimit = value;
        return BuilderInstance;
    }

    public TBuilder SetHighLimit(float value)
    {
        Root.highLimit = value;
        return BuilderInstance;
    }

    public TBuilder SetValue(Vector2 value)
    {
        Root.value = value;
        return BuilderInstance;
    }

    protected override TElement InitializeRoot()
    {
        return new TElement();
    }
}