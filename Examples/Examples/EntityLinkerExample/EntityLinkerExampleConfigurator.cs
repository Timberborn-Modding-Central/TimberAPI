using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberAPIExample.Examples.EntityLinkerExample.UI;
using Timberborn.Buildings;
using Timberborn.EntityPanelSystem;
using Timberborn.Stockpiles;
using Timberborn.TemplateSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample
{
    [Configurator(SceneEntrypoint.InGame)]
    public class EntityLinkerExampleConfigurator : IConfigurator
    {
        // Bind our custom classes
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<LinkerFragment<Building>>().AsSingleton();
            containerDefinition.Bind<EntityLinkViewFactory>().AsSingleton();
            containerDefinition.Bind<StartLinkingButton>().AsSingleton();

            containerDefinition.MultiBind<EntityPanelModule>().ToProvider<EntityPanelModuleProvider>().AsSingleton();
            containerDefinition.MultiBind<TemplateModule>().ToProvider(ProvideTemplateModule).AsSingleton();
        }

        private static TemplateModule ProvideTemplateModule()
        {
            TemplateModule.Builder builder = new TemplateModule.Builder();
            builder.AddDecorator<Stockpile, WarehouseLinkService>();
            return builder.Build();
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
