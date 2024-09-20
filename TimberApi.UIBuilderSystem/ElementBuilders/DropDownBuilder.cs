using System;
using Timberborn.DropdownSystem;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.ElementBuilders;

public class DropDownBuilder : BaseElementBuilder<DropDownBuilder, Dropdown>
{
    protected override DropDownBuilder BuilderInstance => this;
    
    public void SetItems(
        IDropdownProvider dropdownProvider,
        Func<string, VisualElement> elementGetter)
    {
        Root.SetItems(dropdownProvider, elementGetter);
    } 
    
    protected override Dropdown InitializeRoot()
    {
        return new Dropdown();
    }
}