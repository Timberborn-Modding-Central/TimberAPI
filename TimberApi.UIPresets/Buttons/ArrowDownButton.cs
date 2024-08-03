using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine.UIElements;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons;

public class ArrowDownButton : ArrowDownButton<ArrowDownButton>
{
    protected override ArrowDownButton BuilderInstance => this;
}

public abstract class ArrowDownButton<TBuilder> : BaseBuilder<TBuilder, Button>
    where TBuilder : BaseBuilder<TBuilder, Button>
{
    protected ButtonBuilder ButtonBuilder = null!;

    protected string ImageClass = "api__button__arrow_down-button--normal";

    protected string SizeClass = "api__button__arrow_down-button--size-normal";

    public TBuilder Small()
    {
        SizeClass = "api__button__arrow_down-button--size-small";
        return BuilderInstance;
    }

    public TBuilder Large()
    {
        SizeClass = "api__button__arrow_down-button--size-large";
        return BuilderInstance;
    }

    public TBuilder SetSize(Length size)
    {
        ButtonBuilder.SetHeight(size);
        ButtonBuilder.SetWidth(size);
        return BuilderInstance;
    }

    public TBuilder Active()
    {
        ButtonBuilder.AddClass("api__button__arrow_down-button--active");
        return BuilderInstance;
    }

    public TBuilder Inverted()
    {
        ImageClass = "api__button__arrow_down-button--inverted";
        return BuilderInstance;
    }

    protected override Button InitializeRoot()
    {
        ButtonBuilder = UIBuilder.Create<ButtonBuilder>();

        return ButtonBuilder.AddClass("api__button__arrow_down-button").Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClickSoundClass("api__button__arrow_down-button", "UI.Click")
            .AddBackgroundClass("api__button__arrow_down-button", "ui/images/buttons/arrow-down-hover",
                PseudoClass.Hover)
            .AddBackgroundClass("api__button__arrow_down-button--normal", "ui/images/buttons/arrow-down")
            .AddBackgroundClass("api__button__arrow_down-button--inverted", "ui/images/buttons/arrow-down-inverted")
            .AddBackgroundClass("api__button__arrow_down-button--active", "ui/images/buttons/arrow-down-active",
                PseudoClass.Active, PseudoClass.Hover)
            .AddClass("api__button__arrow_down-button--size-normal", builder => builder
                .Height(20)
                .Width(20)
            )
            .AddClass("api__button__arrow_down-button--size-small", builder => builder
                .Height(18)
                .Width(18)
            )
            .AddClass("api__button__arrow_down-button--size-large", builder => builder
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
            .AddClass(ImageClass)
            .AddClass(SizeClass)
            .Build();
    }
}