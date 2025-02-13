using Bindito.Core;

namespace TimberApi.UIPresets.Dropdowns;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class DropdownPresetConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<OptionDropdown>().AsTransient();
        Bind<GameDropdown>().AsTransient();
    }
}