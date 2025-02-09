using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BotGenerator;

[Context("Game")]
public class BotGeneratorToolConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<ISpecificationGenerator>().To<BotGeneratorToolGenerator>().AsSingleton();
    }
}