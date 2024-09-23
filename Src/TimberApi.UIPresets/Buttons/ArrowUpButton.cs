using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine.UIElements;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons;

public class ArrowUpButton : ArrowUpButton<ArrowUpButton>
{
    protected override ArrowUpButton BuilderInstance => this;
}

public abstract class ArrowUpButton<TBuilder> : BaseBuilder<TBuilder, Button>
    where TBuilder : BaseBuilder<TBuilder, Button>
{
    protected ButtonBuilder ButtonBuilder = null!;

    protected string ImageClass = "api__button__arrow_up-button--normal";

    protected string SizeClass = "api__button__arrow_up-button--size-normal";

    public TBuilder Small()
    {
        SizeClass = "api__button__arrow_up-button--size-small";
        return BuilderInstance;
    }

    public TBuilder Large()
    {
        SizeClass = "api__button__arrow_up-button--size-large";
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
        ButtonBuilder.AddClass("api__button__arrow_up-button--active");
        return BuilderInstance;
    }

    public TBuilder Inverted()
    {
        ImageClass = "api__button__arrow_up-button--inverted";
        return BuilderInstance;
    }

    protected override Button InitializeRoot()
    {
        ButtonBuilder = UIBuilder.Create<ButtonBuilder>();

        return ButtonBuilder.AddClass("api__button__arrow_up-button").Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClickSoundClass("api__button__arrow_up-button", "UI.Click")
            .AddBackgroundClass("api__button__arrow_up-button", "ui/images/buttons/arrow-up-hover", PseudoClass.Hover)
            .AddBackgroundClass("api__button__arrow_up-button--normal", "ui/images/buttons/arrow-up")
            .AddBackgroundClass("api__button__arrow_up-button--inverted", "ui/images/buttons/arrow-up-inverted")
            .AddBackgroundClass("api__button__arrow_up-button--active", "ui/images/buttons/arrow-up-active",
                PseudoClass.Active, PseudoClass.Hover)
            .AddClass("api__button__arrow_up-button--size-normal", builder => builder
                .Height(20)
                .Width(20)
            )
            .AddClass("api__button__arrow_up-button--size-small", builder => builder
                .Height(18)
                .Width(18)
            )
            .AddClass("api__button__arrow_up-button--size-large", builder => builder
                .Height(24)
                .Width(24)
            );
    }

    public override Button Build()
    {
        return ButtonBuilder
            .AddClass(ImageClass)
            .AddClass(SizeClass)
            .Build();
    }
    
    public TBuilder AddClass(string styleClass)
    {
        ButtonBuilder.AddClass(styleClass);
        return BuilderInstance;
    }

    public TBuilder ModifyRoot(Action<ButtonBuilder> buttonBuilder)
    {
        buttonBuilder.Invoke(ButtonBuilder);
        return BuilderInstance;
    }
}