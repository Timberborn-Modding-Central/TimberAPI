using TimberApi.New.ModAssetSystem;
using TimberApi.New.UiBuilderSystem.ElementSystem;
using TimberApi.New.UiBuilderSystem.PresetSystem;
using Timberborn.CoreUI;

namespace TimberApi.New.UiBuilderSystem
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
            return new ButtonBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
        }
        
        public ToggleBuilder CreateToggle()
        {
            return new ToggleBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
        }
        
        public VisualElementBuilder CreateVisualElement()
        {
            return new VisualElementBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
        }
        
        public ScrollViewBuilder CreateScrollView()
        {
            return new ScrollViewBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
        }
        
        public LabelBuilder CreateLabel()
        {
            return new LabelBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
        }
        
        public SliderBuilder CreateSlider()
        {
            return new SliderBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
        }
        
        public SliderIntBuilder CreateSliderInt()
        {
            return new SliderIntBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
        }
        
        public TextFieldBuilder CreateTextField()
        {
            return new TextFieldBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
        }
        
        public ListViewBuilder CreateListView()
        {
            return new ListViewBuilder(_visualElementInitializer, _assetLoader, _uiPresetFactory);
        }
    }
}