using Bindito.Core;
using TimberApi.SpecificationSystem;
using TimberApi.Tools.ToolSystem.Tools.Planting;

namespace TimberApi.Tools.ToolSystem.Tools.GenericTool;

[Context("Game")]
public class GenericToolConfigurator : Configurator
{
    protected override void Configure()
    {
        MultiBind<IToolFactory>().To<GenericToolFactory>().AsSingleton();
    }
}