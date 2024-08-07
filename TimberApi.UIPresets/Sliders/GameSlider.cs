using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Sliders;

public class GameSlider : GameSlider<GameSlider>
{
    protected override GameSlider BuilderInstance => this;
}

public abstract class GameSlider<TBuilder> : BaseBuilder<TBuilder, LocalizableSlider>
    where TBuilder : BaseBuilder<TBuilder, LocalizableSlider>
{
    protected LocalizableSliderBuilder SliderBuilder = null!;

    protected string SizeClass = "api__slider--normal";

    protected string DraggerClass = "api__slider--circle";
    
    public TBuilder SetLocKey(string locKey)
    {
        SliderBuilder.SetLocKey(locKey);

        return BuilderInstance;
    }
    
    public TBuilder SetHighValue(int value)
    {
        SliderBuilder.SetHighValue(value);

        return BuilderInstance;
    }
    
    public TBuilder SetLowValue(int value)
    {
        SliderBuilder.SetLowValue(value);

        return BuilderInstance;
    }
    
    public TBuilder SetWidth(Length width)
    {
        SliderBuilder.SetWidth(width);

        return BuilderInstance;
    }
    
    public TBuilder Small()
    {
        SizeClass = "api__slider--small";

        return BuilderInstance;
    }
    
    public TBuilder Diamond()
    {
        DraggerClass = "api__slider--diamond";

        return BuilderInstance;
    }
    
    protected override LocalizableSlider InitializeRoot()
    {
        SliderBuilder = UIBuilder.Create<LocalizableSliderBuilder>()
            .AddClass("api__slider");

        return SliderBuilder.Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__slider", builder => builder.Add(Property.FlexGrow, 1))
            .AddSelector(".api__slider > .unity-slider__label", builder => builder
                .Color(new Color(0.8f, 0.8f, 0.8f))
                .FontSize(13)
                .PaddingRight(13)
                .UnityTextAlign(UnityTextAlign.MiddleRight)
                .MinWidth(0)
            )
            .AddSelector(
                ".api__slider--circle > .unity-slider__input > .unity-base-slider__drag-container > .unity-base-slider__dragger",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/circle-off")
            )
            .AddSelector(
                ".api__slider--circle > .unity-slider__input > .unity-base-slider__drag-container > .unity-base-slider__dragger:hover:enabled",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/circle-hover")
            )
            .AddSelector(
                ".api__slider--circle > .unity-slider__input > .unity-base-slider__drag-container:hover:enabled:active > .unity-base-slider__dragger",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/circle-on")
            )
            .AddSelector(
                ".api__slider--diamond > .unity-slider__input > .unity-base-slider__drag-container > .unity-base-slider__dragger",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/slider_holder")
            )
            .AddSelector(
                ".api__slider--diamond > .unity-slider__input > .unity-base-slider__drag-container > .unity-base-slider__dragger:hover:enabled",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/slider_holder_hover")
            )
            .AddSelector(
                ".api__slider--normal > .unity-slider__input > .unity-base-slider__drag-container > .unity-base-slider__dragger",
                builder => builder
                    .Height(25)
                    .Width(25)
                    .MarginTop(-10)
            )
            .AddSelector(
                ".api__slider--small > .unity-slider__input > .unity-base-slider__drag-container > .unity-base-slider__dragger",
                builder => builder
                    .Height(16)
                    .Width(16)
                    .MarginTop(-7)
            )
            .AddSelector(
                ".api__slider > .unity-slider__input > .unity-base-slider__drag-container > .unity-base-slider__tracker",
                builder => builder
                    .BackgroundImage("UI/Images/Backgrounds/bg-pixel-2")
                    .UnityBackgroundScaleMode(UnityBackgroundScaleMode.StretchToFill)
            )
            .AddSelector(
                ".api__slider--normal > .unity-slider__input > .unity-base-slider__drag-container > .unity-base-slider__tracker",
                builder => builder
                    .Height(4)
            )
            .AddSelector(
                ".api__slider--small > .unity-slider__input > .unity-base-slider__drag-container > .unity-base-slider__tracker",
                builder => builder
                    .Height(2)
            );
    }
    
    public override LocalizableSlider Build()
    {
        return SliderBuilder
            .AddClass(SizeClass)
            .AddClass(DraggerClass)
            .Build();
    }
}