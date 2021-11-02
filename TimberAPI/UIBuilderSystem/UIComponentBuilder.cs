using System;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;
using LocalizableButton = TimberbornAPI.UIBuilderSystem.CustomElements.LocalizableButton;
using LocalizableLabel = TimberbornAPI.UIBuilderSystem.CustomElements.LocalizableLabel;
using LocalizableToggle = TimberbornAPI.UIBuilderSystem.CustomElements.LocalizableToggle;

namespace TimberbornAPI.UIBuilderSystem
{
public class UIComponentBuilder : IUIComponentBuilder
{
        private readonly VisualElementInitializer _visualElementInitializer;
        
        private readonly ElementFactory _elementFactory;
        
        private VisualElement _root;
        
        public UIComponentBuilder(ElementFactory elementFactory, VisualElementInitializer visualElementInitializer)
        {
            _elementFactory = elementFactory;
            _visualElementInitializer = visualElementInitializer;
            _root = new VisualElement();
        }
        
        public UIComponentBuilder(ElementFactory elementFactory, VisualElementInitializer visualElementInitializer, VisualElement root)
        {
            _elementFactory = elementFactory;
            _root = root;
            _visualElementInitializer = visualElementInitializer;
        }

        public IUIComponentBuilder RootStyle(Action<IStyle> style)
        {
            style(_root.style);
            return this;
        }

        #region Toggles

        public IUIComponentBuilder AddLocalizedSettingToggle(string textLocKey = null, string name = null, Action<IStyle> style = null)
        {
            LocalizableToggle toggle = _elementFactory.LocalizedToggle(new[] {"settings-element", "settings-toggle", "settings-text"}, name);
            toggle.TextLocKey = textLocKey;
            return AddToggle(toggle, textLocKey, style);
        }
        
        public IUIComponentBuilder AddSettingToggle(string text = null, string name = null, Action<IStyle> style = null)
        {
            return AddToggle(_elementFactory.Toggle(new[] {"settings-element", "settings-toggle", "settings-text"}, name), text, style);
        }

        private IUIComponentBuilder AddToggle(Toggle toggle, string text, Action<IStyle> style)
        {
            style?.Invoke(toggle.style);
            toggle.text = text;
            _root.Add(toggle);
            return this;
        }

        #endregion

        #region Boxes

        public IUIComponentBuilder AddBox(Action<IUIComponentBuilder> children, Length width = default, Length height = default, Length padding = default, string name = null, Action<IStyle> style = null)
        {
            VisualElement box = _elementFactory.NineSliceVisualElement(new[] {"sliced-border", "content-centered"}, name);
            if (width != default)
                box.style.width = width;
            if (height != default)
                box.style.height = height;
            if (padding != default)
            {
                box.style.paddingTop = padding;
                box.style.paddingRight = padding;
                box.style.paddingBottom = padding;
                box.style.paddingLeft = padding;
            }
            else
            {
                box.style.paddingTop = 45;
                box.style.paddingRight = 45;
                box.style.paddingBottom = 45;
                box.style.paddingLeft = 45;
            }
            
            return AddBox(box, children, style);
        }
        
        private IUIComponentBuilder AddBox(VisualElement box, Action<IUIComponentBuilder> builder, Action<IStyle> style = null)
        {
            IUIComponentBuilder cb = new UIComponentBuilder(_elementFactory, _visualElementInitializer, box);
            builder(cb);
            VisualElement element = cb.Build();
            style?.Invoke(element.style);
            _root.Add(element);
            return this;
        }

        #endregion

        #region ScrollView
        
        public IUIComponentBuilder AddScrollView(Action<IUIComponentBuilder> children, string name = null, Action<IStyle> style = null)
        {
            VisualElement wrapper = _elementFactory.VisualElement(new [] {"panel-list-view"}, name);
            ScrollView scrollView = _elementFactory.ScrollView(new[] {"unity-scroll-view", "unity-scroll-view--vertical", "unity-scroll-view--scroll"});
            
            return AddScrollView(wrapper, scrollView, children, style);
        }

        private IUIComponentBuilder AddScrollView(VisualElement wrapper, ScrollView scrollView, Action<IUIComponentBuilder> builder, Action<IStyle> style = null)
        {
            IUIComponentBuilder cb = new UIComponentBuilder(_elementFactory, _visualElementInitializer, scrollView);
            builder(cb);
            VisualElement element = cb.Build();
            style?.Invoke(element.style);
            wrapper.Add(element);
            _root.Add(wrapper);
            return this;
        }

        #endregion
        
        #region Sliders

        public IUIComponentBuilder AddLocalizedSlider(int low, int high, string textLocKey = "", Length width = default, string sliderName = null, string sliderValueName = null, string wrapperName = null, Action<IStyle> wrapperStyle = null, Action<IStyle> sliderStyle = null, Action<IStyle> labelStyle = null)
        {
            VisualElement wrapper = _elementFactory.VisualElement(new[] {"settings-element", "settings-slider", "settings-text"}, wrapperName);
            LocalizableLabel label = _elementFactory.LocalizedLabel(new[] {"settings-slider__end-label"}, sliderValueName);
            label.TextLocKey = textLocKey;
            SliderInt slider = _elementFactory.Slider(new[] {"settings-slider__slider"}, sliderName);
            return AddSlider(wrapper, label, slider, textLocKey, low, high, width, wrapperStyle, sliderStyle, labelStyle);
        }
        
        public IUIComponentBuilder AddSlider(int low, int high, string text = "", Length width = default, string sliderName = null, string sliderValueName = null, string wrapperName = null, Action<IStyle> wrapperStyle = null, Action<IStyle> sliderStyle = null, Action<IStyle> labelStyle = null)
        {
            VisualElement wrapper = _elementFactory.VisualElement(new[] {"settings-element", "settings-slider", "settings-text"}, wrapperName);
            Label label = _elementFactory.Label(new[] {"settings-slider__end-label"}, sliderValueName);
            SliderInt slider = _elementFactory.Slider(new[] {"settings-slider__slider"}, sliderName);
            return AddSlider(wrapper, label, slider, text, low, high, width, wrapperStyle, sliderStyle, labelStyle);
        }
        
        private IUIComponentBuilder AddSlider(VisualElement wrapper, Label label, SliderInt slider, string text, int low, int high, Length width, Action<IStyle> wrapperStyle, Action<IStyle> sliderStyle, Action<IStyle> labelStyle)
        {
            wrapperStyle?.Invoke(wrapper.style);
            sliderStyle?.Invoke(slider.style);
            labelStyle?.Invoke(label.style);
            if (width != default)
                wrapper.style.width = width;
            slider.lowValue = low;
            slider.highValue = high;
            slider.label = text;
            wrapper.Add(slider);
            wrapper.Add(label);
            _root.Add(wrapper);
            return this;
        }

        #endregion

        #region Headers
        
        public IUIComponentBuilder AddLocalizedBoxHeader(string textLocKey, string name = null, string wrapperName = null, Action<IStyle> style = null, Action<IStyle> wrapperStyle = null)
        {
            VisualElement wrapper = _elementFactory.Label(new[] {"capsule-header", "capsule-header--lower", "content-centered"}, wrapperName);
            LocalizableLabel header = _elementFactory.LocalizedLabel(new[] {"unity-text-element", "unity-label", "capsule-header__text"}, name);
            header.TextLocKey = textLocKey;
            
            return AddHeaderWithWrapper(wrapper, header, textLocKey, style, wrapperStyle);
        }
        
        public IUIComponentBuilder AddBoxHeader(string text, string name = null, string wrapperName = null, Action<IStyle> style = null, Action<IStyle> wrapperStyle = null)
        {
            VisualElement wrapper = _elementFactory.Label(new[] {"capsule-header", "capsule-header--lower", "content-centered"}, wrapperName);
            Label header = _elementFactory.Label(new[] {"unity-text-element", "unity-label", "capsule-header__text"}, name);
            
            return AddHeaderWithWrapper(wrapper, header, text, style, wrapperStyle);
        }
        
        public IUIComponentBuilder AddSectionHeader(string text, string name = null, Action<IStyle> style = null)
        {
            return AddHeader(_elementFactory.Label(new[] {"unity-text-element", "unity-label", "settings-header"}, name), text, style);
        }
        
        private IUIComponentBuilder AddHeader(Label header, string text, Action<IStyle> style)
        {
            style?.Invoke(header.style);
            header.text = text;
            _root.Add(header);
            return this;
        }
        
        private IUIComponentBuilder AddHeaderWithWrapper(VisualElement wrapper, Label header, string text, Action<IStyle> style = null, Action<IStyle> wrapperStyle = null)
        {
            style?.Invoke(header.style);
            wrapperStyle?.Invoke(wrapper.style);
            header.text = text;
            wrapper.Add(header);
            _root.Add(wrapper);
            return this;
        }

        #endregion

        #region Buttons
        
        public IUIComponentBuilder AddLocalizedButton(string textLocKey, Length width = default, Length height = default, Length fontsize = default, string name = null, Action<IStyle> style = null)
        {
            LocalizableButton button = _elementFactory.LocalizedButton(new[] {"menu-button"}, name);
            button.TextLocKey = textLocKey;
            return AddButton(button, textLocKey, width, height, fontsize, style);
        }
        
        public IUIComponentBuilder AddButton(string text, Length width = default, Length height = default, Length fontsize = default, string name = null, Action<IStyle> style = null)
        {
            return AddButton(_elementFactory.Button(new[] {"menu-button"}, name), text, width, height, fontsize, style);
        }
        
        public IUIComponentBuilder AddCloseButton(Length width = default, Length height = default, Length fontsize = default, string name = null, Action<IStyle> style = null)
        {
            return AddButton(_elementFactory.Button(new[] {"close-button"}, name), null, width, height, fontsize, style);
        }

        public IUIComponentBuilder AddButtonLeftArrow(Length width = default, Length height = default, Length fontSize = default,
            string name = null, Action<IStyle> style = null)
        {
            return AddButton(_elementFactory.Button(new[] {"settings-cycler__decrease"}, name), null, width, height, fontSize, style);
        }

        public IUIComponentBuilder AddButtonRightArrow(Length width = default, Length height = default, Length fontSize = default,
            string name = null, Action<IStyle> style = null)
        {
            return AddButton(_elementFactory.Button(new[] {"settings-cycler__increase"}, name), null, width, height, fontSize, style);
        }

        private IUIComponentBuilder AddButton(Button button, string text, Length width, Length height, Length fontSize, Action<IStyle> style)
        {
            style?.Invoke(button.style);
            button.text = text;
            if (width != default)
                button.style.width = width;
            if (height != default)
                button.style.height = height;
            if (fontSize != default)
                button.style.fontSize = fontSize;
            _root.Add(button);
            return this;
        }

        #endregion

        #region Wrappers
        
        public IUIComponentBuilder AddWrapper(Action<IUIComponentBuilder> builder, string name = null, FlexDirection flexDirection = FlexDirection.Row, Justify justifyContent = Justify.FlexStart, Wrap wrap = Wrap.Wrap, Action<IStyle> style = null)
        {
            IUIComponentBuilder cb = new UIComponentBuilder(_elementFactory, _visualElementInitializer);
            builder(cb);
            VisualElement element = cb.Build();
            style?.Invoke(element.style);
            element.name = name;
            element.style.flexDirection = flexDirection;
            element.style.justifyContent = justifyContent;
            element.style.flexWrap = wrap;
            _root.Add(element);
            return this;
        }
        
        #endregion

        #region TextFields

        public IUIComponentBuilder AddTextField(string nameField = null, string nameInput = null, string defaultText = "", Length width = default, Length height = default, Length fontsize = default, bool multiline = false, TextAnchor textAnchor = TextAnchor.MiddleCenter, Action<IStyle> style = null)
        {
            TextField textField = _elementFactory.TextField(new[] {"text-field"}, nameField);
            return AddTextField(textField, nameInput, defaultText, width, height, fontsize, multiline, textAnchor, style);
        } 
        
        private IUIComponentBuilder AddTextField(TextField textField, string nameInput, string defaultText, Length width, Length height, Length fontsize, bool multiline, TextAnchor textAnchor, Action<IStyle> style)
        {
            style?.Invoke(textField.style);
            textField.textInput.style.unityTextAlign = new StyleEnum<TextAnchor>(textAnchor);
            if (fontsize != default)
                textField.textInput.style.fontSize = fontsize;
            if (width != default)
                textField.style.width = width;
            if (height != default)
                textField.style.height = height;
            textField.multiline = multiline;
            textField.text = defaultText;

            textField.textInput.name = nameInput;
            _root.Add(textField);
            return this;
        }

        #endregion

        #region Labels

        public IUIComponentBuilder AddLocalizedLabel(string textLocKey, Length width = default, TextAnchor textAnchor = TextAnchor.UpperLeft, string name = null, Action<IStyle> style = null)
        {
            LocalizableLabel label = _elementFactory.LocalizedLabel(new[] {"menu-label"}, name);
            label.TextLocKey = textLocKey;
            return AddLabel(label, textLocKey, width, textAnchor, style);
        } 
        
        public IUIComponentBuilder AddLabel(string text, Length width = default, TextAnchor textAnchor = TextAnchor.UpperLeft, string name = null, Action<IStyle> style = null)
        {
            Label label = _elementFactory.Label(new[] {"menu-label"}, name);
            return AddLabel(label, text, width, textAnchor, style);
        }
        
        private IUIComponentBuilder AddLabel(Label label, string text, Length width, TextAnchor textAnchor, Action<IStyle> style)
        {
            style?.Invoke(label.style);
            label.text = text;
            if(width != default)
                label.style.width = width;
            label.style.unityTextAlign = textAnchor;
            
            _root.Add(label);
            return this;
        }

        #endregion

        #region Customs

        public IUIComponentBuilder AddCustomComponent(VisualElement component, Action<IStyle> style = null)
        {
            style?.Invoke(component.style);
            _root.Add(component);
            return this;
        }

        #endregion
        
        

        public VisualElement Build()
        {
            _visualElementInitializer.InitializeVisualElement(_root);
            return _root;
        }
    }
}