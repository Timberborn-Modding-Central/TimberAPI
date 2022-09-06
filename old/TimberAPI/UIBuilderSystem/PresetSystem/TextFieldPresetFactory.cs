using System;
using Timberborn.CoreUI;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem.PresetSystem
{
    public class TextFieldPresetFactory
    {
        private readonly ComponentBuilder _componentBuilder;

        public TextFieldPresetFactory(ComponentBuilder componentBuilder)
        {
            _componentBuilder = componentBuilder;
            
        }

        public NineSliceTextField InGameTextField(Length width, Length height = default, bool isMultiLine = false, Length fontSize = default , Color fontColor = default, StyleColor backgroundColor = default, string name = null, Action<TextFieldBuilder> builder = default)
        {
            TextFieldBuilder textFieldBuilder = _componentBuilder.CreateTextField()
                .SetName(name)
                .SetWidth(width)
                .SetMultiLine(isMultiLine)
                .SetStyle(style =>
                {
                    style.color = fontColor == default ? Color.white : fontColor;
                    style.backgroundColor = backgroundColor == default ? new Color(0.14f, 0.2f, 0.16f) : backgroundColor;
                });

            if(height != default)
                textFieldBuilder.SetHeight(height);
            if(fontSize != default)
                textFieldBuilder.SetStyle(style => style.fontSize = fontSize);
            builder?.Invoke(textFieldBuilder);
            return textFieldBuilder.Build();
        }

    }
}