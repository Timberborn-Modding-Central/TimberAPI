using Bindito.Core;

namespace TimberApi.Core.ConfigSystem
{
    public class ConfigSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ConfigServiceFactory>().AsSingleton();
        }
    }
}