using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using Timberborn.Persistence;

namespace TimberApi.SpecificationSystem
{
    [Configurator(SceneEntrypoint.All)]
    internal class SpecificationSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<SpecificationRepository>().AsSingleton();
            containerDefinition.Bind<SpecificationRepositoryPreLoadableSingleton>().AsSingleton();
            containerDefinition.Bind<ISpecificationService>().To<TimberApiSpecificationService>().AsSingleton();
        }
    }

    /// <summary>
    ///     registered in global container, `ISpecificationService` called before seeder was loaded
    /// </summary>
    internal class SpecificationSystemGlobalConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<SpecificationPatcher>().AsSingleton();
        }
    }
}