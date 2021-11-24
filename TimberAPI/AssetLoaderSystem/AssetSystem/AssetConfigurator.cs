using Bindito.Core;

namespace TimberbornAPI.AssetLoaderSystem.AssetSystem
{
    public class AssetConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IAssetLoader>().To<AssetLoader>().AsSingleton();
        }
    }
}