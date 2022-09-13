using Bindito.Core;
using TimberApi.New.ConfiguratorSystem;
using TimberApi.New.SceneSystem;

namespace TimberApi.New.SpecificationSystem.CustomSpecifications.Buildings
{
    [Configurator(SceneEntrypoint.InGame | SceneEntrypoint.MapEditor)]
    public class BuildingSpecificationConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<BuildingSpecificationService>().AsSingleton();
            containerDefinition.Bind<BuildingSpecificationDeserializer>().AsSingleton();
            containerDefinition.Bind<BuildingCostDeserializer>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<BuildingSpecificationGenerator>().AsSingleton();
            containerDefinition.Bind<BuildingChanger>().AsSingleton();
        }
    }
}