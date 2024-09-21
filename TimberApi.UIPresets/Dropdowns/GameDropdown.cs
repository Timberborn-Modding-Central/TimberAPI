using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using Timberborn.DropdownSystem;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using Display = TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums.Display;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;
using StyleValueType = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleValueType;

namespace TimberApi.UIPresets.Dropdowns;

public class GameDropdown : GameDropdown<GameDropdown>
{
    protected override GameDropdown BuilderInstance => this;
}

public abstract class GameDropdown<TBuilder> : BaseBuilder<TBuilder, Dropdown>
    where TBuilder : BaseBuilder<TBuilder, Dropdown>
{
    protected DropDownBuilder DropDownBuilder = null!;
    
    protected override Dropdown InitializeRoot()
    {
        DropDownBuilder = UIBuilder.Create<DropDownBuilder>();
        return DropDownBuilder.Build();
    }
    
    public TBuilder SetWidth(float width)
    {
        DropDownBuilder.SetWidth(width);
        return BuilderInstance;
    }
}