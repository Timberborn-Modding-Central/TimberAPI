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
}