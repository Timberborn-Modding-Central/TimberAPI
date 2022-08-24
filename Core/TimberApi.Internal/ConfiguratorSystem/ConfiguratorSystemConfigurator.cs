using Bindito.Core;

namespace TimberApi.Internal.ConfiguratorSystem
{
    public class ConfiguratorSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ConfiguratorPatcher>().AsSingleton();
            containerDefinition.Bind<ConfiguratorRepository>().AsSingleton();
        }
    }
}