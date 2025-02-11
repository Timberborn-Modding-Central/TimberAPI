using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Cursor;

[Context("Game")]
public class CursorToolConfigurator : Configurator
{
    protected override void Configure()
    {
        MultiBind<ISpecGenerator>().To<CursorToolGenerator>().AsSingleton();
    }
}