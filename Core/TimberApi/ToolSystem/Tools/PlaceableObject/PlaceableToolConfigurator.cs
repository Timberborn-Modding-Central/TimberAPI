using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;

namespace TimberApi.ToolSystem.Tools.PlaceableObject
{
    [Configurator(SceneEntrypoint.InGame)]
    public class PlaceableToolConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IToolFactory>().To<PlaceableObjectToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IObjectSpecificationGenerator>().To<PlaceableObjectToolGenerator>().AsSingleton();
        }
    }
}