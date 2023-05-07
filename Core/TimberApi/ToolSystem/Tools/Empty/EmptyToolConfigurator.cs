using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace TimberApi.ToolSystem.Tools.Empty
{
    [Configurator(SceneEntrypoint.InGame)]
    public class EmptyToolConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IToolFactory>().To<EmptyToolFactory>().AsSingleton();
        }
    }
}