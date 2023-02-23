using Bindito.Core;
using TimberApi.AssetSystem;

namespace TimberApi
{
    internal class BootstrapConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<TimberApi>().AsSingleton();
            containerDefinition.Install(new AssetSystemGlobalConfigurator());
        }
    }
}