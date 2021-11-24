using Bindito.Core;
using TimberAPIExample.AutoConfiguratorInstaller;
using TimberbornAPI.EntityActionSystem;

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