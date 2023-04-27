using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;

namespace TimberApi.ToolSystem.Tools.BeaverGenerator
{
    [Configurator(SceneEntrypoint.InGame)]
    public class BeaverGeneratorToolConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IToolFactory>().To<BeaverGeneratorToolFactory>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<BeaverGeneratorToolGenerator>().AsSingleton();
        }
    }
}