using Bindito.Core;

namespace TimberbornAPI.EntityInstantiatorSystem
{
    public class EntityActionConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<EntityActionApplier>().AsSingleton();
        }
    }
}