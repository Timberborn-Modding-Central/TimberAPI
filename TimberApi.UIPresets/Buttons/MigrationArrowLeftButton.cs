using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons
{
    public class MigrationArrowLeftButton : MigrationArrowLeftButton<MigrationArrowLeftButton>
    {
        protected override MigrationArrowLeftButton BuilderInstance => this;
    }
    
    public abstract class MigrationArrowLeftButton<TBuilder> : BaseBuilder<TBuilder, Button>
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
            
            return ButtonBuilder.AddClass("api__button__migration-arrow-left-button").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddBackgroundHoverClass("api__button__migration-arrow-left-button", "ui/images/buttons/migration/left-arrow", "ui/images/buttons/migration/left-arrow-hover")
                .AddClass("api__button__migration-arrow-left-button", builder => builder
                    .Add(Property.ClickSound, "UI.Click", StyleValueType.String)
                    .Add(Property.Height, new Dimension(24, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(32, Dimension.Unit.Pixel))
                );
        }
    }
}