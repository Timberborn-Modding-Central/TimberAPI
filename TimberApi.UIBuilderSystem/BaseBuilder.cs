using Bindito.Core;
using TimberApi.DependencyContainerSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using Timberborn.CoreUI;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem;

public abstract class BaseBuilder<TBuilder, TElement> : BaseBuilder<TElement>
    where TElement : VisualElement, new()
    where TBuilder : BaseBuilder<TBuilder, TElement>
{
    protected abstract TBuilder BuilderInstance { get; }

    public new TBuilder SetName(string name)
    {
        Root.name = name;
        return BuilderInstance;
    }
}

public abstract class BaseBuilder<TElement> : BaseBuilder
    where TElement : VisualElement, new()
{
    protected TElement Root { get; private set; } = null!;

    internal override void Initialize()
    {
        Root = InitializeRoot();
        InitializeStyleSheet();
    }

    private void InitializeStyleSheet()
    {
        if (!BuilderStyleSheetCache.TryGet(GetType(), out var styleSheet))
        {
            var styleSheetBuilder = DependencyContainer.GetInstance<StyleSheetBuilder>();

            InitializeStyleSheet(styleSheetBuilder);

            styleSheet = styleSheetBuilder.Build();

            BuilderStyleSheetCache.Add(GetType(), styleSheet);
        }

        Root.styleSheets.Add(styleSheet);
    }

    internal override void SetName(string name)
    {
        Root.name = name;
    }

    protected abstract TElement InitializeRoot();

    protected virtual void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        // Builds an empty stylesheet, if the concrete builder does not use this method.
    }

    public virtual TElement Build()
    {
        return Root;
    }

    public virtual TElement BuildAndInitialize()
    {
        var element = Build();

        VisualElementInitializer.InitializeVisualElement(element);

        return element;
    }

    internal override VisualElement BuildElement()
    {
        return Build();
    }
}

public abstract class BaseBuilder
{
    protected internal BuilderStyleSheetCache BuilderStyleSheetCache = null!;

    protected UIBuilder UIBuilder = null!;
    
    protected internal VisualElementInitializer VisualElementInitializer = null!;

    internal abstract void SetName(string name);

    internal abstract void Initialize();

    [Inject]
    public void InjectDependencies(VisualElementInitializer visualElementInitializer,
        BuilderStyleSheetCache builderStyleSheetCache, UIBuilder uiBuilder)
    {
        VisualElementInitializer = visualElementInitializer;
        BuilderStyleSheetCache = builderStyleSheetCache;
        UIBuilder = uiBuilder;
    }

    internal abstract VisualElement BuildElement();

    internal VisualElement BuildAndInitializeElement()
    {
        var element = BuildElement();
        VisualElementInitializer.InitializeVisualElement(element);

        return element;
    }
}