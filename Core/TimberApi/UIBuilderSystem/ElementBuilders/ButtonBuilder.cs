using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.UiBuilderSystem.ElementBuilders
{
    public class ButtonBuilder : ButtonBuilder<ButtonBuilder>
    {
        protected override ButtonBuilder BuilderInstance => this;
    }
    
    public abstract class ButtonBuilder<TBuilder> : BaseElementBuilder<LocalizableButton, TBuilder> 
        where TBuilder : BaseElementBuilder<LocalizableButton, TBuilder>
    {
        public ButtonBuilder<TBuilder> SetText(string text)
        {
            Root.text = text;
            return this;
        }

        public ButtonBuilder<TBuilder> SetLocKey(string key)
        {
            Root._textLocKey = key;
            return this;
        }

        public ButtonBuilder<TBuilder> SetColor(StyleColor color)
        {
            Root.style.color = color;
            return this;
        }

        public ButtonBuilder<TBuilder> SetFontSize(Length size)
        {
            Root.style.fontSize = size;
            return this;
        }

        public ButtonBuilder<TBuilder> SetFontStyle(FontStyle style)
        {
            Root.style.unityFontStyleAndWeight = style;
            return this;
        } 
    }
}