using Bindito.Core;
using TimberApi.SceneSystem;

namespace TimberApi.Core.ConfiguratorSystem
{
    internal class ConfiguratorInstaller
    {
        private readonly ConfiguratorRepository _configuratorRepository;

        public ConfiguratorInstaller(ConfiguratorRepository configuratorRepository)
        {
            _configuratorRepository = configuratorRepository;
            TimberApiSceneManager.SceneChanged += OnSceneChanged;
        }

        private void OnSceneChanged(SceneEntrypoint previousScene, SceneEntrypoint currentScene, IContainerDefinition currentContainerDefinition)
        {
            foreach (IConfigurator configurator in _configuratorRepository.SceneConfigurators[currentScene])
            {
                currentContainerDefinition.Install(configurator);
            }
        }
    }
}