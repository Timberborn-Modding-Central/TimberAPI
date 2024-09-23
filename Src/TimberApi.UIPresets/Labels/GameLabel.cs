using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.CustomElements;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;
using UnityEngine;

namespace TimberApi.UIPresets.Labels;

public class GameLabel : GameLabel<GameLabel>
{
    protected override GameLabel BuilderInstance => this;
}

public abstract class GameLabel<TBuilder> : BaseBuilder<TBuilder, LocalizableLabel>
    where TBuilder : BaseBuilder<TBuilder, LocalizableLabel>
{
    protected LocalizableLabelBuilder LabelBuilder = null!;

    protected string SizeClass = "api__game-text-label--normal";
    
    public TBuilder SetLocKey(string locKey)
    {
        LabelBuilder.SetLocKey(locKey);
        return BuilderInstance;
    }
    
    public TBuilder Small()
    {
        SizeClass = "api__game-text-label--small";
        return BuilderInstance;
    }
    
    public TBuilder Big()
    {
        SizeClass = "api__game-text-label--big";
        return BuilderInstance;
    }
    
    public TBuilder Heading()
    {
        SizeClass = "api__game-text-label--heading";
        return BuilderInstance;
    }
    
    public TBuilder Title()
    {
        SizeClass = "api__game-text-label--title";
        return BuilderInstance;
    }
    
    public TBuilder SetFontStyle(FontStyle style)
    {
        LabelBuilder.SetFontStyle(style);
        return BuilderInstance;
    }

    protected override LocalizableLabel InitializeRoot()
    {
        LabelBuilder = UIBuilder.Create<LocalizableLabelBuilder>();

        return LabelBuilder.AddClass("api__game-text-label").Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__game-text-label", builder => builder
                .WhiteSpace(WhiteSpace.Normal)
                .Color(new Color(0.8f, 0.8f, 0.8f))
            )
            .AddClass("api__game-text-label--small", builder => builder.FontSize(12))
            .AddClass("api__game-text-label--normal", builder => builder.FontSize(13))
            .AddClass("api__game-text-label--big", builder => builder.FontSize(14))
            .AddClass("api__game-text-label--heading", builder => builder.FontSize(15))
            .AddClass("api__game-text-label--title", builder => builder.FontSize(18))
            .AddClass("api__game_text-label--bold", builder => builder.UnityFontStyle(UnityFontStyle.Bold));
    }

    public override LocalizableLabel Build()
    {
        return LabelBuilder
            .AddClass(SizeClass)
            .Build();
    }
    
    public TBuilder AddClass(string styleClass)
    {
        LabelBuilder.AddClass(styleClass);
        return BuilderInstance;
    }

    public TBuilder ModifyRoot(Action<LocalizableLabelBuilder> labelBuilder)
    {
        labelBuilder.Invoke(LabelBuilder);
        return BuilderInstance;
    }
}