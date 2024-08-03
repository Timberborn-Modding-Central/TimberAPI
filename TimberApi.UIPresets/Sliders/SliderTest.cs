using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Sliders;

public class SliderTest : BaseBuilder<LocalizableSliderInt>
{
    protected override LocalizableSliderInt InitializeRoot()
    {
        return UIBuilder.Create<SliderIntBuilder>()
            .AddClass("api__slider_circle")
            .SetLabelLocKey("AAAAAAAAA")
            .SetLowValue(1)
            .SetHighValue(100)
            .Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder.AddClass("api__slider_circle", builder => builder.Add(Property.FlexGrow, 1));

        styleSheetBuilder.AddSelector(".api__slider_circle > .unity-slider-int__label", builder => builder
            .Color(new Color(0.5f, 0.5f, 0.5f))
            .FontSize(13)
            .PaddingRight(13)
            .UnityTextAlign(UnityTextAlign.MiddleRight)
            .MinWidth(0)
        );

        styleSheetBuilder.AddSelector(
            ".api__slider_circle > .unity-slider-int__input > .unity-base-slider__drag-container > .unity-base-slider__dragger",
            builder => builder
                .BackgroundImage("UI/Images/Buttons/circle-off")
                .Height(16)
                .Width(16)
                .MarginTop(-7)
        );

        styleSheetBuilder.AddSelector(
            ".api__slider_circle > .unity-slider-int__input > .unity-base-slider__drag-container > .unity-base-slider__dragger:hover:enabled",
            builder => builder.BackgroundImage("UI/Images/Buttons/circle-hover")
        );

        styleSheetBuilder.AddSelector(
            ".api__slider_circle > .unity-slider-int__input > .unity-base-slider__drag-container:hover:enabled:active > .unity-base-slider__dragger",
            builder => builder.BackgroundImage("UI/Images/Buttons/circle-on")
        );

        styleSheetBuilder.AddSelector(
            ".api__slider_circle > .unity-slider-int__input > .unity-base-slider__drag-container > .unity-base-slider__tracker",
            builder => builder
                .BackgroundImage("UI/Images/Backgrounds/bg-pixel-2")
                .UnityBackgroundScaleMode(UnityBackgroundScaleMode.StretchToFill)
                .Height(2)
        );
    }
}