using TimberApi.Core2.ModAssetSystem;
using TimberApi.Internal.UiBuilderSystem.PresetSystem;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;
using LocalizableButton = TimberApi.Internal.UiBuilderSystem.CustomElements.LocalizableButton;

namespace TimberApi.Internal.UiBuilderSystem.ElementSystem
{
    public class ButtonBuilder : BaseElementBuilder<CustomElements.LocalizableButton, ButtonBuilder>, ITextElementBuilder<ButtonBuilder>
    {
        protected override ButtonBuilder BuilderInstance => this;
        
        public ButtonBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory) 
            : base(new LocalizableButton(), visualElementInitializer, assetLoader, uiPresetFactory)
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
        
        public ButtonBuilder SetColor(StyleColor color)
        {
            Root.style.color = color;
            return this;
        }
        
        public ButtonBuilder SetFontSize(Length size)
        {
            Root.style.fontSize = size;
            return this;
        }
        
        public ButtonBuilder SetFontStyle(FontStyle style)
        {
            Root.style.unityFontStyleAndWeight = style;
            return this;
        }
    }
}