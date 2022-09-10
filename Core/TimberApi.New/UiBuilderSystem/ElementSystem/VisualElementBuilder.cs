using TimberApi.New.ModAssetSystem;
using TimberApi.New.UiBuilderSystem.PresetSystem;
using Timberborn.CoreUI;
using UnityEngine.UIElements;

namespace TimberApi.New.UiBuilderSystem.ElementSystem
{
    public class VisualElementBuilder : BaseElementBuilder<VisualElement, VisualElementBuilder>
    {
        public VisualElementBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory) : base(new NineSliceVisualElement(),
            visualElementInitializer, assetLoader, uiPresetFactory)
        {
        }

        public VisualElementBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory, VisualElement element) : base(element,
            visualElementInitializer, assetLoader, uiPresetFactory)
        {
        }

        protected override VisualElementBuilder BuilderInstance => this;
    }
}