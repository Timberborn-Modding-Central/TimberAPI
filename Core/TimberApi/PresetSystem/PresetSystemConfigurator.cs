using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace TimberApi.PresetSystem
{
    [Configurator(SceneEntrypoint.All)]
    public class PresetSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<PresetRepository>().AsSingleton();
            containerDefinition.Bind<PresetRepositorySeeder>().AsSingleton();
        }
    }
}