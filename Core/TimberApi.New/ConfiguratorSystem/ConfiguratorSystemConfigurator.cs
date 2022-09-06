using Bindito.Core;

namespace TimberApi.New.ConfiguratorSystem
{
    public class ConfiguratorSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            // containerDefinition.Bind<ConfiguratorPatcher>().AsSingleton();
            containerDefinition.Bind<ConfiguratorRepository>().AsSingleton();
            containerDefinition.Bind<ConfigurationSeeder>().AsSingleton();
        }
    }
}