using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BeaverGenerator;

[Context("Game")]
internal class BeaverGeneratorToolConfigurator : Configurator
{
    protected override void Configure()
    {
        MultiBind<ISpecGenerator>().To<BeaverGeneratorToolGenerator>().AsSingleton();
    }
}