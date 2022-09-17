using TimberAPIExample.Examples.EntityLinkerExample.UI;

namespace TimberAPIExample.Examples.EntityLinkerExample
{
    public class EntityLinkerExampleConfigurator : IConfigurator
    {
        // Bind our custom classes
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IEntityAction>().To<EntityActions>().AsSingleton();

            containerDefinition.Bind<LinkerFragment<Building>>().AsSingleton();
            containerDefinition.Bind<EntityLinkViewFactory>().AsSingleton();
            containerDefinition.Bind<StartLinkingButton>().AsSingleton();

            containerDefinition.MultiBind<EntityPanelModule>().ToProvider<EntityPanelModuleProvider>().AsSingleton();
        }

        private class EntityPanelModuleProvider : IProvider<EntityPanelModule>
        {
            private readonly LinkerFragment<Building> _linkerFragment;

            public EntityPanelModuleProvider(LinkerFragment<Building> linkerFragment)
            {
                _linkerFragment = linkerFragment;
            }

            public EntityPanelModule Get()
            {
                EntityPanelModule.Builder builder = new EntityPanelModule.Builder();
                builder.AddBottomFragment(_linkerFragment);
                return builder.Build();
            }
        }
    }
}
