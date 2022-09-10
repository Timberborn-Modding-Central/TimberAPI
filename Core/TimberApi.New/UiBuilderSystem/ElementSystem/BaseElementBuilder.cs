using System;
using TimberApi.New.ModAssetSystem;
using TimberApi.New.UiBuilderSystem.PresetSystem;
using Timberborn.CoreUI;
using UnityEngine.UIElements;

namespace TimberApi.New.UiBuilderSystem.ElementSystem
{
    public abstract class BaseElementBuilder<TElement, TBuilder> where TElement : VisualElement where TBuilder : BaseElementBuilder<TElement, TBuilder>
    {
        private readonly IAssetLoader _assetLoader;

        private readonly UiPresetFactory _uiPresetFactory;
        private readonly VisualElementInitializer _visualElementInitializer;

        protected readonly TElement Root;

        public BaseElementBuilder(TElement root, VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory)
        {
            Root = root;
            _visualElementInitializer = visualElementInitializer;
            _assetLoader = assetLoader;
            _uiPresetFactory = uiPresetFactory;
            AddStyleSheet(assetLoader.Load<StyleSheet>("TimberAPI/timber_api/style"));
        }

        protected abstract TBuilder BuilderInstance { get; }

        public TBuilder AddStyleSheet(StyleSheet styleSheet)
        {
            Root.styleSheets.Add(styleSheet);
            return BuilderInstance;
        }

        public TBuilder SetName(string name)
        {
            Root.name = name;
            return BuilderInstance;
        }

        public TBuilder AddClass(string className)
        {
            Root.AddToClassList(className);
            return BuilderInstance;
        }

        public TBuilder RemoveClass(string className)
        {
            Root.RemoveFromClassList(className);
            return BuilderInstance;
        }

        public TBuilder AddComponent(Action<VisualElementBuilder> builder)
        {
            var visualElementBuilder = new VisualElementBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
            builder(visualElementBuilder);
            Root.Add(visualElementBuilder.Build());
            return BuilderInstance;
        }

        public TBuilder AddComponent(VisualElement element)
        {
            Root.Add(element);
            return BuilderInstance;
        }

        public TBuilder AddPreset(Func<UiPresetFactory, VisualElement> presetFactory)
        {
            Root.Add(presetFactory.Invoke(_uiPresetFactory));
            return BuilderInstance;
        }

        public TBuilder SetWidth(Length width)
        {
            Root.style.width = width;
            return BuilderInstance;
        }

        public TBuilder SetHeight(Length height)
        {
            Root.style.height = height;
            return BuilderInstance;
        }

        public TBuilder SetStyle(Action<IStyle> style)
        {
            style.Invoke(Root.style);
            return BuilderInstance;
        }

        public TBuilder SetMargin(Margin margin)
        {
            Root.style.marginLeft = margin.Left;
            Root.style.marginTop = margin.Top;
            Root.style.marginRight = margin.Right;
            Root.style.marginBottom = margin.Bottom;
            return BuilderInstance;
        }

        public TBuilder SetPadding(Padding padding)
        {
            Root.style.paddingLeft = padding.Left;
            Root.style.paddingTop = padding.Top;
            Root.style.paddingRight = padding.Right;
            Root.style.paddingBottom = padding.Bottom;
            return BuilderInstance;
        }

        public TBuilder SetJustifyContent(Justify justify)
        {
            Root.style.justifyContent = justify;
            return BuilderInstance;
        }

        public TBuilder SetAlignItems(Align align)
        {
            Root.style.alignItems = align;
            return BuilderInstance;
        }

        public TBuilder SetAlignContent(Align align)
        {
            Root.style.alignContent = align;
            return BuilderInstance;
        }

        public TBuilder SetFlexWrap(Wrap wrap)
        {
            Root.style.flexWrap = wrap;
            return BuilderInstance;
        }

        public TBuilder SetFlexDirection(FlexDirection direction)
        {
            Root.style.flexDirection = direction;
            return BuilderInstance;
        }

        public TBuilder SetBackgroundImage(StyleBackground backgroundImage)
        {
            Root.style.backgroundImage = backgroundImage;
            return BuilderInstance;
        }

        public TBuilder SetBackgroundColor(StyleColor color)
        {
            Root.style.backgroundColor = color;
            return BuilderInstance;
        }

        public TBuilder ModifyElement(Action<TElement> elementAction)
        {
            elementAction.Invoke(Root);
            return BuilderInstance;
        }

        public TElement Build()
        {
            return Root;
        }

        public TElement Initialize()
        {
            _visualElementInitializer.InitializeVisualElement(Root);
            return Root;
        }

        public TElement BuildAndInitialize()
        {
            _visualElementInitializer.InitializeVisualElement(Root);
            return Root;
        }
    }
}