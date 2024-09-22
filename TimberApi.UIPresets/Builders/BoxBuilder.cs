using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;
using TimberApi.UIPresets.Buttons;
using TimberApi.UIPresets.Labels;
using TimberApi.UIPresets.ScrollViews;
using Timberborn.CoreUI;
using UnityEngine.UIElements;
using Position = TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums.Position;
using StyleValueType = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleValueType;

namespace TimberApi.UIPresets.Builders;

public class BoxBuilder : BoxBuilder<BoxBuilder>
{
    protected override BoxBuilder BuilderInstance => this;
}

public abstract class BoxBuilder<TBuilder> : BaseBuilder<TBuilder, NineSliceVisualElement>
    where TBuilder : BaseBuilder<TBuilder, NineSliceVisualElement>
{
    protected VisualElementBuilder VisualElementBuilder = null!;

    protected DefaultScrollView DefaultScrollView = null!;

    protected string BackgroundClass = "api__box--nontransparant";

    protected bool HasCloseButton = false;
        
    protected bool HasHeader = false;
    
    public TBuilder AddCloseButton(string name, string? styleClass = null)
    {
        if (HasCloseButton)
        {
            return BuilderInstance;
        }
        
        HasCloseButton = true;
        VisualElementBuilder.AddComponent<CloseButton>(name, builder =>
            {
                builder.AddClass("api__box-close-button");
                if (!string.IsNullOrWhiteSpace(styleClass))
                {
                    builder.AddClass(styleClass);
                }

                return builder;
            }
        );
        
        return BuilderInstance;
    }
    
    public TBuilder AddHeader(string locKey)
    {
        if (HasHeader)
        {
            return BuilderInstance;
        }
        
        HasHeader = true;
        VisualElementBuilder
            .AddClass("api__box--with-header")
            .AddComponent<GameLabel>(label => label
                .Title()
                .SetLocKey(locKey)
                .AddClass("api__box-capsule-header")
            );
        
        return BuilderInstance;
    }

    public TBuilder AddHeaderText(string text)
    {
        if (HasHeader)
        {
            return BuilderInstance;
        }
        
        HasHeader = true;
        VisualElementBuilder
            .AddClass("api__box--with-header")
            .AddComponent<GameTextLabel>(label => label
                .Title()
                .SetText(text)
                .AddClass("api__box-capsule-header")
            );
        
        return BuilderInstance;
    }
    
    public TBuilder SetWidth(Length width)
    {
        VisualElementBuilder.SetWidth(width);
        return BuilderInstance;
    }
    
    public TBuilder SetHeight(Length height)
    {
        VisualElementBuilder.SetHeight(height);
        return BuilderInstance;
    }
    
    public TBuilder AddComponent<TComponentBuilder>(string name, Func<TComponentBuilder, TComponentBuilder> builder)
        where TComponentBuilder : BaseBuilder
    {
        DefaultScrollView.AddComponent(name, builder);
        return BuilderInstance;
    }

    public TBuilder AddComponent<TComponentBuilder>(Func<TComponentBuilder, TComponentBuilder> builder)
        where TComponentBuilder : BaseBuilder
    {
        DefaultScrollView.AddComponent(builder);
        return BuilderInstance;
    }
    
    public TBuilder AddComponent<TComponentBuilder>(string name) where TComponentBuilder : BaseBuilder
    {
        DefaultScrollView.AddComponent<TComponentBuilder>(name);
        return BuilderInstance;
    }
    
    public TBuilder AddComponent<TComponentBuilder>() where TComponentBuilder : BaseBuilder
    {
        DefaultScrollView.AddComponent<TComponentBuilder>();
        return BuilderInstance;
    }
    
    public TBuilder AddComponent(string name, Type builderType)
    {
        DefaultScrollView.AddComponent(name, builderType);
        return BuilderInstance;
    }

    public TBuilder AddComponent(Type builderType)
    {
        DefaultScrollView.AddComponent(builderType);
        return BuilderInstance;
    }
    
    protected override NineSliceVisualElement InitializeRoot()
    {
        DefaultScrollView = UIBuilder.Create<DefaultScrollView>();
        
        VisualElementBuilder = UIBuilder.Create<VisualElementBuilder>()
            .AddComponent(DefaultScrollView.Build())
            .AddClass("api__box");

        return VisualElementBuilder.Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__box", builder => builder
                .Padding(45)
                .Add(Property.BackgroundSlice, 64)
                .Add(Property.BackgroundSliceScale, 0.5f)
            )
            .AddClass("api__box--with-header", builder => builder
                .MinWidth(350)
            )
            .AddClass("api__box--nontransparant", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Core/border_nontransparent",
                    StyleValueType.ResourcePath)
            )
            .AddClass("api__box--transparant", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Core/border_transparent",
                    StyleValueType.ResourcePath)
            )
            .AddClass("api__box-close-button", builder => builder
                .Position(Position.Absolute)
                .Right(-3)
                .Top(-3)
            )
            .AddClass("api__box-capsule-header", builder => builder
                .MinWidth(237)
                .Height(51)
                .NineSlicedBackgroundImage("UI/Images/Core/header", 0, 65, 0, 65, 0.5f)
                .Position(Position.Absolute)
                .UnityTextAlign(UnityTextAlign.MiddleCenter)
                .Top(-9)
                .AlignSelf(AlignSelf.Center)
                .PaddingY(25)
            );
    }

    public override NineSliceVisualElement Build()
    {
        VisualElementBuilder
            .AddClass(BackgroundClass);
        
        return VisualElementBuilder.Build();
    }
}