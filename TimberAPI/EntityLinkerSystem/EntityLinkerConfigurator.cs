using Bindito.Core;
using TimberbornAPI.EntityActionSystem;

namespace TimberbornAPI.EntityLinkerSystem
{
    public class EntityLinkerConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IEntityAction>().To<EntityActions>().AsSingleton();
            containerDefinition.Bind<EntityLinkSerializer>().AsSingleton();
        }
    }
}
