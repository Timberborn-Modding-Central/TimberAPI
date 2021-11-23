using Bindito.Core;

namespace TimberbornAPI.GameObjectModifier
{
    public class ModifierConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<EntityInstantiator>().AsSingleton();
        }
    }
}