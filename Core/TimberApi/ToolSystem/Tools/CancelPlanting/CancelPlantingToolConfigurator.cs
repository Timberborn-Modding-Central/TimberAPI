using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;

namespace TimberApi.ToolSystem.Tools.CancelPlanting
{
    [Configurator(SceneEntrypoint.InGame)]
    public class CancelPlantingToolConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IToolFactory>().To<CancelPlantingToolFactory>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<CancelPlantingToolGenerator>().AsSingleton();
        }
    }
}