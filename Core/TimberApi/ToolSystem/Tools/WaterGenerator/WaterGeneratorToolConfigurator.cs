using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;

namespace TimberApi.ToolSystem.Tools.WaterGenerator
{
    [Configurator(SceneEntrypoint.InGame)]
    public class WaterGeneratorToolConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IToolFactory>().To<WaterGeneratorToolFactory>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<WaterGeneratorToolGenerator>().AsSingleton();
        }
    }
}