using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;

namespace TimberApi.ToolSystem.Tools.Cursor
{
    [Configurator(SceneEntrypoint.InGame)]
    public class CursorToolConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IToolFactory>().To<CursorToolFactory>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<CursorToolGenerator>().AsSingleton();
        }
    }
}