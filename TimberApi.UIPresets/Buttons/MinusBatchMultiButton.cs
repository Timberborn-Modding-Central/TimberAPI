using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons;

public class MinusBatchMultiButton : MinusBatchMultiButton<MinusBatchMultiButton>
{
    protected override MinusBatchMultiButton BuilderInstance => this;
}

public abstract class MinusBatchMultiButton<TBuilder> : BaseBuilder<TBuilder, Button>
    where TBuilder : BaseBuilder<TBuilder, Button>
{
    protected ButtonBuilder ButtonBuilder = null!;

    protected string SizeClass = "api__button__minus-batch-button--size-normal";

    public TBuilder Small()
    {
        SizeClass = "api__button__minus-batch-button--size-small";
        return BuilderInstance;
    }

    public TBuilder Large()
    {
        SizeClass = "api__button__minus-batch-button--size-large";
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

        return ButtonBuilder.AddClass("api__button__minus-batch-button").Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClickSoundClass("api__button__minus-batch-button", "UI.Click")
            .AddBackgroundHoverClass("api__button__minus-batch-button", "ui/images/buttons/minus-batch-multi",
                "ui/images/buttons/minus-batch-multi-hover")
            .AddClass("api__button__minus-batch-button--size-normal", builder => builder
                .Height(20)
                .Width(20)
            )
            .AddClass("api__button__minus-batch-button--size-small", builder => builder
                .Height(18)
                .Width(18)
            )
            .AddClass("api__button__minus-batch-button--size-large", builder => builder
                .Height(24)
                .Width(24)
            );
    }

    public TBuilder ModifyRoot(Action<ButtonBuilder> buttonBuilder)
    {
        buttonBuilder.Invoke(ButtonBuilder);

        return BuilderInstance;
    }

    public override Button Build()
    {
        return ButtonBuilder
            .AddClass(SizeClass)
            .Build();
    }
}