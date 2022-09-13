using Bindito.Core;
using TimberApi.ConfigSystem;

namespace TimberApi.Core.ConfigSystem
{
    internal class ConfigSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IConfigServiceFactory>().To<ConfigServiceFactory>().AsSingleton();
        }
    }
}