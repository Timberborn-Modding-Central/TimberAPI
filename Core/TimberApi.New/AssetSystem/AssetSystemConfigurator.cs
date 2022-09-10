using Bindito.Core;
using TimberApi.New.ConfiguratorSystem;
using TimberApi.New.ModAssetSystem;
using TimberApi.New.SceneSystem;

namespace TimberApi.New.AssetSystem
{
    [Configurator(SceneEntrypoint.All)]
    internal class AssetSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IAssetLoader>().To<AssetLoader>().AsSingleton();
            containerDefinition.Bind<AssetSceneLoader>().AsSingleton();
        }
    }

    internal class AssetSystemGlobalConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<AssetBundleLoader>().AsSingleton();
            containerDefinition.Bind<AssetRepository>().AsSingleton();
            containerDefinition.Bind<AssetRepositorySeeder>().AsSingleton();
        }
    }
}