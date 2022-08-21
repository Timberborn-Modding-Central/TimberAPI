using Bindito.Core;

namespace TimberApi.Internal.ConfiguratorSystem
{
    public class ConfiguratorConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ConfiguratorRepository>().AsSingleton();
        }
    }
}