using Bindito.Core;
using TimberApi.New.ConfiguratorSystem;
using TimberApi.New.SceneSystem;

namespace TimberApi.New.DependencyContainer
{
    [Configurator(SceneEntrypoint.All)]
    public class DependencyContainerConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<DependencyContainerSetter>().AsSingleton();
        }
    }
}