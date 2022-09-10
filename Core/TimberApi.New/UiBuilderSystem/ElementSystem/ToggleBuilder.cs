using System;
using TimberApi.New.ModAssetSystem;
using TimberApi.New.UiBuilderSystem.PresetSystem;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;
using LocalizableToggle = TimberApi.New.UiBuilderSystem.CustomElements.LocalizableToggle;

namespace TimberApi.New.UiBuilderSystem.ElementSystem
{
    public class ToggleBuilder : BaseElementBuilder<LocalizableToggle, ToggleBuilder>, ITextElementBuilder<ToggleBuilder>
    {
        private readonly VisualElementBuilder _toggleElementBuilder;

        public ToggleBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory) : base(new LocalizableToggle(), visualElementInitializer,
            assetLoader, uiPresetFactory)
        {
            Root.style.color = Color.white;
            _toggleElementBuilder = new VisualElementBuilder(visualElementInitializer, assetLoader, uiPresetFactory, Root.Q<VisualElement>("unity-checkmark"));
        }

        protected override ToggleBuilder BuilderInstance => this;

        public ToggleBuilder SetText(string text)
        {
            Root.text = text;
            return this;
        }

        public ToggleBuilder SetLocKey(string key)
        {
            Root.TextLocKey = key;
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
    }
}