using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using Timberborn.DropdownSystem;
using UnityEngine;
using UnityEngine.UIElements;
using Display = TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums.Display;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;
using StyleValueType = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleValueType;

namespace TimberApi.UIPresets.Dropdowns;

public class OptionDropdown : OptionDropdown<OptionDropdown>
{
    protected override OptionDropdown BuilderInstance => this;
}

public abstract class OptionDropdown<TBuilder> : BaseBuilder<TBuilder, Dropdown>
    where TBuilder : BaseBuilder<TBuilder, Dropdown>
{
    protected DropDownBuilder DropDownBuilder = null!;

    protected string SizeClass = "api__settings-dropdown--normal";
    
    protected override Dropdown InitializeRoot()
    {
        DropDownBuilder = UIBuilder.Create<DropDownBuilder>();
        DropDownBuilder.SetWidth(100);
        
        DropDownBuilder.AddClass("api__settings-dropdown");

        return DropDownBuilder.Build();
    }
    
    public TBuilder SetWidth(Length width)
    {
        DropDownBuilder.SetWidth(width);
        return BuilderInstance;
    }
    
    public TBuilder Small()
    {
        SizeClass = "api__settings-dropdown--small";
        return BuilderInstance;
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddSelector(".api__settings-dropdown--normal .dropdown__selection", builder => builder
                .Height(36)
                .PaddingLeft(16)
                .PaddingRight(45)
            )
            .AddSelector(".api__settings-dropdown--small .dropdown__selection", builder => builder
                .PaddingLeft(8)
                .PaddingRight(45)
            )
            .AddSelector(".api__settings-dropdown .dropdown__selection", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Backgrounds/bg-pixel-0",
                    StyleValueType.ResourcePath)
                .BackgroundImage("UI/Images/Buttons/dropdown")
            )
            .AddSelector(".api__settings-dropdown .dropdown__arrow", builder => builder.Display(Display.None))
            .AddSelector(".api__settings-dropdown .dropdown__selectable.dropdown__selection:enabled:hover", builder =>
                builder
                    .Add(Property.NineSlicedBackgroundImage, "UI/Images/Backgrounds/bg-pixel-0",
                        StyleValueType.ResourcePath)
                    .BackgroundImage("UI/Images/Buttons/dropdown-hover"))
            .AddSelector(".api__settings-dropdown .dropdown__selection:enabled:hover .dropdown-item__text",
                builder => builder.Color(Color.black));
    }

    public override Dropdown Build()
    {
        return DropDownBuilder
            .AddClass(SizeClass)
            .Build();
    }
}