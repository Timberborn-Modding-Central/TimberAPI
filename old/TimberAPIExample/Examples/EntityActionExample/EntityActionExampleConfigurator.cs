namespace TimberAPIExample.Examples.EntityActionExample
{
    public class EntityActionExampleConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IEntityAction>().To<AddComponentActionExample>().AsSingleton();
            containerDefinition.MultiBind<IEntityAction>().To<TriggerActionExample>().AsSingleton();
        }
    }
}