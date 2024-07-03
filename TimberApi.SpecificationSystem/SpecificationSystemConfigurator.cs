using Bindito.Core;

namespace TimberApi.SpecificationSystem;

[Context("Game")]
[Context("MainMenu")]
[Context("MapEditor")]
internal class SpecificationSystemConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<GeneratedSpecificationLoader>().AsSingleton();
    }
}