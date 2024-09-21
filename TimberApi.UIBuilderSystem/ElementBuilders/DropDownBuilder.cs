using Timberborn.DropdownSystem;

namespace TimberApi.UIBuilderSystem.ElementBuilders;

public class DropDownBuilder : BaseElementBuilder<DropDownBuilder, Dropdown>
{
    protected override DropDownBuilder BuilderInstance => this;
    
    protected override Dropdown InitializeRoot()
    {
        return new Dropdown();
    }
}