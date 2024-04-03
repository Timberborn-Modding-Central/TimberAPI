using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.UiBuilderSystem.ElementBuilders
{
    public class LabelBuilder : BaseElementBuilder<LabelBuilder, LocalizableLabel>
    {
        protected override LabelBuilder BuilderInstance => this;

        public LabelBuilder SetLocKey(string key)
        {
            Root._textLocKey = key;
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

        protected override LocalizableLabel InitializeRoot()
        {
            return new LocalizableLabel();
        }
    }
}