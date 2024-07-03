using Bindito.Core;

namespace TimberApi.SpecificationSystem;

[Context("InGame")]
[Context("MainMenu")]
[Context("MapEditor")]
internal class SpecificationSystemConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<GeneratedSpecificationLoader>().AsSingleton();
    }
}