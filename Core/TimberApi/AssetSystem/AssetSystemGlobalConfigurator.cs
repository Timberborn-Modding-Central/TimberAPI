using Bindito.Core;

namespace TimberApi.AssetSystem
{
    internal class AssetSystemGlobalConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<AssetBundleLoader>().AsSingleton();
            containerDefinition.Bind<AssetRepository>().AsSingleton();
            containerDefinition.Bind<AssetRepositoryPreLoadableSingleton>().AsSingleton();
        }
    }
}