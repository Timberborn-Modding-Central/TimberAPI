using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Timberborn.AssetSystem;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberbornAPI.UIBuilderSystem.PresetSystem
{
    public class ScrollPresetFactory
    {
        private readonly ComponentBuilder _componentBuilder;
        
        private readonly IResourceAssetLoader _resourceAssetLoader;

        public ScrollPresetFactory(ComponentBuilder componentBuilder, IResourceAssetLoader resourceAssetLoader)
        {
            _componentBuilder = componentBuilder;
            _resourceAssetLoader = resourceAssetLoader;
        }
        
        public ScrollView MainScrollView(IEnumerable<VisualElement> children, string name = null, Length height = default, Length width = default, Action<ScrollViewBuilder> builder = default)
        {
            return MainScrollView(name, height, width, builder + (viewBuilder => viewBuilder.AddChildren(children)));
        }
        
        public ScrollView MainScrollView(VisualElement child, string name = null, Length height = default, Length width = default, Action<ScrollViewBuilder> builder = default)
        {
            return MainScrollView(name, height, width, builder + (viewBuilder => viewBuilder.AddChild(child)));
        }

        [SuppressMessage("", "Publicizer001")]
        public ScrollView MainScrollView(string name = null, Length height = default, Length width = default, Action<ScrollViewBuilder> builder = default)
        {
            ScrollViewBuilder scrollView = _componentBuilder.CreateScrollView()
                .SetName(name)
                .ModifyVerticalScroller(scroller =>
                {
                    scroller.slider.dragElement.style.minHeight = new Length(60, Pixel);
                    scroller.slider.dragElement.style.maxHeight = new Length(60, Pixel);
                    scroller.slider.dragElement.style.backgroundImage =
                        new StyleBackground(_resourceAssetLoader.Load<Sprite>("Ui/Images/Core/Scroll_button"));
                    scroller.slider.style.backgroundImage =
                        new StyleBackground(_resourceAssetLoader.Load<Sprite>("Ui/Images/Core/Scroll_bar"));
                    scroller.slider.style.unityBackgroundScaleMode = new StyleEnum<ScaleMode>(ScaleMode.StretchToFill);
                });
            
            if(height != default)
                scrollView.SetHeight(height);
            
            if(width != default)
                scrollView.SetWidth(height);
            
            builder?.Invoke(scrollView);
            return scrollView.Build();
        }
    }
}