using Bindito.Core;
using TimberAPIExample.AutoConfiguratorInstaller;
using TimberbornAPI.GameObjectModifier;

namespace TimberAPIExample.Examples.GameObjectModifier
{
    public class EntityInstantiatorConfigurator : IInGameConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IEntityInstantiator>().To<AddComponentExample>().AsSingleton();
            containerDefinition.MultiBind<IEntityInstantiator>().To<TriggerActionExample>().AsSingleton();
        }
    }
}