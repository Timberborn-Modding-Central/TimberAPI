using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace TimberApi.ToolGroupSystem
{
    [Configurator(SceneEntrypoint.InGame)]
    public class ToolGroupConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ToolGroupSpecificationService>().AsSingleton();
        }
    }
}