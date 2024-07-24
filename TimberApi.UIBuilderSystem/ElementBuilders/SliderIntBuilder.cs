using System;
using System.Diagnostics.CodeAnalysis;
using Timberborn.CoreUI;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.ElementBuilders
{
    public class SliderIntBuilder : BaseElementBuilder<SliderIntBuilder, LocalizableSliderInt>
    {
        protected override SliderIntBuilder BuilderInstance => this;

        public SliderIntBuilder SetLabelLocKey(string locKey)
        {
            Root._textLocKey = locKey;
            return this;
        }

        public SliderIntBuilder SetLowValue(int value)
        {
            Root.lowValue = value;
            return this;
        }

        public SliderIntBuilder SetHighValue(int value)
        {
            Root.highValue = value;
            return this;
        }

        public SliderIntBuilder SetValue(int value)
        {
            Root.value = value;
            return this;
        }

        [SuppressMessage("", "Publicizer001")]
        public SliderIntBuilder ModifyDragContainer(Action<VisualElement> modifyScroller)
        {
            modifyScroller.Invoke(Root.dragContainer);
            return this;
        }

        [SuppressMessage("", "Publicizer001")]
        public SliderIntBuilder ModifyDragElement(Action<VisualElement> modifyScroller)
        {
            modifyScroller.Invoke(Root.dragElement);
            return this;
        }

        public SliderIntBuilder ModifyLabelElement(Action<VisualElement> modifyScroller)
        {
            modifyScroller.Invoke(Root.labelElement);
            return this;
        }

        public SliderIntBuilder ModifyTracker(Action<VisualElement> modifyScroller)
        {
            modifyScroller.Invoke(Root.Q<VisualElement>("unity-tracker"));
            return this;
        }

        protected override LocalizableSliderInt InitializeRoot()
        {
            return new LocalizableSliderInt();
        }
    }
}