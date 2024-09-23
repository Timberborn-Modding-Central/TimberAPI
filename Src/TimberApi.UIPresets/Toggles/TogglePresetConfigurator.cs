using Bindito.Core;

namespace TimberApi.UIPresets.Toggles;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class TogglePresetConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<GameToggle>().AsTransient();
        containerDefinition.Bind<GameTextToggle>().AsTransient();
        
        containerDefinition.Bind<SettingToggle>().AsTransient();
        containerDefinition.Bind<SettingTextToggle>().AsTransient();
    }
}