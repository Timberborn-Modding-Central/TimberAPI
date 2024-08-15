using TimberApi.UIBuilderSystem.CustomElements;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.ElementBuilders;

public class LocalizableSliderBuilder : SliderBuilder<LocalizableSliderBuilder, LocalizableSlider>
{
    protected override LocalizableSliderBuilder BuilderInstance => this;

    public LocalizableSliderBuilder SetLocKey(string key)
    {
        Root._textLocKey = key;
        return BuilderInstance;
    }
}

public class SliderBuilder : SliderBuilder<SliderBuilder, Slider>
{
    protected override SliderBuilder BuilderInstance => this;

    public SliderBuilder SetLabel(string text)
    {
        Root.label = text;
        return BuilderInstance;
    }
}

public abstract class SliderBuilder<TBuilder, TElement> : BaseElementBuilder<TBuilder, TElement>
    where TBuilder : BaseElementBuilder<TBuilder, TElement>
    where TElement : Slider, new()
{
    public TBuilder SetLowValue(float value)
    {
        Root.lowValue = value;
        return BuilderInstance;
    }

    public TBuilder SetHighValue(float value)
    {
        Root.highValue = value;
        return BuilderInstance;
    }

    public TBuilder SetValue(float value)
    {
        Root.value = value;
        return BuilderInstance;
    }

    protected override TElement InitializeRoot()
    {
        return new TElement();
    }
}