using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using Timberborn.CoreUI;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UiBuilderSystem.Presets.Buttons
{
    public class ArrowDown : BaseBuilder<LocalizableButton>
    {
        private readonly ButtonBuilder _buttonBuilder;

        private string _standardImageClass = "api__button__arrow_down--normal";

        public ArrowDown(UIBuilder uiBuilder)
        {
            _buttonBuilder = uiBuilder.Create<ButtonBuilder>();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClass("api__button__arrow_down", builder => builder
                    .Add(Property.Width, new Dimension(100, Dimension.Unit.Pixel))
                    .Add(Property.Height, new Dimension(100, Dimension.Unit.Pixel)))
                .AddBackgroundClass("api__button__arrow_down", "ui/images/buttons/arrow-down-hover", PseudoClass.Hover)
                
                .AddBackgroundClass("api__button__arrow_down--normal", "ui/images/buttons/arrow-down")
                .AddBackgroundClass("api__button__arrow_down--inverted", "ui/images/buttons/arrow-down-inverted")
                .AddBackgroundClass("api__button__arrow_down--active", "ui/images/buttons/arrow-down-active", PseudoClass.Active, PseudoClass.Hover);
        }
        
        public ArrowDown WithActive()
        {
            _buttonBuilder.AddClass("api__button__arrow_down--active");
            
            return this;
        }
        
        public ArrowDown Inverted()
        {
            _standardImageClass = "api__button__arrow_down--inverted";
            
            return this;
        }

        protected override LocalizableButton InitializeRoot()
        {
            return _buttonBuilder.AddClass("api__button__arrow_down").Build();
        }

        public override LocalizableButton Build()
        {
            return _buttonBuilder.AddClass(_standardImageClass).Build();
        }
    }
}