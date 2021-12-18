using Timberborn.CoreUI;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using TimberbornAPI.UIBuilderSystem.PresetSystem;

namespace TimberbornAPI.UIBuilderSystem
{
    public class ComponentBuilder
    {
        private readonly VisualElementInitializer _visualElementInitializer;

        private readonly IAssetLoader _assetLoader;

        private readonly UiPresetFactory _uiPresetFactory;
        
        public ComponentBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader)
        {
            _visualElementInitializer = visualElementInitializer;
            _assetLoader = assetLoader;
            _uiPresetFactory = new UiPresetFactory(this);
        }
        
        public ButtonBuilder CreateButton()
        {
            return new ButtonBuilder(_visualElementInitializer, _assetLoader);
        }
        
        public VisualElementBuilder CreateVisualElement()
        {
            return new VisualElementBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
        }
    }
}