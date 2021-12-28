using System;
using Timberborn.AssetSystem;
using TimberbornAPI.UIBuilderSystem.CustomElements;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberbornAPI.UIBuilderSystem.PresetSystem
{
    public class SliderPresetFactory
    {
        private readonly ComponentBuilder _componentBuilder;

        private readonly IResourceAssetLoader _resourceAssetLoader;
        

        public SliderPresetFactory(ComponentBuilder componentBuilder, IResourceAssetLoader resourceAssetLoader)
        {
            _componentBuilder = componentBuilder;
            _resourceAssetLoader = resourceAssetLoader;
        }
        
        public LocalizableSliderInt SliderInt(int lowValue, int highValue, int value = default, string locKey = default, Length width = default, string text = default, string name = default, Action<SliderIntBuilder> builder = default)
        {
            SliderIntBuilder slider = _componentBuilder.CreateSliderInt()
                .SetName(name)
                .SetLabel(text)
                .SetLowValue(lowValue)
                .SetHighValue(highValue)
                .SetValue(value)
                .SetLabelLocKey(locKey)
                .ModifyTracker(element =>
                {
                    element.style.backgroundImage = new StyleBackground(_resourceAssetLoader.Load<Sprite>("Ui/Images/Buttons/Slider_bar"));
                    element.style.height = new Length(4, Pixel);
                    element.style.unityBackgroundScaleMode = ScaleMode.StretchToFill;
                })
                .ModifyDragContainer(element => element.style.justifyContent = Justify.Center)
                .ModifyDragElement(element =>
                {
                    element.AddToClassList(TimberApiStyle.Buttons.Normal.SliderHolder);
                    element.AddToClassList(TimberApiStyle.Buttons.Hover.SliderHolderHover);
                    element.style.width = new Length(24, Pixel);
                    element.style.height = new Length(24, Pixel);
                    element.style.marginTop = -10f;
                })
                .ModifyLabelElement(element => element.style.color = Color.white);

            if (width != default)
                slider.SetWidth(width);
            
            builder?.Invoke(slider);
            return slider.Build();
        }
        
        public LocalizableSlider Slider(float lowValue, float highValue, float value = default, string locKey = default, Length width = default, string text = default, string name = default, Action<SliderBuilder> builder = default)
        {
            SliderBuilder slider = _componentBuilder.CreateSlider()
                .SetName(name)
                .SetLabel(text)
                .SetLowValue(lowValue)
                .SetHighValue(highValue)
                .SetValue(value)
                .SetLabelLocKey(locKey)
                .ModifyTracker(element =>
                {
                    element.style.backgroundImage = new StyleBackground(_resourceAssetLoader.Load<Sprite>("Ui/Images/Buttons/Slider_bar"));
                    element.style.height = new Length(4, Pixel);
                    element.style.unityBackgroundScaleMode = ScaleMode.StretchToFill;
                })
                .ModifyDragContainer(element => element.style.justifyContent = Justify.Center)
                .ModifyDragElement(element =>
                {
                    element.AddToClassList(TimberApiStyle.Buttons.Normal.SliderHolder);
                    element.AddToClassList(TimberApiStyle.Buttons.Hover.SliderHolderHover);
                    element.style.width = new Length(24, Pixel);
                    element.style.height = new Length(24, Pixel);
                    element.style.marginTop = -10f;
                })
                .ModifyLabelElement(element => element.style.color = Color.white);

            if (width != default)
                slider.SetWidth(width);
            
            builder?.Invoke(slider);
            return slider.Build();
        }
    }
}