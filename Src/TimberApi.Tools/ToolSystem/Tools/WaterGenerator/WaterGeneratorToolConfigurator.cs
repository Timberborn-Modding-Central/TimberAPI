using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.WaterGenerator;

[Context("Game")]
public class WaterGeneratorToolConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<ISpecificationGenerator>().To<WaterGeneratorToolGenerator>().AsSingleton();
    }
}