using Bindito.Core;
using TimberApi.Core2.Common;
using TimberApi.Core2.ConfiguratorSystem;
using TimberApi.Core2.ModAssetSystem;

namespace TimberApi.Internal.AssetSystem
{
    [Configurator(SceneEntrypoint.All)]
    public class AssetSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IAssetLoader>().To<AssetLoader>().AsSingleton();
            containerDefinition.Bind<AssetScenePatcher>().AsSingleton();
        }
    }

    public class AssetSystemGlobalConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<AssetBundleLoader>().AsSingleton();
            containerDefinition.Bind<AssetRepository>().AsSingleton();
            containerDefinition.Bind<AssetRepositorySeeder>().AsSingleton();
            // containerDefinition.Bind<AssetScenePatcher>().AsSingleton();
        }
    }
}