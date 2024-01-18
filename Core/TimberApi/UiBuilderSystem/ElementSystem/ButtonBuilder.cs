using TimberApi.AssetSystem;
using TimberApi.PresetSystem;
using TimberApi.PresetSystem.PresetOptions;
using TimberApi.UiBuilderSystem.PresetSystem;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;
using LocalizableButton = TimberApi.UiBuilderSystem.CustomElements.LocalizableButton;

namespace TimberApi.UiBuilderSystem.ElementSystem
{
    public class ButtonBuilderOptions : PresetOption, ISizePreset, ILocalizationPreset
    {
        public ButtonBuilderOptions(string locKey, Length? width, Length? height)
        {
            LocKey = locKey;
            Width = width;
            Height = height;
        }

        public string LocKey { get; set; }
        
        public Length? Width { get; set; }

        public Length? Height { get; set; }
    }
    
    public class ButtonBuilder : BaseElementBuilder<LocalizableButton, ButtonBuilder>, ITextElementBuilder<ButtonBuilder>
    {
        public ButtonBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory) : base(new LocalizableButton(), visualElementInitializer,
            assetLoader, uiPresetFactory)
        {
        }

        protected override ButtonBuilder BuilderInstance => this;

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