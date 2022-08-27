using Bindito.Core;
using TimberApi.Core.BootstrapSystem;
using TimberApi.Internal.AssetSystem;
using TimberApi.Internal.ConfiguratorSystem;

namespace TimberApi.Internal
{
    public class BootstrapConfigurator : ITimberApiEntryConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<TimberApiInternal>().AsSingleton();
            containerDefinition.Install(new ConfiguratorSystemConfigurator());
            containerDefinition.Install(new AssetSystemConfigurator());
        }
    }
}
