using Bindito.Core;
using Timberborn.AssetSystem;

namespace TimberApi.SpecificationSystem;

internal class BootstrapperConfigurator : IConfigurator
{
    public static void Patch(IContainerDefinition containerDefinition)
    {
        containerDefinition.Install(new BootstrapperConfigurator());
    }
    
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<IAssetProvider>().To<GeneratedSpecificationAssetProvider>().AsSingleton();
        containerDefinition.Bind<GeneratedSpecificationAssetRepository>().AsSingleton();
    }
}