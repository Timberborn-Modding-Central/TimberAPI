using TimberApi.AssetSystem;
using TimberApi.UiBuilderSystem.PresetSystem;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;
using LocalizableLabel = TimberApi.UiBuilderSystem.CustomElements.LocalizableLabel;

namespace TimberApi.UiBuilderSystem.ElementSystem
{
    public class LabelBuilder : BaseElementBuilder<LocalizableLabel, LabelBuilder>, ITextElementBuilder<LabelBuilder>
    {
        public LabelBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory) : base(new LocalizableLabel(), visualElementInitializer,
            assetLoader, uiPresetFactory)
        {
        }

        protected override LabelBuilder BuilderInstance => this;

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

        public LabelBuilder SetWhiteSpace(WhiteSpace whiteSpace)
        {
            Root.style.whiteSpace = whiteSpace;
            return this;
        }
    }
}