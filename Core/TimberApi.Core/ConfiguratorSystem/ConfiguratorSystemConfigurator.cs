using Bindito.Core;

namespace TimberApi.Core.ConfiguratorSystem
{
    internal class ConfiguratorSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ConfiguratorRepository>().AsSingleton();
            containerDefinition.Bind<ConfigurationRepositorySeeder>().AsSingleton();
            containerDefinition.Bind<ConfiguratorInstaller>().AsSingleton();
        }
    }
}