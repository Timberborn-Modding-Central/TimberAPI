using System;
using TimberApi.New.UiBuilderSystem.CustomElements;
using TimberApi.New.UiBuilderSystem.ElementSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;
#pragma warning disable CS8625

namespace TimberApi.New.UiBuilderSystem.PresetSystem
{
    public class SliderPresetFactory
    {
        private readonly ComponentBuilder _componentBuilder;

        public SliderPresetFactory(ComponentBuilder componentBuilder)
        {
            _componentBuilder = componentBuilder;
        }
        
        public LocalizableSliderInt SliderIntCircle(int lowValue, int highValue, int value = default, string locKey = default,
            Length width = default, string text = default, string name = default,
            Action<SliderIntBuilder> builder = default)
        {
            SliderIntBuilder slider = EmptySliderInt(lowValue, highValue, value, locKey, width, text, name);
            slider.ModifyDragElement(element =>
            {
                element.AddToClassList(TimberApiStyle.Buttons.Normal.CircleOff);
                element.AddToClassList(TimberApiStyle.Buttons.Hover.CircleHover);
                element.style.width = new Length(16, Pixel);
                element.style.height = new Length(16, Pixel);
                element.style.marginTop = -6f;
            });

            builder?.Invoke(slider);
            return slider.Build();
        }

        public LocalizableSliderInt SliderIntDiamond(int lowValue, int highValue, int value = default, string locKey = default,
            Length width = default, string text = default, string name = default,
            Action<SliderIntBuilder> builder = default)
        {
            SliderIntBuilder slider = EmptySliderInt(lowValue, highValue, value, locKey, width, text, name);
            slider.ModifyDragElement(element =>
                {
                    element.AddToClassList(TimberApiStyle.Buttons.Normal.SliderHolder);
                    element.AddToClassList(TimberApiStyle.Buttons.Hover.SliderHolderHover);
                    element.style.width = new Length(24, Pixel);
                    element.style.height = new Length(24, Pixel);
                    element.style.marginTop = -10f;
                });

            builder?.Invoke(slider);
            return slider.Build();
        }
        
        public LocalizableSlider SliderCircle(float lowValue, float highValue, float value = default, string locKey = default,
            Length width = default, string text = default, string name = default,
            Action<SliderBuilder> builder = default)
        {
            SliderBuilder slider = EmptySlider(lowValue, highValue, value, locKey, width, text, name);
            slider.ModifyDragElement(element =>
            {
                element.AddToClassList(TimberApiStyle.Buttons.Normal.CircleOff);
                element.AddToClassList(TimberApiStyle.Buttons.Hover.CircleHover);
                element.style.width = new Length(16, Pixel);
                element.style.height = new Length(16, Pixel);
                element.style.marginTop = -6f;
            });

            builder?.Invoke(slider);
            return slider.Build();
        }

        public LocalizableSlider SliderDiamond(float lowValue, float highValue, float value = default, string locKey = default,
            Length width = default, string text = default, string name = default,
            Action<SliderBuilder> builder = default)
        {
            SliderBuilder slider = EmptySlider(lowValue, highValue, value, locKey, width, text, name);
            slider.ModifyDragElement(element =>
                {
                    element.AddToClassList(TimberApiStyle.Buttons.Normal.SliderHolder);
                    element.AddToClassList(TimberApiStyle.Buttons.Hover.SliderHolderHover);
                    element.style.width = new Length(24, Pixel);
                    element.style.height = new Length(24, Pixel);
                    element.style.marginTop = -10f;
                });

            builder?.Invoke(slider);
            return slider.Build();
        }

        private SliderBuilder EmptySlider(float lowValue, float highValue, float value = default,
            string locKey = default, Length width = default, string text = default, string name = default)
        {
            SliderBuilder slider = _componentBuilder.CreateSlider()
                .SetName(name)
                .SetLabel(text)
                .SetLowValue(lowValue)
                .SetHighValue(highValue)
                .SetValue(value)
                .SetLabelLocKey(locKey)
                .ModifyDragContainer(element => element.style.justifyContent = Justify.Center)
                .ModifyLabelElement(element => element.style.color = Color.white)
                .ModifyTracker(element =>
                {
                    element.AddToClassList(TimberApiStyle.Backgrounds.ScrollBar);
                    element.style.height = new Length(4, Pixel);
                    element.style.unityBackgroundScaleMode = ScaleMode.StretchToFill;
                });
            if (width != default)
                slider.SetWidth(width);
            return slider;
        }

        private SliderIntBuilder EmptySliderInt(int lowValue, int highValue, int value = default,
            string locKey = default, Length width = default, string text = default, string name = default,
            Action<SliderIntBuilder> builder = default)
        {
            SliderIntBuilder slider = _componentBuilder.CreateSliderInt()
                .SetName(name)
                .SetLabel(text)
                .SetLowValue(lowValue)
                .SetHighValue(highValue)
                .SetValue(value)
                .SetLabelLocKey(locKey)
                .ModifyLabelElement(element => element.style.color = Color.white)
                .ModifyTracker(element =>
                {
                    element.AddToClassList(TimberApiStyle.Backgrounds.ScrollBar);
                    element.style.height = new Length(4, Pixel);
                    element.style.unityBackgroundScaleMode = ScaleMode.StretchToFill;
                })
                .ModifyDragContainer(element => element.style.justifyContent = Justify.Center);

            if (width != default)
                slider.SetWidth(width);

            return slider;
        }
    }
}