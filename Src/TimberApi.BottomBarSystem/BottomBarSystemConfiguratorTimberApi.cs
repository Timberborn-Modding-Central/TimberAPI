using Bindito.Core;

namespace TimberApi.BottomBarSystem;

[Context("Game")]
public class BottomBarSystemConfiguratorTimberApi : Configurator
{
    protected override void Configure()
    {
        Bind<BottomBarPanel>().AsSingleton();
        Bind<BottomBarUiService>().AsSingleton();
        Bind<BottomBarService>().AsSingleton();
    }
}