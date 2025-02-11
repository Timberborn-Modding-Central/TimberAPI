using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.TreeCuttingArea;

[Context("Game")]
public class TreeCuttingAreaToolConfigurator : Configurator
{
    protected override void Configure()
    {
        MultiBind<ISpecGenerator>().To<TreeCuttingAreaToolGenerator>().AsSingleton();
    }
}