using Bindito.Core;
using TimberAPIExample.AutoConfiguratorInstaller;
using TimberbornAPI.EntityInstantiatorSystem;

namespace TimberAPIExample.Examples.EntityActionExample
{
    public class EntityInstantiatorConfigurator : IInGameConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IEntityAction>().To<AddComponentExample>().AsSingleton();
            containerDefinition.MultiBind<IEntityAction>().To<TriggerActionExample>().AsSingleton();
        }
    }
}