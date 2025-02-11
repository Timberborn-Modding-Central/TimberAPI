using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.PlaceableObject;

[Context("Game")]
public class PlaceableToolConfigurator : Configurator
{
    protected override void Configure()
    {
        MultiBind<IToolFactory>().To<PlaceableObjectToolFactory>().AsSingleton();
        MultiBind<ISpecGenerator>().To<PlaceableObjectToolGenerator>().AsSingleton();
    }
}