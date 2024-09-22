using Bindito.Core;

namespace TimberApi.DependencyContainerSystem;

[Context("MainMenu")]
[Context("Game")]
[Context("MapEditor")]
public class DependencyContainerConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<DependencyContainer>().AsSingleton();
    }
}
