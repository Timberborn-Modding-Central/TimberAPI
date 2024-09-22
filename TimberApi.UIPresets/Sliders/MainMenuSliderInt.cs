using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.CustomElements;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;
using UnityEngine;
using UnityEngine.UIElements;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Sliders;

public class MainMenuSliderInt : MainMenuSliderInt<MainMenuSliderInt>
{
    protected override MainMenuSliderInt BuilderInstance => this;
}

public abstract class MainMenuSliderInt<TBuilder> : BaseBuilder<TBuilder, LocalizableSliderInt>
    where TBuilder : BaseBuilder<TBuilder, LocalizableSliderInt>
{
    protected LocalizableSliderIntBuilder SliderIntBuilder = null!;

    protected string SizeClass = "api__slider--normal";

    protected string DraggerClass = "api__slider--circle";
    
    public TBuilder SetLocKey(string locKey)
    {
        SliderIntBuilder.SetLocKey(locKey);

        return BuilderInstance;
    }
    
    public TBuilder SetHighValue(int value)
    {
        SliderIntBuilder.SetHighValue(value);

        return BuilderInstance;
    }
    
    public TBuilder SetLowValue(int value)
    {
        SliderIntBuilder.SetLowValue(value);

        return BuilderInstance;
    }
    
    public TBuilder SetWidth(Length width)
    {
        SliderIntBuilder.SetWidth(width);

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
    
    protected override LocalizableSliderInt InitializeRoot()
    {
        SliderIntBuilder = UIBuilder.Create<LocalizableSliderIntBuilder>()
            .AddClass("api__slider");

        return SliderIntBuilder.Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__slider", builder => builder.Add(Property.FlexGrow, 1))
            .AddSelector(".api__slider > .unity-slider-int__label", builder => builder
                .Color(new Color(0.8f, 0.8f, 0.8f))
                .FontSize(13)
                .PaddingRight(13)
                .UnityTextAlign(UnityTextAlign.MiddleRight)
                .MinWidth(0)
            )
            .AddSelector(
                ".api__slider--circle > .unity-slider-int__input > .unity-base-slider__drag-container > .unity-base-slider__dragger",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/circle-off")
            )
            .AddSelector(
                ".api__slider--circle > .unity-slider-int__input > .unity-base-slider__drag-container > .unity-base-slider__dragger:hover:enabled",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/circle-hover")
            )
            .AddSelector(
                ".api__slider--circle > .unity-slider-int__input > .unity-base-slider__drag-container:hover:enabled:active > .unity-base-slider__dragger",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/circle-on")
            )
            .AddSelector(
                ".api__slider--diamond > .unity-slider-int__input > .unity-base-slider__drag-container > .unity-base-slider__dragger",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/slider_holder")
            )
            .AddSelector(
                ".api__slider--diamond > .unity-slider-int__input > .unity-base-slider__drag-container > .unity-base-slider__dragger:hover:enabled",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/slider_holder_hover")
            )
            .AddSelector(
                ".api__slider--normal > .unity-slider-int__input > .unity-base-slider__drag-container > .unity-base-slider__dragger",
                builder => builder
                    .Height(25)
                    .Width(25)
                    .MarginTop(-10)
            )
            .AddSelector(
                ".api__slider--small > .unity-slider-int__input > .unity-base-slider__drag-container > .unity-base-slider__dragger",
                builder => builder
                    .Height(16)
                    .Width(16)
                    .MarginTop(-7)
            )
            .AddSelector(
                ".api__slider > .unity-slider-int__input > .unity-base-slider__drag-container > .unity-base-slider__tracker",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/slider_bar")
                    .UnityBackgroundScaleMode(UnityBackgroundScaleMode.StretchToFill)
            )
            .AddSelector(
                ".api__slider--normal > .unity-slider-int__input > .unity-base-slider__drag-container > .unity-base-slider__tracker",
                builder => builder
                    .Height(4)
            )
            .AddSelector(
                ".api__slider--small > .unity-slider-int__input > .unity-base-slider__drag-container > .unity-base-slider__tracker",
                builder => builder
                    .Height(2)
            );
    }
    
    public override LocalizableSliderInt Build()
    {
        return SliderIntBuilder
            .AddClass(SizeClass)
            .AddClass(DraggerClass)
            .Build();
    }
    
    public TBuilder AddClass(string styleClass)
    {
        SliderIntBuilder.AddClass(styleClass);
        return BuilderInstance;
    }

    public TBuilder ModifyRoot(Action<LocalizableSliderIntBuilder> sliderIntBuilder)
    {
        sliderIntBuilder.Invoke(SliderIntBuilder);
        return BuilderInstance;
    }
}