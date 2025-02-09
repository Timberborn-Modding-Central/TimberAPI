using Bindito.Core;

namespace TimberApi.UIPresets.Dropdowns;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class DropdownPresetConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<OptionDropdown>().AsTransient();
        containerDefinition.Bind<GameDropdown>().AsTransient();
    }
}