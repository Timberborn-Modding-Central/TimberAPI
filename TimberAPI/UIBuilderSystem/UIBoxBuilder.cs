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
        private readonly ComponentBuilder _componentBuilder;

        private readonly VisualElementBuilder _root;
        
        public UIBoxBuilder(ComponentBuilder componentBuilder)
        {
            _componentBuilder = componentBuilder;
            _root = _componentBuilder.CreateVisualElement();
        }
        
        public UIBoxBuilder AddComponents(Action<VisualElementBuilder> builder)
        {
            _root.AddComponent(builder);
            return this;
        }

        public VisualElement Build()
        {
            return _root.AddClass(TimberApiStyle.Backgrounds.BorderTransparent).SetHeight(500).SetWidth(500).Build();
        }
    }
}