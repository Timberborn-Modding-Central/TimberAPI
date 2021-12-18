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

        public VisualElementBuilder AddComponent(Func<UiPresetFactory, VisualElement> presetFactory)
        {
            Root.Add(presetFactory.Invoke(_uiPresetFactory));
            return this;
        }
    }
}