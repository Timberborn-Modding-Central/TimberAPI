using Bindito.Core;
using TimberApi.Internal.ConfiguratorSystem;

namespace TimberApi.Core.ConfiguratorSystem
{
    public class ConfiguratorSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ConfiguratorRepository>().AsSingleton();
        }
    }
}