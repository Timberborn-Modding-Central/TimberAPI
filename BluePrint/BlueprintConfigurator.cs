using Bindito.Core;

namespace BluePrint;

[Context("Game")]
public class BlueprintConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<BlueprintRepository>().AsSingleton();
        containerDefinition.Bind<BlueprintPreviewPlacerFactory>().AsSingleton();
        containerDefinition.Bind<BlueprintService>().AsSingleton();
        containerDefinition.Bind<FakeTool>().AsSingleton();
    }
}