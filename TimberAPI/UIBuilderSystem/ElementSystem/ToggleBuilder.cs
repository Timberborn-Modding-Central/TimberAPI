using Timberborn.CoreUI;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using LocalizableToggle = TimberbornAPI.UIBuilderSystem.CustomElements.LocalizableToggle;

namespace TimberbornAPI.UIBuilderSystem.ElementSystem
{
    public class ToggleBuilder : BaseElementBuilder<LocalizableToggle, ToggleBuilder>
    {
        protected override ToggleBuilder BuilderInstance => this;
        
        public ToggleBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader) : base(new LocalizableToggle(), visualElementInitializer, assetLoader)
        {
            AddClass("tba-toggle-hide-background");
        }
    }
}