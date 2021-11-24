using Bindito.Core;

namespace TimberbornAPI.EntityActionSystem
{
    public class EntityActionConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<EntityActionApplier>().AsSingleton();
        }
    }
}