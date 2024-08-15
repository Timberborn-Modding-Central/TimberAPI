using TimberApi.UIBuilderSystem.CustomElements;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.ElementBuilders;

public class LocalizableSliderIntBuilder : SliderIntBuilder<LocalizableSliderIntBuilder, LocalizableSliderInt>
{
    protected override LocalizableSliderIntBuilder BuilderInstance => this;

    public LocalizableSliderIntBuilder SetLocKey(string key)
    {
        Root._textLocKey = key;
        return BuilderInstance;
    }
}

public class SliderIntBuilder : SliderIntBuilder<SliderIntBuilder, SliderInt>
{
    protected override SliderIntBuilder BuilderInstance => this;

    public SliderIntBuilder SetLabel(string text)
    {
        Root.label = text;
        return BuilderInstance;
    }
}

public abstract class SliderIntBuilder<TBuilder, TElement> : BaseElementBuilder<TBuilder, TElement>
    where TBuilder : BaseElementBuilder<TBuilder, TElement>
    where TElement : SliderInt, new()
{
    public TBuilder SetLowValue(int value)
    {
        Root.lowValue = value;
        return BuilderInstance;
    }

    public TBuilder SetHighValue(int value)
    {
        Root.highValue = value;
        return BuilderInstance;
    }

    public TBuilder SetValue(int value)
    {
        Root.value = value;
        return BuilderInstance;
    }

    protected override TElement InitializeRoot()
    {
        return new TElement();
    }
}