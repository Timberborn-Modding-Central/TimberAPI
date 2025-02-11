using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.WaterGenerator;

[Context("Game")]
public class WaterGeneratorToolConfigurator : Configurator
{
    protected override void Configure()
    {
        MultiBind<ISpecGenerator>().To<WaterGeneratorToolGenerator>().AsSingleton();
    }
}