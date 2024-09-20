using Bindito.Core;
using TimberApi.UIPresets.ListViews;

namespace TimberApi.UIPresets.Dropdowns;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class DropdownPresetConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<DefaultDropdown>().AsTransient();
    }
}