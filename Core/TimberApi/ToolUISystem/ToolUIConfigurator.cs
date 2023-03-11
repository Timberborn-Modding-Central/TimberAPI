using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace TimberApi.ToolUISystem
{
    [Configurator(SceneEntrypoint.InGame)]
    public class ToolUIConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ToolButtonFactory>().AsSingleton();
        }
    }
}