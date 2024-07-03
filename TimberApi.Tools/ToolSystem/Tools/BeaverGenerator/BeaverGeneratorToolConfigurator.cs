using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BeaverGenerator;

[Context("Game")]
internal class BeaverGeneratorToolConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<IToolFactory>().To<BeaverGeneratorToolFactory>().AsSingleton();
        containerDefinition.MultiBind<ISpecificationGenerator>().To<BeaverGeneratorTool>().AsSingleton();
    }
}