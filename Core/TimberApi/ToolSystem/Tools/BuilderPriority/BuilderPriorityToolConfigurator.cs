using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;

namespace TimberApi.ToolSystem.Tools.BuilderPriority
{
    [Configurator(SceneEntrypoint.InGame)]
    public class BuilderPriorityToolConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IToolFactory>().To<BuilderPriorityToolFactory>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<BuilderPriorityToolGenerator>().AsSingleton();
        }
    }
}