using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;

namespace TimberApi.AssetSystem
{
    [Configurator(SceneEntrypoint.All)]
    internal class AssetSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IAssetLoader>().To<AssetLoader>().AsSingleton();
            containerDefinition.Bind<AssetSceneLoader>().AsSingleton();
            containerDefinition.Bind<AssetSpecificationDeserializer>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<AssetSpecificationGenerator>().AsSingleton();
        }
    }
}