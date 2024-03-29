using TimberApi.AssetSystem;
using TimberApi.UiBuilderSystem.ElementSystem;
using TimberApi.UiBuilderSystem.PresetSystem;
using Timberborn.CoreUI;

namespace TimberApi.UiBuilderSystem
{
    public class ComponentBuilder
    {
        private readonly IAssetLoader _assetLoader;

        private readonly UiPresetFactory _uiPresetFactory;
        private readonly VisualElementInitializer _visualElementInitializer;

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