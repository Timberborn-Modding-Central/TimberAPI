using Bindito.Core;
using TimberApi.Core.BootstrapSystem;
using TimberApi.Internal.AssetSystem;
using TimberApi.Internal.ConfiguratorSystem;
using TimberApi.Internal.SingletonSystem;
using TimberApi.Internal.SpecificationSystem;

namespace TimberApi.Internal
{
    public class BootstrapConfigurator : ITimberApiEntryConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ISingletonRepository>().To<SingletonRepository>().AsSingleton();
            var instance = new SingletonListener();
            containerDefinition.Bind<SingletonListener>().ToInstance(instance);
            containerDefinition.AddInjectionListener(instance);
            containerDefinition.AddProvisionListener(instance);

            containerDefinition.Bind<TimberApiInternal>().AsSingleton();
            containerDefinition.Install(new ConfiguratorSystemConfigurator());
            containerDefinition.Install(new AssetSystemConfigurator());
            containerDefinition.Install(new SpecificationGlobalConfigurator());


            // Needs to be last at all times, will activate on instantiation to run TimberAPI singletons
            containerDefinition.Bind<SingletonRunner>().AsSingleton();
        }
    }
}
