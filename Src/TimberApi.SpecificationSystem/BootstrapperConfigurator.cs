using Bindito.Core;
using Timberborn.AssetSystem;

namespace TimberApi.SpecificationSystem;

[Context("Bootstrapper")]
internal class BootstrapperConfigurator : Configurator
{
    protected override void Configure()
    {
        MultiBind<IAssetProvider>().To<GeneratedSpecificationAssetProvider>().AsSingleton().AsExported();
        Bind<GeneratedSpecificationAssetRepository>().AsSingleton().AsExported();
    }
}