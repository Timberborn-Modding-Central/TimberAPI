using Bindito.Core;

namespace TimberbornAPI.EntityInstantiatorSystem
{
    public class ModifierConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<EntityInstantiator>().AsSingleton();
        }
    }
}