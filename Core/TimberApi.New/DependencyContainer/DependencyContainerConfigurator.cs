using Bindito.Core;
using TimberApi.New.Common;
using TimberApi.New.ConfiguratorSystem;

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