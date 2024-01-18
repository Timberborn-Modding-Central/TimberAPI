using System;
using TimberApi.UiBuilderSystem.ElementSystem;
using TimberApi.UiBuilderSystem.PresetSystem;
using Timberborn.AssetSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

#pragma warning disable CS8625

namespace TimberApi.UiBuilderSystem
{
    public class UIBoxBuilder
    {
        private readonly VisualElementBuilder _box;

        private readonly VisualElementBuilder _centerWrapper;
        private readonly IResourceAssetLoader _resourceAssetLoader;

        private readonly VisualElementBuilder _scrollView;

        private readonly VisualElementBuilder _wrapper;

        public UIBoxBuilder(ComponentBuilder componentBuilder, IResourceAssetLoader resourceAssetLoader)
        {
            _resourceAssetLoader = resourceAssetLoader;
            _wrapper = componentBuilder.CreateVisualElement();
            _centerWrapper = componentBuilder.CreateVisualElement();
            _box = componentBuilder.CreateVisualElement().AddClass(TimberApiStyle.Backgrounds.BorderTransparent).AddClass(TimberApiStyle.Scales.Scale5).SetPadding(new Length(45, Pixel));
            _scrollView = componentBuilder.CreateVisualElement();
        }

        public UIBoxBuilder SetBoxInCenter()
        {
            _centerWrapper.SetJustifyContent(Justify.Center).SetAlignItems(Align.Center).SetFlexDirection(FlexDirection.Row).SetFlexWrap(Wrap.Wrap).SetStyle(style => style.flexGrow = 1);
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
// // Old, lacks ability to be extended easily, specially with complex components
// _box.AddPreset(test => test.Sliders().SliderDiamond(10, 100, builder: builder => builder.SetLowValue(10).SetHighValue(100)));
//
// // New option 1, There is no way to make the options discoverable by which preset type they belong (slider, buttons, etc)
// // Builder Func would still be available here, eg. builder => builder.SetLowValue(10)
// _box.AddPreset("SliderDiamond", new SliderOptions(10, 100)); // Diamond slider with a value of min: 10, max: 100
// _box.AddPreset("Button", new ButtonOptions("text.locKey", 10, 10)); // locKey, height, width
//
// // New option 2, other option
// _box.AddPreset("SliderDiamond", builder => builder.SetLowValue(10).SetHighValue(100));
// _box.AddPreset("SliderDiamond", builder => builder.SetLocKey(10).SetHeight(10).SetWidth(10));
//
// // Wish I was possible. or something similar
// _box.AddPreset("SliderDiamond", 10, 100); // Diamond slider with a value of min: 10, max: 100
// _box.AddPreset("Button", "text.locKey", 10, 10); // locKey, height, width

  
            
            _box.AddPreset(factory => factory.Buttons().Close(name, builder: builder => builder.SetStyle(style =>
            {
                style.position = Position.Absolute;
                style.right = new Length(-3, Pixel);
                style.top = new Length(-3, Pixel);
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
            }).SetPadding(new Padding(new Length(20, Pixel), new Length(0, Pixel))).AddPreset(factory => factory.Labels().Label(locKey, new Length(18, Pixel), Color.white, text: text, name: name)));
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