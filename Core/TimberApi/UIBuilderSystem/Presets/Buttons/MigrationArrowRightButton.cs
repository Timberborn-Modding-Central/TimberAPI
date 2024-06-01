using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UiBuilderSystem.Presets.Buttons
{
    public class MigrationArrowRightButton : MigrationArrowRightButton<MigrationArrowRightButton>
    {
        protected override MigrationArrowRightButton BuilderInstance => this;
    }
    
    public abstract class MigrationArrowRightButton<TBuilder> : BaseBuilder<TBuilder, Button>
        where TBuilder : BaseBuilder<TBuilder, Button>
    {
        protected ButtonBuilder ButtonBuilder = null!;
        
        public TBuilder SetHeight(Length size)
        {
            ButtonBuilder.SetHeight(size);
            return BuilderInstance;
        }
        
        public TBuilder SetWidth(Length size)
        {
            ButtonBuilder.SetWidth(size);
            return BuilderInstance;
        }

        protected override Button InitializeRoot()
        {
            ButtonBuilder = UIBuilder.Create<ButtonBuilder>();
            
            return ButtonBuilder.AddClass("api__button__migration-arrow-right-button").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddBackgroundHoverClass("api__button__migration-arrow-right-button", "ui/images/buttons/migration/right-arrow", "ui/images/buttons/migration/right-arrow-hover")
                .AddClass("api__button__migration-arrow-right-button", builder => builder
                    .Add(Property.ClickSound, "UI.Click", StyleValueType.String)
                    .Add(Property.Height, new Dimension(24, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(32, Dimension.Unit.Pixel))
                );
        }
    }
}