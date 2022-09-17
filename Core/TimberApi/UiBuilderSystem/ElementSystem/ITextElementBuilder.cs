using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.UiBuilderSystem.ElementSystem
{
    public interface ITextElementBuilder<out TBuilder>
    {
        public TBuilder SetText(string text);

        public TBuilder SetLocKey(string key);

        public TBuilder SetColor(StyleColor color);

        public TBuilder SetFontSize(Length size);

        public TBuilder SetFontStyle(FontStyle style);
    }
}