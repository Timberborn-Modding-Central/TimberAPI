using Bindito.Core;

namespace TimberApi.Internal.AssetSystem
{
    public class AssetSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<AssetRepository>().AsSingleton();
            containerDefinition.Bind<AssetRepositorySeeder>().AsSingleton();
            containerDefinition.Bind<AssetLoader>().AsSingleton();
            containerDefinition.Bind<AssetBundleLoader>().AsSingleton();
            containerDefinition.Bind<AssetScenePatcher>().AsSingleton();
        }
    }
}