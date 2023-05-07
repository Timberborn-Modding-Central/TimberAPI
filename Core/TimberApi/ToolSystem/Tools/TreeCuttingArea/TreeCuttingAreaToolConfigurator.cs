using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;

namespace TimberApi.ToolSystem.Tools.TreeCuttingArea
{
    [Configurator(SceneEntrypoint.InGame)]
    public class TreeCuttingAreaToolConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<ISpecificationGenerator>().To<TreeCuttingAreaToolGenerator>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<TreeCuttingAreaSelectionToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<TreeCuttingAreaUnselectionToolFactory>().AsSingleton();
        }
    }
}