using System;
using System.Diagnostics.CodeAnalysis;
using Timberborn.CoreUI;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.ElementBuilders;

public class SliderBuilder : BaseElementBuilder<SliderBuilder, LocalizableSlider>
{
    protected override SliderBuilder BuilderInstance => this;

    public SliderBuilder SetLabelLocKey(string locKey)
    {
        Root._textLocKey = locKey;
        return this;
    }

    public SliderBuilder SetLowValue(float value)
    {
        Root.lowValue = value;
        return this;
    }

    public SliderBuilder SetHighValue(float value)
    {
        Root.highValue = value;
        return this;
    }

    public SliderBuilder SetValue(float value)
    {
        Root.value = value;
        return this;
    }

    [SuppressMessage("", "Publicizer001")]
    public SliderBuilder ModifyDragContainer(Action<VisualElement> modifyScroller)
    {
        modifyScroller.Invoke(Root.dragContainer);
        return this;
    }

    [SuppressMessage("", "Publicizer001")]
    public SliderBuilder ModifyDragElement(Action<VisualElement> modifyScroller)
    {
        modifyScroller.Invoke(Root.dragElement);
        return this;
    }

    public SliderBuilder ModifyLabelElement(Action<VisualElement> modifyScroller)
    {
        modifyScroller.Invoke(Root.labelElement);
        return this;
    }

    public SliderBuilder ModifyTracker(Action<VisualElement> modifyScroller)
    {
        modifyScroller.Invoke(Root.Q<VisualElement>("unity-tracker"));
        return this;
    }

    protected override LocalizableSlider InitializeRoot()
    {
        return new LocalizableSlider();
    }
}