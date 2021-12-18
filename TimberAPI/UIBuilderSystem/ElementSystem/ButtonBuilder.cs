using Timberborn.CoreUI;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using LocalizableButton = TimberbornAPI.UIBuilderSystem.CustomElements.LocalizableButton;

namespace TimberbornAPI.UIBuilderSystem.ElementSystem
{
    public class ButtonBuilder : BaseElementBuilder<LocalizableButton, ButtonBuilder>
    {
        protected override ButtonBuilder BuilderInstance => this;
        
        public ButtonBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader) : base(new LocalizableButton(), visualElementInitializer, assetLoader)
        {
            
        }
        
        public ButtonBuilder SetText(string text)
        {
            Root.text = text;
            return this;
        }
        
        public ButtonBuilder SetLocKey(string key)
        {
            Root.TextLocKey = key;
            return this;
        }
    }
}