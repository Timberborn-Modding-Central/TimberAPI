using Timberborn.CoreUI;
using TimberbornAPI.UIBuilderSystem.PresetSystem;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem.ElementSystem
{
    public class VisualElementBuilder : BaseElementBuilder<VisualElement, VisualElementBuilder>
    {
        protected override VisualElementBuilder BuilderInstance => this;
        
        public VisualElementBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory) 
            : base(new NineSliceVisualElement(), visualElementInitializer, assetLoader, uiPresetFactory)
        {

        }
        
        public VisualElementBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory, VisualElement element) 
            : base(element, visualElementInitializer, assetLoader, uiPresetFactory)
        {

        }
    }
}