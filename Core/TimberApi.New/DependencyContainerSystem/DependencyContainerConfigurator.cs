using Bindito.Core;
using TimberApi.New.ConfiguratorSystem;
using TimberApi.New.SceneSystem;

namespace TimberApi.New.DependencyContainerSystem
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