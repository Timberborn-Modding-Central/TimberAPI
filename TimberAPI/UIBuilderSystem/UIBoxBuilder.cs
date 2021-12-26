using System;
using Timberborn.AssetSystem;
using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using TimberbornAPI.UIBuilderSystem.PresetSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberbornAPI.UIBuilderSystem
{
    public class UIBoxBuilder
    {
        private readonly IResourceAssetLoader _resourceAssetLoader;
        
        private readonly VisualElementBuilder _centerWrapper;
        
        private readonly VisualElementBuilder _wrapper;

        private readonly VisualElementBuilder _box;

        private VisualElementBuilder _scrollView;

        public UIBoxBuilder(ComponentBuilder componentBuilder, IResourceAssetLoader resourceAssetLoader)
        {
            _resourceAssetLoader = resourceAssetLoader;
            _wrapper = componentBuilder.CreateVisualElement();
            _centerWrapper = componentBuilder.CreateVisualElement();
            _box = componentBuilder.CreateVisualElement()
                .AddClass(TimberApiStyle.Backgrounds.BorderTransparent)
                .AddClass(TimberApiStyle.Scales.Scale5)
                .SetPadding(new Length(45, Pixel));
            _scrollView = componentBuilder.CreateVisualElement();
            
        }

        public UIBoxBuilder SetBoxInCenter()
        {
            _centerWrapper
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
            _box.AddPreset(factory => factory.Buttons().Close(name, builder: builder => builder.SetStyle(style =>
            {
                style.position = Position.Absolute;
                style.alignSelf = Align.FlexEnd;
            })));
            return this;
        }
        
        public UIBoxBuilder AddHeader(string locKey = default, string text = default, string name = null)
        {
            _box.AddComponent(builder => builder.SetStyle(style =>
                {
                    style.minWidth = new Length(237, Pixel);
                    style.height = new Length(51, Pixel);
                    style.backgroundImage = new StyleBackground(_resourceAssetLoader.Load<Sprite>("Ui/Images/Core/Header"));
                    style.position = Position.Absolute;
                    style.top = new Length(-9, Pixel);
                    style.alignSelf = Align.Center;
                    style.alignItems = Align.Center;
                    style.justifyContent = Justify.Center;
                })
                .SetPadding(new Padding(new Length(20, Pixel), new Length(0, Pixel)))
                .AddPreset(factory => factory.Labels().Label(locKey, new Length(18, Pixel), Color.white, text: text, name: name)));
            return this;
        }
        
        public UIBoxBuilder ModifyCenterWrapper(Action<VisualElementBuilder> builder)
        {
            builder.Invoke(_centerWrapper);
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
            return _centerWrapper.AddComponent(_wrapper.AddComponent(_box.AddPreset(factory => factory.ScrollViews().MainScrollView(_scrollView.Build())).Build()).Build()).Build();
        }

        public VisualElement BuildAndInitialize()
        {
            return _centerWrapper.AddComponent(_wrapper.AddComponent(_box.AddPreset(factory => factory.ScrollViews().MainScrollView(_scrollView.Build())).Build()).Build()).BuildAndInitialize();
        }
    }
}