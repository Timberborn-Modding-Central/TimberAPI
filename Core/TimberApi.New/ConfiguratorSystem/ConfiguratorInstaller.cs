using Bindito.Core;
using TimberApi.Common.SingletonSystem;
using TimberApi.New.SceneSystem;

namespace TimberApi.New.ConfiguratorSystem
{
    internal static class ConfiguratorInstaller
    {
        public static void Install(IContainerDefinition containerDefinition, SceneEntrypoint sceneEntrypoint)
        {
            containerDefinition.Bind<ISingletonRepository>().To<SingletonRepository>().AsSingleton();
            var instance = new SingletonListener();
            containerDefinition.Bind<SingletonListener>().ToInstance(instance);
            containerDefinition.AddInjectionListener(instance);
            containerDefinition.AddProvisionListener(instance);

            foreach (IConfigurator configurator in ConfiguratorRepository.SceneConfigurators[sceneEntrypoint])
            {
                containerDefinition.Install(configurator);
            }

            containerDefinition.Bind<SingletonRunner>().AsSingleton();
        }
    }
}