using Bindito.Core;

namespace TimberApi.SpecificationSystem;

[Context("Game")]
[Context("MainMenu")]
[Context("MapEditor")]
internal class SpecificationSystemConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<GeneratedSpecificationLoader>().AsSingleton();
    }
}