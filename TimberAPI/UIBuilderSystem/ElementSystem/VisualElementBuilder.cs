using System;
using Timberborn.CoreUI;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.UIBuilderSystem.PresetSystem;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem.ElementSystem
{
    public class VisualElementBuilder : BaseElementBuilder<NineSliceVisualElement, VisualElementBuilder>
    {
        private readonly UiPresetFactory _uiPresetFactory;
        
        private readonly VisualElementInitializer _visualElementInitializer;

        private readonly IAssetLoader _assetLoader;
        
        protected override VisualElementBuilder BuilderInstance => this;
        
        public VisualElementBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory) : base(new NineSliceVisualElement(), visualElementInitializer, assetLoader)
        {
            _visualElementInitializer = visualElementInitializer;
            _assetLoader = assetLoader;
            _uiPresetFactory = uiPresetFactory;
        }
        
        public VisualElementBuilder AddComponent(Action<VisualElementBuilder> builder)
        {
            VisualElementBuilder visualElementBuilder = new VisualElementBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
            builder(visualElementBuilder);
            Root.Add(visualElementBuilder.Build());
            return this;
        }
        
        public VisualElementBuilder AddComponent(VisualElement element)
        {
            Root.Add(element);
            return this;
        }

        public VisualElementBuilder AddPreset(Func<UiPresetFactory, VisualElement> presetFactory)
        {
            Root.Add(presetFactory.Invoke(_uiPresetFactory));
            return this;
        }
        
        public VisualElementBuilder SetJustifyContent(Justify justify)
        {
            Root.style.justifyContent = justify;
            return this;
        }
        
        public VisualElementBuilder SetAlignItems(Align align)
        {
            Root.style.alignItems = align;
            return this;
        }
        
        public VisualElementBuilder SetAlignContent(Align align)
        {
            Root.style.alignContent = align;
            return this;
        }
        
        public VisualElementBuilder SetFlexWrap(Wrap wrap)
        {
            Root.style.flexWrap = wrap;
            return this;
        }
        
        public VisualElementBuilder SetFlexDirection(FlexDirection direction)
        {
            Root.style.flexDirection = direction;
            return this;
        }
    }
}