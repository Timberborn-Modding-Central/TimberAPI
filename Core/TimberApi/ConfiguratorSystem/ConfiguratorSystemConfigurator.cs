using Bindito.Core;

namespace TimberApi.ConfiguratorSystem
{
    internal class ConfiguratorSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ConfiguratorRepository>().AsSingleton();
            containerDefinition.Bind<ConfigurationPreLoadableSingleton>().AsSingleton();
        }
    }
}