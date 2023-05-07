using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;

namespace TimberApi.ToolSystem.Tools.Planting
{
    [Configurator(SceneEntrypoint.InGame)]
    public class PlantingToolConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IToolFactory>().To<PlantingToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IObjectSpecificationGenerator>().To<PlantingToolGenerator>().AsSingleton();
        }
    }
}