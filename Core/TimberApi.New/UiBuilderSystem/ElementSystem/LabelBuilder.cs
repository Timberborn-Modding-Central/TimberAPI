using TimberApi.New.ModAssetSystem;
using TimberApi.New.UiBuilderSystem.PresetSystem;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;
using LocalizableLabel = TimberApi.New.UiBuilderSystem.CustomElements.LocalizableLabel;

namespace TimberApi.New.UiBuilderSystem.ElementSystem
{
    public class LabelBuilder : BaseElementBuilder<CustomElements.LocalizableLabel, LabelBuilder>, ITextElementBuilder<LabelBuilder>
    {
        protected override LabelBuilder BuilderInstance => this;

        public LabelBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory) 
            : base(new LocalizableLabel(), visualElementInitializer, assetLoader, uiPresetFactory)
        {
        }

        public LabelBuilder SetWhiteSpace(WhiteSpace whiteSpace)
        {
            Root.style.whiteSpace = whiteSpace;
            return this;
        }
        
        public LabelBuilder SetText(string text)
        {
            Root.text = text;
            return this;
        }

        public LabelBuilder SetLocKey(string key)
        {
            Root.TextLocKey = key;
            return this;
        }
        
        public LabelBuilder SetColor(StyleColor color)
        {
            Root.style.color = color;
            return this;
        }
        
        public LabelBuilder SetFontSize(Length size)
        {
            Root.style.fontSize = size;
            return this;
        }
        
        public LabelBuilder SetFontStyle(FontStyle style)
        {
            Root.style.unityFontStyleAndWeight = style;
            return this;
        }
    }
}