using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UiBuilderSystem.Presets.Buttons
{
    public class ArrowLeft : BaseBuilder<Button>
    {
        private readonly ButtonBuilder _buttonBuilder;

        private string _imageClass = "api__button__arrow_down--normal";

        private string _sizeClass = "api__button__arrow_down--size-normal";

        public ArrowLeft(UIBuilder uiBuilder)
        {
            _buttonBuilder = uiBuilder.Create<ButtonBuilder>();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddBackgroundClass("api__button__arrow_down", "ui/images/buttons/arrow-left-hover", PseudoClass.Hover)
                .AddBackgroundClass("api__button__arrow_down--normal", "ui/images/buttons/arrow-left")
                .AddBackgroundClass("api__button__arrow_down--inverted", "ui/images/buttons/arrow-left-inverted")
                .AddBackgroundClass("api__button__arrow_down--active", "ui/images/buttons/arrow-left-active", PseudoClass.Active, PseudoClass.Hover)

                .AddClass("api__button__arrow_down--size-normal", builder => builder
                    .Add(Property.Height, new Dimension(20, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(20, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__arrow_down--size-small", builder => builder
                    .Add(Property.Height, new Dimension(18, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(18, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__arrow_down--size-large", builder => builder
                    .Add(Property.Height, new Dimension(24, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(24, Dimension.Unit.Pixel))
                );
        }
        
        public ArrowLeft Small()
        {
            _sizeClass = "api__button__arrow_down--size-small";
            return this;
        }
        
        public ArrowLeft Large()
        {
            _sizeClass = "api__button__arrow_down--size-large";
            return this;
        }
        
        public ArrowLeft SetSize(Length size)
        {
            _buttonBuilder.SetHeight(size);
            _buttonBuilder.SetWidth(size);
            return this;
        }

        public ArrowLeft Active()
        {
            _buttonBuilder.AddClass("api__button__arrow_down--active");
            return this;
        }

        public ArrowLeft Inverted()
        {
            _imageClass = "api__button__arrow_down--inverted";
            return this;
        }

        protected override Button InitializeRoot()
        {
            return _buttonBuilder.AddClass("api__button__arrow_down").Build();
        }

        public override Button Build()
        {
            return _buttonBuilder
                .AddClass(_imageClass)
                .AddClass(_sizeClass)
                .Build();
        }
    }
}