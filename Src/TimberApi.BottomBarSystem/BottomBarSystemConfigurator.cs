using Bindito.Core;

namespace TimberApi.BottomBarSystem;

[Context("Game")]
public class BottomBarSystemConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<BottomBarPanel>().AsSingleton();
        containerDefinition.Bind<BottomBarUiService>().AsSingleton();
        containerDefinition.Bind<BottomBarService>().AsSingleton();
    }
}