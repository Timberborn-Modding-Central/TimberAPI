using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine.UIElements;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons;

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
            .AddBackgroundHoverClass("api__button__migration-arrow-right-button",
                "ui/images/buttons/migration/right-arrow", "ui/images/buttons/migration/right-arrow-hover")
            .AddClass("api__button__migration-arrow-right-button", builder => builder
                .ClickSound("UI.Click")
                .Height(24)
                .Width(32)
            );
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