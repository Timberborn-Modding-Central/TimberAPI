using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.ScrollViews;

public class DefaultScrollView : DefaultScrollView<DefaultScrollView>
{
    protected override DefaultScrollView BuilderInstance => this;
}

public abstract class DefaultScrollView<TBuilder> : BaseBuilder<TBuilder, ScrollView>
    where TBuilder : BaseBuilder<TBuilder, ScrollView>
{
    protected ScrollViewBuilder ScrollViewBuilder = null!;

    public TBuilder SetMaxWidth(float width)
    {
        ScrollViewBuilder.SetMaxWidth(width);
        return BuilderInstance;
    }
    
    public TBuilder SetMaxHeight(float height)
    {
        ScrollViewBuilder.SetMaxHeight(height);
        return BuilderInstance;
    }
    
    public TBuilder AddComponent<TComponentBuilder>(string name, Func<TComponentBuilder, TComponentBuilder> builder)
        where TComponentBuilder : BaseBuilder
    {
        ScrollViewBuilder.AddComponent(name, builder);
        return BuilderInstance;
    }

    public TBuilder AddComponent<TComponentBuilder>(Func<TComponentBuilder, TComponentBuilder> builder)
        where TComponentBuilder : BaseBuilder
    {
        ScrollViewBuilder.AddComponent(builder);
        return BuilderInstance;
    }
    
    public TBuilder AddComponent<TComponentBuilder>(string name) where TComponentBuilder : BaseBuilder
    {
        ScrollViewBuilder.AddComponent<TComponentBuilder>(name);
        return BuilderInstance;
    }
    
    public TBuilder AddComponent<TComponentBuilder>() where TComponentBuilder : BaseBuilder
    {
        ScrollViewBuilder.AddComponent<TComponentBuilder>();
        return BuilderInstance;
    }
    
    public TBuilder AddComponent(string name, Type builderType)
    {
        ScrollViewBuilder.AddComponent(name, builderType);
        return BuilderInstance;
    }

    public TBuilder AddComponent(Type builderType)
    {
        ScrollViewBuilder.AddComponent(builderType);
        return BuilderInstance;
    }
    
    protected override ScrollView InitializeRoot()
    {
        ScrollViewBuilder = UIBuilder.Create<ScrollViewBuilder>()
            .AddClass("api__default-scroll-view");
        
        return ScrollViewBuilder.Build();
    }
    
    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__default-scroll-view", builder => builder
                .FlexGrow(1)
            )
            .AddSelector(".api__default-scroll-view .unity-scroll-view__content-and-vertical-scroll-container > .unity-scroll-view__content-viewport", builder => builder
                .PaddingX(3)
            )
            .AddSelector(
                ".api__default-scroll-view .unity-scroll-view__content-and-vertical-scroll-container > .unity-scroller > .unity-slider",
                builder => builder
                    .Width(20)
                    .MinWidth(20)
            )
            .AddSelector(
                ".api__default-scroll-view .unity-scroll-view__content-and-vertical-scroll-container > .unity-scroller > .unity-slider .unity-base-slider__dragger",
                builder => builder
                    .MinHeight(58)
                    .Left(2)
            )
            .AddSelector(".api__default-scroll-view .scroll-view__nine-slice-dragger", builder => builder
                .NineSlicedBackgroundImage("UI/Images/Core/scroll-button-nine-slice", 14, 0.5f)
                .Width(100, Dimension.Unit.Percent)
                .Height(100, Dimension.Unit.Percent)
            )
            .AddSelector(".api__default-scroll-view .scroll-view__nine-slice-tracker", builder => builder
                .NineSlicedBackgroundImage("UI/Images/Core/scroll-bar-nine-slice", 16, 0, 16, 0, 0.5f)
                .Width(100, Dimension.Unit.Percent)
                .Height(100, Dimension.Unit.Percent)
            )
            .AddSelector(".api__default-scroll-view .scroll-view__nine-slice-dragger:hover", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Core/scroll-button-nine-slice-highlight",
                    UIBuilderSystem.StyleSheetSystem.StyleValueType.ResourcePath)
            )
            .AddSelector(
                ".api__default-scroll-view .unity-base-slider__drag-container:active .scroll-view__nine-slice-dragger",
                builder => builder
                    .Add(Property.NineSlicedBackgroundImage, "UI/Images/Core/scroll-button-nine-slice-highlight",
                        UIBuilderSystem.StyleSheetSystem.StyleValueType.ResourcePath)
            );
    }
}