using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using Timberborn.CoreUI;

namespace TimberApi.UIPresets.Builders;

public class FragmentBuilder : FragmentBuilder<FragmentBuilder>
{
    protected override FragmentBuilder BuilderInstance => this;
}

public abstract class FragmentBuilder<TBuilder> : BaseBuilder<TBuilder, NineSliceVisualElement>
    where TBuilder : BaseBuilder<TBuilder, NineSliceVisualElement>
{
    protected VisualElementBuilder VisualElementBuilder = null!;

    protected string BackgroundClass = "api__fragment--background-green";
    
    public TBuilder PalePurple()
    {
        BackgroundClass = "api__fragment--background-pale-purple";
        return BuilderInstance;
    }
    
    public TBuilder Purple()
    {
        BackgroundClass = "api__fragment--background-purple";
        return BuilderInstance;
    }
    
    public TBuilder PurpleStriped()
    {
        BackgroundClass = "api__fragment--background-purple-striped";
        return BuilderInstance;
    }
    
    public TBuilder Red()
    {
        BackgroundClass = "api__fragment--background-red";
        return BuilderInstance;
    }
    
    public TBuilder RedStriped()
    {
        BackgroundClass = "api__fragment--background-red-striped";
        return BuilderInstance;
    }
    
    public TBuilder Blue()
    {
        BackgroundClass = "api__fragment--background-blue";
        return BuilderInstance;
    }
    
    public TBuilder Gray()
    {
        BackgroundClass = "api__fragment--background-gray";
        return BuilderInstance;
    }
    
    public TBuilder AddComponent<TComponentBuilder>(string name, Func<TComponentBuilder, TComponentBuilder> builder)
        where TComponentBuilder : BaseBuilder
    {
        VisualElementBuilder.AddComponent(name, builder);
        return BuilderInstance;
    }

    public TBuilder AddComponent<TComponentBuilder>(Func<TComponentBuilder, TComponentBuilder> builder)
        where TComponentBuilder : BaseBuilder
    {
        VisualElementBuilder.AddComponent(builder);
        return BuilderInstance;
    }
    
    public TBuilder AddComponent<TComponentBuilder>(string name) where TComponentBuilder : BaseBuilder
    {
        VisualElementBuilder.AddComponent<TComponentBuilder>(name);
        return BuilderInstance;
    }
    
    public TBuilder AddComponent<TComponentBuilder>() where TComponentBuilder : BaseBuilder
    {
        VisualElementBuilder.AddComponent<TComponentBuilder>();
        return BuilderInstance;
    }
    
    public TBuilder AddComponent(string name, Type builderType)
    {
        VisualElementBuilder.AddComponent(name, builderType);
        return BuilderInstance;
    }

    public TBuilder AddComponent(Type builderType)
    {
        VisualElementBuilder.AddComponent(builderType);
        return BuilderInstance;
    }
    
    protected override NineSliceVisualElement InitializeRoot()
    {
        VisualElementBuilder = UIBuilder.Create<VisualElementBuilder>()
            .AddClass("api__fragment");

        return VisualElementBuilder.Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__fragment", builder => builder
                .Padding(12)
                .Add(Property.BackgroundSlice, 9)
                .Add(Property.BackgroundSliceScale, 0.5f)
            )
            .AddClass("api__fragment--background-green", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Backgrounds/bg-3", StyleValueType.ResourcePath)
            )
            .AddClass("api__fragment--background-pale-purple", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Backgrounds/bg-1", StyleValueType.ResourcePath)
            )
            .AddClass("api__fragment--background-purple", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Backgrounds/bg-2", StyleValueType.ResourcePath)
            )            
            .AddClass("api__fragment--background-purple-striped", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Backgrounds/bg-2-striped", StyleValueType.ResourcePath)
            )
            .AddClass("api__fragment--background-red", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Backgrounds/bg-6", StyleValueType.ResourcePath)
            )
            .AddClass("api__fragment--background-red-striped", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Backgrounds/bg-6-striped", StyleValueType.ResourcePath)
            )
            .AddClass("api__fragment--background-blue", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Backgrounds/bg-7", StyleValueType.ResourcePath)
            )
            .AddClass("api__fragment--background-gray", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Backgrounds/bg-8", StyleValueType.ResourcePath)
            );
    }

    public override NineSliceVisualElement Build()
    {
        VisualElementBuilder
            .AddClass(BackgroundClass);
        
        return VisualElementBuilder.Build();
    }
}