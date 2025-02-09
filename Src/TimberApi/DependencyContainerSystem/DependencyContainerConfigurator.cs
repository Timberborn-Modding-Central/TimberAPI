using Bindito.Core;

namespace TimberApi.DependencyContainerSystem;

[Context("MainMenu")]
[Context("Game")]
[Context("MapEditor")]
public class DependencyContainerConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<DependencyContainer>().AsSingleton();
    }
}
