using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Cursor;

[Context("Game")]
public class CursorToolConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<ISpecificationGenerator>().To<CursorToolGenerator>().AsSingleton();
    }
}