using System;
using Timberborn.CoreUI;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.Common;
using UnityEngine.UIElements;
using LocalizableSlider = TimberbornAPI.UIBuilderSystem.CustomElements.LocalizableSlider;

namespace TimberbornAPI.UIBuilderSystem.ElementSystem
{
    public abstract class BaseElementBuilder<TElement, TBuilder> where TElement : VisualElement where TBuilder : BaseElementBuilder<TElement, TBuilder>
    {
        private readonly VisualElementInitializer _visualElementInitializer;
        
        protected abstract TBuilder BuilderInstance { get; }
        
        protected readonly TElement Root;
        
        public BaseElementBuilder(TElement root, VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader)
        {
            Root = root;
            _visualElementInitializer = visualElementInitializer;
            AddStyleSheet(assetLoader.Load<StyleSheet>("timberApi/timber_api/style"));
        }
        
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

        public TElement Build()
        {
            return Root;
        }
        
        public TElement BuildAndInitialize()
        {
            _visualElementInitializer.InitializeVisualElement(Root);
            return Root;
        }
    }
}