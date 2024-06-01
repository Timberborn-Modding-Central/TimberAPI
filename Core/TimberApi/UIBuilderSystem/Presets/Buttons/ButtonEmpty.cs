using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UiBuilderSystem.Presets.Buttons
{
    public class ButtonEmpty : ButtonEmpty<ButtonEmpty>
    {
        protected override ButtonEmpty BuilderInstance => this;
    }
    
    public abstract class ButtonEmpty<TBuilder> : BaseBuilder<TBuilder, NineSliceButton>
        where TBuilder : BaseBuilder<TBuilder, NineSliceButton>
    {
        protected ButtonBuilder ButtonBuilder = null!;
        
        protected string ImageClass = "api__button__button-empty--normal";
        
        public TBuilder Red()
        {
            ImageClass = "api__button__button-empty--red";
            return BuilderInstance;
        }
        
        public TBuilder Batch()
        {
            ImageClass = "api__button__button-empty--batch";
            return BuilderInstance;
        }
        
        public TBuilder Inverted()
        {
            ImageClass = "api__button__button-empty--inverted";
            return BuilderInstance;
        }
        
        public TBuilder Active()
        { 
            ButtonBuilder.AddClass("api__button__button-empty--active");
            return BuilderInstance;
        }
        
        public TBuilder SetWidth(Length width)
        {
            ButtonBuilder.SetWidth(width);
            return BuilderInstance;
        }
        
        public TBuilder SetHeight(Length height)
        {
            ButtonBuilder.SetHeight(height);
            return BuilderInstance;
        }
        
        protected override NineSliceButton InitializeRoot()
        {
            ButtonBuilder = UIBuilder.Create<ButtonBuilder>();
            
            return ButtonBuilder.AddClass("api__button__button-empty").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClickSoundClass("api__button__button-empty", "UI.Click")
                .AddNineSlicedBackgroundHoverClass("api__button__button-empty--normal", "ui/images/buttons/empty", "ui/images/buttons/empty-hover", 16, 0.5f)
                .AddNineSlicedBackgroundHoverClass("api__button__button-empty--red", "ui/images/buttons/empty-red", "ui/images/buttons/empty-red-hover", 16, 0.5f)
                .AddNineSlicedBackgroundHoverClass("api__button__button-empty--inverted", "ui/images/buttons/empty-inverted", "ui/images/buttons/empty-hover", 16, 0.5f)
                .AddNineSlicedBackgroundHoverClass("api__button__button-empty--batch", "ui/images/buttons/empty-batch", "ui/images/buttons/empty-batch-hover", 16, 0.5f)

                .AddNineSlicedBackgroundClass("api__button__button-empty--active", "ui/images/buttons/empty-active", 16, 0.5f, PseudoClass.Hover, PseudoClass.Active);
        }

        public override NineSliceButton Build()
        {
            return ButtonBuilder
                .AddClass(ImageClass)
                .Build();
        }
    }
}