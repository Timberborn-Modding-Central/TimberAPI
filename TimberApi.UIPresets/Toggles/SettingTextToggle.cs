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

public class SettingTextToggle : SettingTextToggle<SettingTextToggle>
{
    protected override SettingTextToggle BuilderInstance => this;
}

public abstract class SettingTextToggle<TBuilder> : BaseBuilder<TBuilder, Toggle>
    where TBuilder : BaseBuilder<TBuilder, Toggle>
{
    protected ToggleBuilder ToggleBuilder = null!;

    public TBuilder SetText(string locKey)
    {
        ToggleBuilder.SetText(locKey);
        return BuilderInstance;
    }
    
    public TBuilder Size(Length size)
    {
        var checkmark = Root.Q<VisualElement>("unity-checkmark");
        checkmark.style.width = size;
        checkmark.style.height = size;
        return BuilderInstance;
    }

    protected override Toggle InitializeRoot()
    {
        ToggleBuilder = UIBuilder.Create<ToggleBuilder>()
            .AddClass("api__setting-toggle");

        return ToggleBuilder.Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__setting-toggle", builder => builder
                .ClickSound("UI.Click")
                .Overflow(Overflow.Visible)
            )
            .AddSelector(".api__setting-toggle > .unity-toggle__input > .unity-toggle__text", builder => builder
                .Color(new Color(0.8f, 0.8f, 0.8f))
                .WhiteSpace(WhiteSpace.Normal)
                .FontSize(13)
            )
            .AddSelector(".api__setting-toggle > .unity-toggle__input > .unity-toggle__checkmark", builder => builder
                .BackgroundImage("UI/Images/Buttons/checkbox_off")
                .MarginRight(4)
                .Width(25)
                .Height(25)
            )
            .AddSelector(".api__setting-toggle > .unity-toggle__input > .unity-toggle__checkmark", builder => builder
                .BackgroundImage("UI/Images/Buttons/checkbox_off")
                .MarginRight(4)
                .Width(25)
                .Height(25)
            )
            .AddSelector(".api__setting-toggle > .unity-toggle__input:checked > .unity-toggle__checkmark", builder => builder
                .BackgroundImage("UI/Images/Buttons/checkbox_on")
            )
            .AddSelector(".api__setting-toggle > .unity-toggle__input:hover:enabled > .unity-toggle__checkmark", builder =>
                builder
                    .BackgroundImage("UI/Images/Buttons/checkbox_off_hover")
            )
            .AddSelector(".api__setting-toggle > .unity-toggle__input:checked:hover:enabled > .unity-toggle__checkmark",
                builder => builder
                    .BackgroundImage("UI/Images/Buttons/checkbox_on_hover")
            );
    }
}