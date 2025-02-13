using Bindito.Core;

namespace TimberApi.UIPresets.Toggles;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class TogglePresetConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<GameToggle>().AsTransient();
        Bind<GameTextToggle>().AsTransient();
        
        Bind<SettingToggle>().AsTransient();
        Bind<SettingTextToggle>().AsTransient();
    }
}