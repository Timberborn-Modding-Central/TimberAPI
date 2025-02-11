using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BotGenerator;

[Context("Game")]
public class BotGeneratorToolConfigurator : Configurator
{
    protected override void Configure()
    {
        MultiBind<ISpecGenerator>().To<BotGeneratorToolGenerator>().AsSingleton();
    }
}