using Timberborn.AssetSystem;
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
        
        public ComponentBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, IResourceAssetLoader resourceAssetLoader)
        {
            _visualElementInitializer = visualElementInitializer;
            _assetLoader = assetLoader;
            _uiPresetFactory = new UiPresetFactory(this, resourceAssetLoader);
        }
        
        public ButtonBuilder CreateButton()
        {
            return new ButtonBuilder(_visualElementInitializer, _assetLoader);
        }
        
        public ToggleBuilder CreateToggle()
        {
            return new ToggleBuilder(_visualElementInitializer, _assetLoader);
        }
        
        public VisualElementBuilder CreateVisualElement()
        {
            return new VisualElementBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
        }
        
        public ScrollViewBuilder CreateScrollView()
        {
            return new ScrollViewBuilder(_visualElementInitializer, _assetLoader);
        }
        
        public LabelBuilder CreateLabel()
        {
            return new LabelBuilder(_visualElementInitializer, _assetLoader);
        }
        
        public SliderBuilder CreateSlider()
        {
            return new SliderBuilder(_visualElementInitializer, _assetLoader);
        }
        
        public SliderIntBuilder CreateSliderInt()
        {
            return new SliderIntBuilder(_visualElementInitializer, _assetLoader);
        }
    }
}