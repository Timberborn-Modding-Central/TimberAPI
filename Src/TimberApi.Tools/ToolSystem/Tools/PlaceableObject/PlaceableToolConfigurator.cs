using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.PlaceableObject;

[Context("Game")]
public class PlaceableToolConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<IToolFactory>().To<PlaceableObjectToolFactory>().AsSingleton();
        containerDefinition.MultiBind<ISpecificationGenerator>().To<PlaceableObjectToolGenerator>().AsSingleton();
    }
}