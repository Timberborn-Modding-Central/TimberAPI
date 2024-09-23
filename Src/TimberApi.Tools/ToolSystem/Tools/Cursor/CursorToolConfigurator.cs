using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Cursor;

[Context("Game")]
public class CursorToolConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<IToolFactory>().To<CursorToolFactory>().AsSingleton();
        containerDefinition.MultiBind<ISpecificationGenerator>().To<CursorToolGenerator>().AsSingleton();
    }
}