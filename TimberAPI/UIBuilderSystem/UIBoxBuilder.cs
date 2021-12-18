using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Timberborn.CoreUI;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using TimberbornAPI.UIBuilderSystem.PresetSystem;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberbornAPI.UIBuilderSystem
{
    public class UIBoxBuilder
    {
        private readonly VisualElementBuilder _wrapper;

        private readonly VisualElementBuilder _box;

        private readonly VisualElementBuilder _scrollView;

        public UIBoxBuilder(ComponentBuilder componentBuilder)
        {
            _wrapper = componentBuilder.CreateVisualElement();
            _box = componentBuilder.CreateVisualElement()
                .AddClass(TimberApiStyle.Backgrounds.BorderTransparent)
                .AddClass(TimberApiStyle.Scales.Scale5);
            _scrollView = componentBuilder.CreateVisualElement();
        }

        public UIBoxBuilder SetBoxInCenter()
        {
            _wrapper
                .SetJustifyContent(Justify.Center)
                .SetAlignItems(Align.Center)
                .SetFlexDirection(FlexDirection.Row)
                .SetFlexWrap(Wrap.Wrap)
                .SetStyle(style => style.flexGrow = 1);
            return this;
        }

        public UIBoxBuilder SetHeight(Length height)
        {
            _box.SetHeight(height);
            return this;
        }

        public UIBoxBuilder SetWidth(Length width)
        {
            _box.SetWidth(width);
            return this;
        }

        public UIBoxBuilder AddComponent(Action<VisualElementBuilder> builder)
        {
            _scrollView.AddComponent(builder);
            return this;
        }

        public UIBoxBuilder AddComponent(VisualElement element)
        {
            _scrollView.AddComponent(element);
            return this;
        }

        public UIBoxBuilder AddPreset(Func<UiPresetFactory, VisualElement> presetFactory)
        {
            _scrollView.AddPreset(presetFactory);
            return this;
        }
        
        public UIBoxBuilder AddCloseButton(string name = null)
        {
            _box.AddPreset(factory => factory.Buttons().Close(null, builder: builder => builder.SetStyle(style =>
            {
                style.position = Position.Absolute;
                style.alignSelf = Align.FlexEnd;
            })));
            return this;
        }

        public UIBoxBuilder ModifyWrapper(Action<VisualElementBuilder> builder)
        {
            builder.Invoke(_wrapper);
            return this;
        }

        public UIBoxBuilder ModifyBox(Action<VisualElementBuilder> builder)
        {
            builder.Invoke(_box);
            return this;
        }

        public UIBoxBuilder ModifyScrollView(Action<VisualElementBuilder> builder)
        {
            builder.Invoke(_scrollView);
            return this;
        }

        public VisualElement Build()
        {
            return _wrapper.AddComponent(_box.AddComponent(_scrollView.Build()).Build()).BuildAndInitialize();
        }

        public VisualElement BuildAndInitialize()
        {
            return _wrapper.AddComponent(_box.AddComponent(_scrollView.Build()).Build()).BuildAndInitialize();
        }
    }
}