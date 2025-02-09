using Bindito.Core;

namespace TimberApi.SpecificationSystem;

[Context("Game")]
[Context("MainMenu")]
[Context("MapEditor")]
internal class SpecSystemConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<GeneratedSpecificationLoader>().AsSingleton();
    }
}