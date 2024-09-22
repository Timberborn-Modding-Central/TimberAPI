using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using Timberborn.DropdownSystem;
using UnityEngine.UIElements;

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
    
    public TBuilder SetWidth(Length width)
    {
        DropDownBuilder.SetWidth(width);
        return BuilderInstance;
    }
}