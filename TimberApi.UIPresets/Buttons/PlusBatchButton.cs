using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons
{
    public class PlusBatchButton : PlusBatchButton<PlusBatchButton>
    {
        protected override PlusBatchButton BuilderInstance => this;
    }
    
    public abstract class PlusBatchButton<TBuilder> : BaseBuilder<TBuilder, Button>
        where TBuilder : BaseBuilder<TBuilder, Button>
    {
        protected ButtonBuilder ButtonBuilder = null!;
        
        protected string SizeClass = "api__button__plus-batch-button--size-normal";
        
        public TBuilder Small()
        {
            SizeClass = "api__button__plus-batch-button--size-small";
            return BuilderInstance;
        }
        
        public TBuilder Large()
        {
            SizeClass = "api__button__plus-batch-button--size-large";
            return BuilderInstance;
        }
        
        public TBuilder SetSize(Length size)
        {
            ButtonBuilder.SetHeight(size);
            ButtonBuilder.SetWidth(size);
            return BuilderInstance;
        }

        protected override Button InitializeRoot()
        {
            ButtonBuilder = UIBuilder.Create<ButtonBuilder>();
            
            return ButtonBuilder.AddClass("api__button__plus-batch-button").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClickSoundClass("api__button__plus-batch-button", "UI.Click")
                .AddBackgroundHoverClass("api__button__plus-batch-button", "ui/images/buttons/plus-batch", "ui/images/buttons/plus-batch-hover")
                .AddClass("api__button__plus-batch-button--size-normal", builder => builder
                    .Add(Property.Height, new Dimension(20, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(20, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__plus-batch-button--size-small", builder => builder
                    .Add(Property.Height, new Dimension(18, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(18, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__plus-batch-button--size-large", builder => builder
                    .Add(Property.Height, new Dimension(24, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(24, Dimension.Unit.Pixel))
                );
        }

        public override Button Build()
        {
            return ButtonBuilder
                .AddClass(SizeClass)
                .Build();
        }
    }
}