using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine;
using UnityEngine.UIElements;
using WhiteSpace = TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums.WhiteSpace;

namespace TimberApi.UIPresets.Labels;

public class GameTextLabel : GameTextLabel<GameTextLabel>
{
    protected override GameTextLabel BuilderInstance => this;
}

public abstract class GameTextLabel<TBuilder> : BaseBuilder<TBuilder, Label>
    where TBuilder : BaseBuilder<TBuilder, Label>
{
    protected LabelBuilder LabelBuilder = null!;

    protected string SizeClass = "api__game-text-label--normal";
    
    public TBuilder SetText(string text)
    {
        LabelBuilder.SetText(text);
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

    protected override Label InitializeRoot()
    {
        LabelBuilder = UIBuilder.Create<LabelBuilder>();

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
            .AddClass("api__game-text-label--title", builder => builder.FontSize(18));
    }
    
    public TBuilder ModifyRoot(Action<LabelBuilder> buttonBuilder)
    {
        buttonBuilder.Invoke(LabelBuilder);

        return BuilderInstance;
    }
    
    public override Label Build()
    {
        return LabelBuilder
            .AddClass(SizeClass)
            .Build();
    }
}