using System;
using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using TimberbornAPI.UIBuilderSystem.PresetSystem;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberbornAPI.UIBuilderSystem
{
    public class UIFragmentBuilder
    {
        private readonly VisualElementBuilder _wrapper;

        private string _backgroundClass;

        private string _scale;
        
        public UIFragmentBuilder(ComponentBuilder componentBuilder)
        {
            _wrapper = componentBuilder.CreateVisualElement();
            _backgroundClass = TimberApiStyle.Backgrounds.Bg3;
            _scale = TimberApiStyle.Scales.Scale5;
            _wrapper.SetPadding(new Padding(new Length(12, Pixel), new Length(8, Pixel)));
        }
        
        public UIFragmentBuilder SetBackground(string className)
        {
            _backgroundClass = className;
            return this;
        }
        
        public UIFragmentBuilder SetScale(string scaleClass)
        {
            _scale = scaleClass;
            return this;
        }

        public UIFragmentBuilder AddComponent(Action<VisualElementBuilder> builder)
        {
            _wrapper.AddComponent(builder);
            return this;
        }

        public UIFragmentBuilder AddComponent(VisualElement element)
        {
            _wrapper.AddComponent(element);
            return this;
        }

        public UIFragmentBuilder AddPreset(Func<UiPresetFactory, VisualElement> presetFactory)
        {
            _wrapper.AddPreset(presetFactory);
            return this;
        }
        
        public UIFragmentBuilder ModifyWrapper(Action<VisualElementBuilder> builder)
        {
            builder.Invoke(_wrapper);
            return this;
        }

        public VisualElement Build()
        {
            return _wrapper.AddClass(_scale).AddClass(_backgroundClass).Build();
        }

        public VisualElement BuildAndInitialize()
        {
            return _wrapper.AddClass(_scale).AddClass(_backgroundClass).Initialize();
        }
    }
}