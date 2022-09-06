using Bindito.Core;
using TimberApi.New.ConfiguratorSystem;
using TimberApi.New.SceneSystem;
using Timberborn.Persistence;

namespace TimberApi.New.SpecificationSystem
{
    [Configurator(SceneEntrypoint.All)]
    public class SpecificationConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<SpecificationRepository>().AsSingleton();
            containerDefinition.Bind<SpecificationRepositorySeeder>().AsSingleton();
            containerDefinition.Bind<ISpecificationService>().To<TimberApiSpecificationService>().AsSingleton();
        }
    }

    /// <summary>
    /// registered in global container, `ISpecificationService` called before seeder was loaded
    /// </summary>
    public class SpecificationGlobalConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<SpecificationPatcher>().AsSingleton();
        }
    }
}