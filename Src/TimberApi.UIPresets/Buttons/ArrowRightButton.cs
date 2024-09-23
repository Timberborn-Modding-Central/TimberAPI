using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine.UIElements;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons;

public class ArrowRightButton : ArrowRightButton<ArrowRightButton>
{
    protected override ArrowRightButton BuilderInstance => this;
}

public abstract class ArrowRightButton<TBuilder> : BaseBuilder<TBuilder, Button>
    where TBuilder : BaseBuilder<TBuilder, Button>
{
    protected ButtonBuilder ButtonBuilder = null!;

    protected string ImageClass = "api__button__arrow_right-button--normal";

    protected string SizeClass = "api__button__arrow_right-button--size-normal";

    public TBuilder Small()
    {
        SizeClass = "api__button__arrow_right-button--size-small";
        return BuilderInstance;
    }

    public TBuilder Large()
    {
        SizeClass = "api__button__arrow_right-button--size-large";
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
        ButtonBuilder.AddClass("api__button__arrow_right-button--active");
        return BuilderInstance;
    }

    public TBuilder Inverted()
    {
        ImageClass = "api__button__arrow_right-button--inverted";
        return BuilderInstance;
    }

    protected override Button InitializeRoot()
    {
        ButtonBuilder = UIBuilder.Create<ButtonBuilder>();

        return ButtonBuilder.AddClass("api__button__arrow_right-button").Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClickSoundClass("api__button__arrow_right-button", "UI.Click")
            .AddBackgroundClass("api__button__arrow_right-button", "ui/images/buttons/arrow-right-hover",
                PseudoClass.Hover)
            .AddBackgroundClass("api__button__arrow_right-button--normal", "ui/images/buttons/arrow-right")
            .AddBackgroundClass("api__button__arrow_right-button--inverted", "ui/images/buttons/arrow-right-inverted")
            .AddBackgroundClass("api__button__arrow_right-button--active", "ui/images/buttons/arrow-right-active",
                PseudoClass.Active, PseudoClass.Hover)
            .AddClass("api__button__arrow_right-button--size-normal", builder => builder
                .Height(20)
                .Width(20)
            )
            .AddClass("api__button__arrow_right-button--size-small", builder => builder
                .Height(18)
                .Width(18)
            )
            .AddClass("api__button__arrow_right-button--size-large", builder => builder
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