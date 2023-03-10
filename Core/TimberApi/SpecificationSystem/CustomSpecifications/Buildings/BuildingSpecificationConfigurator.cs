using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Buildings
{
    [Configurator(SceneEntrypoint.InGame)]
    internal class BuildingSpecificationConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<BuildingSpecificationService>().AsSingleton();
            containerDefinition.Bind<BuildingSpecificationObjectDeserializer>().AsSingleton();
            containerDefinition.Bind<BuildingCostObjectDeserializer>().AsSingleton();
            containerDefinition.Bind<BuildingSpecificationGenerator>().AsSingleton();
            containerDefinition.Bind<BuildingChanger>().AsSingleton();
        }
    }
}