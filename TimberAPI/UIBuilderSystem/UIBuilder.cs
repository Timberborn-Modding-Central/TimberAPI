using Timberborn.AssetSystem;
using Timberborn.CoreUI;
using TimberbornAPI.UIBuilderSystem.PresetSystem;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem
{
    public class UIBuilder
    {
        private readonly VisualElementInitializer _visualElementInitializer;
        
        private readonly IResourceAssetLoader _resourceAssetLoader;
        
        private readonly ComponentBuilder _componentBuilder;

        public UIBuilder(ComponentBuilder componentBuilder, IResourceAssetLoader resourceAssetLoader, VisualElementInitializer visualElementInitializer)
        {
            _componentBuilder = componentBuilder;
            _resourceAssetLoader = resourceAssetLoader;
            _visualElementInitializer = visualElementInitializer;
        }
        
        public UIBoxBuilder CreateBoxBuilder()
        {
            return new UIBoxBuilder(_componentBuilder, _resourceAssetLoader);
        }
        
        public UIFragmentBuilder CreateFragmentBuilder()
        {
            return new UIFragmentBuilder(_componentBuilder);
        }
        
        public ComponentBuilder CreateComponentBuilder()
        {
            return _componentBuilder;
        }
        
        public UiPresetFactory Presets()
        {
            return new UiPresetFactory(_componentBuilder);
        }
        
        public void InitializeVisualElement(VisualElement visualElement)
        {
            _visualElementInitializer.InitializeVisualElement(visualElement);
        }
    }
}