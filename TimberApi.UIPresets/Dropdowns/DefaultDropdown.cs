using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using Timberborn.DropdownSystem;
using UnityEngine.UIElements;

namespace TimberApi.UIPresets.Dropdowns;

public class DefaultDropdown : DefaultDropdown<DefaultDropdown>
{
    protected override DefaultDropdown BuilderInstance => this;
}

public abstract class DefaultDropdown<TBuilder> : BaseBuilder<TBuilder, Dropdown>
    where TBuilder : BaseBuilder<TBuilder, Dropdown>
{
    protected DropDownBuilder DropDownBuilder = null!;
    
    public void SetItems(
        IDropdownProvider dropdownProvider,
        Func<string, VisualElement> elementGetter)
    {
        Root.SetItems(dropdownProvider, elementGetter);
    } 
    
    protected override Dropdown InitializeRoot()
    {
        DropDownBuilder = UIBuilder.Create<DropDownBuilder>();

        return DropDownBuilder.Build();
    }
}