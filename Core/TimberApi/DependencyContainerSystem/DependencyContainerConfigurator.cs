using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace TimberApi.DependencyContainerSystem
{
    [Configurator(SceneEntrypoint.All)]
    internal class DependencyContainerConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<DependencyContainerSetter>().AsSingleton();
        }
    }
}