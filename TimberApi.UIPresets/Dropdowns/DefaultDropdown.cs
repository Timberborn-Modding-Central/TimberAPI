using TimberApi.UIBuilderSystem;
using Timberborn.DropdownSystem;

namespace TimberApi.UIPresets.Dropdowns;

public abstract class DefaultDropdown<TBuilder> : BaseBuilder<TBuilder, Dropdown>
    where TBuilder : BaseBuilder<TBuilder, Dropdown>
{
}