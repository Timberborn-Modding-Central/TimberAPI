using System;
using Timberborn.CoreUI;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem
{
    public class UIBoxBuilder : IUIBoxBuilder
    {
        private readonly IUIComponentBuilder _root;

        private Action<IUIComponentBuilder> _boxComponents;

        private Action<IUIComponentBuilder> _children;

        private string _name;

        private Length _width;

        private Length _height;

        private Length _padding;

        private Action<IStyle> _style;

        public UIBoxBuilder(IElementFactory elementFactory, VisualElementInitializer visualElementInitializer)
        {
            _root = new UIComponentBuilder(elementFactory, visualElementInitializer);
            _root.RootStyle(style =>
            {
                style.flexGrow = 1;
                style.alignItems = Align.Center;
                style.justifyContent = Justify.Center;
                style.flexWrap = Wrap.Wrap;
                style.flexDirection = FlexDirection.Row;
            });
            _boxComponents = delegate { };
            _children = delegate { };
            _width = new Length(100, Length.Unit.Percent);
            _height = new Length(100, Length.Unit.Percent);
        }

        public IUIBoxBuilder AddComponents(Action<IUIComponentBuilder> action)
        {
            _children += action;
            return this;
        }

        public IUIBoxBuilder AddLocalizedHeader(string textLocKey, string name = null, string wrapperName = null, Action<IStyle> style = null, Action<IStyle> wrapperStyle = null)
        {
            _boxComponents += builder => builder.AddLocalizedBoxHeader(textLocKey, name, wrapperName, style, wrapperStyle);
            return this;
        }

        public IUIBoxBuilder AddHeader(string text, string name = null, string wrapperName = null, Action<IStyle> style = null, Action<IStyle> wrapperStyle = null)
        {
            _boxComponents += builder => builder.AddBoxHeader(text, name, wrapperName, style, wrapperStyle);
            return this;
        }

        public IUIBoxBuilder AddCloseButton(Length width = default, Length height = default, Length fontsize = default, string name = null, Action<IStyle> style = null)
        {
            _boxComponents += builder => builder.AddCloseButton(width, height, fontsize, name, style);
            return this;
        }

        public IUIBoxBuilder BoxStyle(Action<IStyle> style)
        {
            _style = style;
            return this;
        }

        public IUIBoxBuilder BoxWrapperStyle(Action<IStyle> style)
        {
            _root.RootStyle(_style);
            return this;
        }

        public IUIBoxBuilder SetWidth(Length width)
        {
            _width = width;
            return this;
        }

        public IUIBoxBuilder SetHeight(Length height)
        {
            _height = height;
            return this;
        }

        public IUIBoxBuilder SetPadding(Length padding)
        {
            _padding = padding;
            return this;
        }

        public IUIBoxBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public VisualElement Build()
        {
            return _root.AddBox(_boxComponents + (componentBuilder => componentBuilder.AddScrollView(_children)), _width, _height, _padding, _name, _style).Build();
        }
    }
}