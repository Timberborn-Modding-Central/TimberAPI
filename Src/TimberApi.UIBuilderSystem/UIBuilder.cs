using System;
using Bindito.Core;
using Timberborn.CoreUI;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem;

public class UIBuilder(IContainer container, VisualElementInitializer visualElementInitializer)
{
    private BaseBuilder Create(Type builderType)
    {
        var builder = (BaseBuilder)container.GetInstance(builderType);
        builder.Initialize();

        return builder;
    }

    private BaseBuilder Create(string name, Type builderType)
    {
        var builder = Create(builderType);

        builder.SetName(name);
        return builder;
    }

    public TBuilder Create<TBuilder>()
        where TBuilder : BaseBuilder
    {
        return (TBuilder)Create(typeof(TBuilder));
    }

    public TBuilder Create<TBuilder>(string name)
        where TBuilder : BaseBuilder
    {
        return (TBuilder)Create(name, typeof(TBuilder));
    }

    public VisualElement Build(Type builderType)
    {
        return Create(builderType).BuildElement();
    }

    public VisualElement Build(string name, Type builderType)
    {
        return Create(name, builderType).BuildElement();
    }

    public VisualElement Build<TBuilder>()
        where TBuilder : BaseBuilder
    {
        return Build(typeof(TBuilder));
    }

    public VisualElement Build<TBuilder>(string name)
    {
        return Build(name, typeof(TBuilder));
    }

    public TElement Build<TBuilder, TElement>()
        where TBuilder : BaseBuilder<TBuilder, TElement>
        where TElement : VisualElement, new()
    {
        return (TElement)Create(typeof(TBuilder)).BuildElement();
    }

    public TElement Build<TBuilder, TElement>(string name)
        where TBuilder : BaseBuilder<TBuilder, TElement>
        where TElement : VisualElement, new()
    {
        return (TElement)Create(name, typeof(TBuilder)).BuildElement();
    }

    public TElement Build<TElement>(Type builderType)
        where TElement : VisualElement, new()
    {
        return (TElement)Create(builderType).BuildElement();
    }

    public TElement Build<TElement>(string name, Type builderType)
        where TElement : VisualElement, new()
    {
        return (TElement)Create(name, builderType).BuildElement();
    }
    
    public VisualElement BuildAndInitialize(Type builderType)
    {
        return Create(builderType).BuildAndInitializeElement();
    }

    public VisualElement BuildAndInitialize(string name, Type builderType)
    {
        return Create(name, builderType).BuildAndInitializeElement();
    }

    public VisualElement BuildAndInitialize<TBuilder>()
        where TBuilder : BaseBuilder
    {
        return BuildAndInitialize(typeof(TBuilder));
    }

    public VisualElement BuildAndInitialize<TBuilder>(string name)
    {
        return BuildAndInitialize(name, typeof(TBuilder));
    }

    public TElement BuildAndInitialize<TBuilder, TElement>()
        where TBuilder : BaseBuilder<TBuilder, TElement>
        where TElement : VisualElement, new()
    {
        return (TElement)Create(typeof(TBuilder)).BuildAndInitializeElement();
    }

    public TElement BuildAndInitialize<TBuilder, TElement>(string name)
        where TBuilder : BaseBuilder<TBuilder, TElement>
        where TElement : VisualElement, new()
    {
        return (TElement)Create(name, typeof(TBuilder)).BuildAndInitializeElement();
    }

    public TElement BuildAndInitialize<TElement>(Type builderType)
        where TElement : VisualElement, new()
    {
        return (TElement)Create(builderType).BuildAndInitializeElement();
    }

    public TElement BuildAndInitialize<TElement>(string name, Type builderType)
        where TElement : VisualElement, new()
    {
        return (TElement)Create(name, builderType).BuildAndInitializeElement();
    }

    public void Initialize(VisualElement element)
    {
        visualElementInitializer.InitializeVisualElement(element);
    }
}