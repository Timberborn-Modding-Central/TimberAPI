using Bindito.Core;

namespace TimberApi.ResourceAssetSystem
{
    internal class ResourceAssetSystemConfigurator : IConfigurator
    {
        //TODO: Add generalized patcher logic
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<AssetSystemConfiguratorPatcher>().AsSingleton();
        }
    }
}