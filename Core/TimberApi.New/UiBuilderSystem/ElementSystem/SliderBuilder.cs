using System;
using System.Diagnostics.CodeAnalysis;
using TimberApi.New.ModAssetSystem;
using TimberApi.New.UiBuilderSystem.PresetSystem;
using Timberborn.CoreUI;
using UnityEngine.UIElements;
using LocalizableSlider = TimberApi.New.UiBuilderSystem.CustomElements.LocalizableSlider;

namespace TimberApi.New.UiBuilderSystem.ElementSystem
{
    public class SliderBuilder : BaseElementBuilder<CustomElements.LocalizableSlider, SliderBuilder>
    {
        protected override SliderBuilder BuilderInstance => this;
        
        public SliderBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory) 
            : base(new LocalizableSlider(), visualElementInitializer, assetLoader, uiPresetFactory)
        {

        }
        
        public SliderBuilder SetLabelLocKey(string locKey)
        {
            Root.TextLocKey = locKey;
            return this;
        }

        public SliderBuilder SetLabel(string text)
        {
            Root.label = text;
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
    }
}