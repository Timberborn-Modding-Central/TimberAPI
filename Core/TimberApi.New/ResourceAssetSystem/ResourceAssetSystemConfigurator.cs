using Bindito.Core;

namespace TimberApi.New.ResourceAssetSystem
{
    internal class ResourceAssetSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<AssetSystemConfiguratorPatcher>().AsSingleton();
        }
    }
}