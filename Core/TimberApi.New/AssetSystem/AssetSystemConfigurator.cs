using Bindito.Core;
using TimberApi.New.Common;
using TimberApi.New.ConfiguratorSystem;
using TimberApi.New.ModAssetSystem;

namespace TimberApi.New.AssetSystem
{
    [Configurator(SceneEntrypoint.All)]
    public class AssetSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IAssetLoader>().To<AssetLoader>().AsSingleton();
            containerDefinition.Bind<AssetSceneLoader>().AsSingleton();
        }
    }

    public class AssetSystemGlobalConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<AssetBundleLoader>().AsSingleton();
            containerDefinition.Bind<AssetRepository>().AsSingleton();
            containerDefinition.Bind<AssetRepositorySeeder>().AsSingleton();
        }
    }
}