using Bindito.Core;

namespace TimberApi.ResourceAssetSystem
{
    internal class ResourceAssetSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<AssetSystemConfiguratorPatcher>().AsSingleton();
        }
    }
}