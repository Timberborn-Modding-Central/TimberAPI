using Bindito.Core;
using TimberAPIExample.Examples.EntityLinkerExample.LumbermillWIndmillExample.UI;
using Timberborn.EntityPanelSystem;
using TimberbornAPI.EntityActionSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.LumbermillWIndmillExample
{
    public class LumbermillWindmillExampleConfigurator : IConfigurator
    {

        // Bind our custom classes
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IEntityAction>().To<EntityActions>().AsSingleton();

            containerDefinition.Bind<LumbermillWindmillLinkSerializer>().AsSingleton();

            containerDefinition.Bind<LumbermillFragment>().AsSingleton();
            containerDefinition.Bind<WindmillFragment>().AsSingleton();
            containerDefinition.Bind<LinkViewFactory>().AsSingleton();
            containerDefinition.Bind<StartLinkButton>().AsSingleton();

            containerDefinition.MultiBind<EntityPanelModule>().ToProvider<EntityPanelModuleProvider>().AsSingleton();
        }


        private class EntityPanelModuleProvider : IProvider<EntityPanelModule>
        {
            private readonly LumbermillFragment _linkerFragment;
            private readonly WindmillFragment _linkeeFragment;

            public EntityPanelModuleProvider(LumbermillFragment linkerFragment,
                                             WindmillFragment linkeeFragment)
            {
                _linkerFragment = linkerFragment;
                _linkeeFragment = linkeeFragment;
            }

            public EntityPanelModule Get()
            {
                EntityPanelModule.Builder builder = new EntityPanelModule.Builder();
                builder.AddBottomFragment(_linkerFragment);
                builder.AddBottomFragment(_linkeeFragment);
                return builder.Build();
            }
        }
    }
}
