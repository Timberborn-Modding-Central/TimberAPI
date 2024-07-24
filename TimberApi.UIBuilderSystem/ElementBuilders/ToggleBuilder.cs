using System;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.ElementBuilders
{
    public class ToggleBuilder : BaseElementBuilder<ToggleBuilder, LocalizableToggle>
    {
        private readonly VisualElementBuilder _toggleElementBuilder;
        
        // public ToggleBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader) 
        //     : base(new LocalizableToggle(), visualElementInitializer, assetLoader)
        // {
        //     Root.style.color = Color.white;
        //     
        //     //TODO: Fix this?
        //     // _toggleElementBuilder = new VisualElementBuilder(visualElementInitializer, assetLoader, Root.Q<VisualElement>("unity-checkmark"));
        // }

        protected override ToggleBuilder BuilderInstance => this;

        public ToggleBuilder SetLocKey(string key)
        {
            Root._textLocKey = key;
            return this;
        }

        public ToggleBuilder SetColor(StyleColor color)
        {
            Root.style.color = color;
            return this;
        }

        public ToggleBuilder SetFontSize(Length size)
        {
            Root.style.fontSize = size;
            return this;
        }

        public ToggleBuilder SetFontStyle(FontStyle style)
        {
            Root.style.unityFontStyleAndWeight = style;
            return this;
        }

        public ToggleBuilder ModifyCheckMarkElement(Action<VisualElementBuilder> builder)
        {
            builder.Invoke(_toggleElementBuilder);
            return this;
        }

        protected override LocalizableToggle InitializeRoot()
        {
            return new LocalizableToggle();
        }
    }
}