using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BotGenerator;

[Context("Game")]
public class BotGeneratorToolConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<IToolFactory>().To<BotGeneratorToolFactory>().AsSingleton();
        containerDefinition.MultiBind<ISpecificationGenerator>().To<BotGeneratorToolGenerator>().AsSingleton();
    }
}