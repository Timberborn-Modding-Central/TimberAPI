using System;
using Timberborn.CoreUI;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using UnityEngine.UIElements;

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
            root.styleSheets.Add(assetLoader.Load<StyleSheet>("timberApi/timber_api/style"));
            _visualElementInitializer = visualElementInitializer;
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
        
        public TBuilder SetMargin(Length margin)
        {
            Root.style.marginLeft = margin;
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