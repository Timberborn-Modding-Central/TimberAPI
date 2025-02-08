using Bindito.Core;
using Timberborn.AssetSystem;

namespace TimberApi.SpecificationSystem;

[Context("Global")]
internal class BootstrapperConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<IAssetProvider>().To<GeneratedSpecificationAssetProvider>().AsSingleton();
        containerDefinition.Bind<GeneratedSpecificationAssetRepository>().AsSingleton();
    }
}