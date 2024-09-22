using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.CustomElements;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine;
using UnityEngine.UIElements;
using Overflow = TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums.Overflow;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;
using WhiteSpace = TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums.WhiteSpace;

namespace TimberApi.UIPresets.Toggles;

public class GameToggle : GameToggle<GameToggle>
{
    protected override GameToggle BuilderInstance => this;
}

public abstract class GameToggle<TBuilder> : BaseBuilder<TBuilder, LocalizableToggle>
    where TBuilder : BaseBuilder<TBuilder, LocalizableToggle>
{
    protected LocalizableToggleBuilder ToggleBuilder = null!;

    protected string SizeClass = "api__toggle--size-normal";
        
    protected string ImageClass = "api__toggle--normal";
    
    public TBuilder SetLocKey(string locKey)
    {
        ToggleBuilder.SetLocKey(locKey);
        return BuilderInstance;
    }
    
    public TBuilder Small()
    {
        SizeClass = "api__toggle--size-small";
        return BuilderInstance;
    }
    
    public TBuilder Size(Length size)
    {
        var checkmark = Root.Q<VisualElement>("unity-checkmark");
        checkmark.style.width = size;
        checkmark.style.height = size;
        return BuilderInstance;
    }
    
    public TBuilder Inverted()
    {
        ImageClass = "api__toggle--inverted";
        return BuilderInstance;
    }

    protected override LocalizableToggle InitializeRoot()
    {
        ToggleBuilder = UIBuilder.Create<LocalizableToggleBuilder>()
            .AddClass("api__toggle");

        return ToggleBuilder.Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__toggle", builder => builder
                .ClickSound("UI.Click")
                .Overflow(Overflow.Visible)
            )
            .AddSelector(".api__toggle > .unity-toggle__input > .unity-toggle__text", builder => builder
                .Color(new Color(0.8f, 0.8f, 0.8f))
                .WhiteSpace(WhiteSpace.Normal)
                .FontSize(13)
            )
            .AddSelector(".api__toggle--size-small > .unity-toggle__input > .unity-toggle__text", builder => builder
                .FontSize(12)
            )
            .AddSelector(".api__toggle--normal > .unity-toggle__input > .unity-toggle__checkmark", builder => builder
                .BackgroundImage("UI/Images/Buttons/empty-inverted")
                .MarginRight(4)
            )
            .AddSelector(".api__toggle--inverted > .unity-toggle__input > .unity-toggle__checkmark", builder => builder
                .BackgroundImage("UI/Images/Buttons/empty")
                .MarginRight(4)
            )
            .AddSelector(".api__toggle--normal > .unity-toggle__input:checked > .unity-toggle__checkmark", builder => builder
                .BackgroundImage("UI/Images/Buttons/checkmark-inverted")
            )
            .AddSelector(".api__toggle--inverted > .unity-toggle__input:checked > .unity-toggle__checkmark", builder => builder
                .BackgroundImage("UI/Images/Buttons/checkmark")
            )
            .AddSelector(".api__toggle > .unity-toggle__input:hover:enabled > .unity-toggle__checkmark", builder =>
                builder
                    .BackgroundImage("UI/Images/Buttons/empty-hover")
            )
            .AddSelector(".api__toggle > .unity-toggle__input:checked:hover:enabled > .unity-toggle__checkmark",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/checkmark-hover")
            )
            .AddSelector(".api__toggle--size-normal > .unity-toggle__input > .unity-toggle__checkmark",
                builder => builder
                    .Width(20)
                    .Height(20)
            )
            .AddSelector(".api__toggle--size-small > .unity-toggle__input > .unity-toggle__checkmark",
                builder => builder
                    .Width(15)
                    .Height(15)
            );
    }

    public override LocalizableToggle Build()
    {
        return ToggleBuilder
            .AddClass(SizeClass)
            .AddClass(ImageClass)
            .Build();
    }
    
    public TBuilder AddClass(string styleClass)
    {
        ToggleBuilder.AddClass(styleClass);
        return BuilderInstance;
    }

    public TBuilder ModifyRoot(Action<LocalizableToggleBuilder> toggleBuilder)
    {
        toggleBuilder.Invoke(ToggleBuilder);
        return BuilderInstance;
    }
}