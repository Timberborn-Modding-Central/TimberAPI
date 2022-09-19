using Bindito.Core;
using TimberApi.SceneSystem;

namespace TimberApi.ConfiguratorSystem
{
    internal static class ConfiguratorInstaller
    {
        public static void Install(IContainerDefinition containerDefinition, SceneEntrypoint sceneEntrypoint)
        {
            foreach (IConfigurator configurator in ConfiguratorRepository.SceneConfigurators[sceneEntrypoint])
            {
                containerDefinition.Install(configurator);
            }
        }
    }
}