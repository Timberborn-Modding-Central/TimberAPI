using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using Timberborn.EntityPanelSystem;

namespace TimberAPIExample.Examples.UIBuilderExample
{
    [Configurator(SceneEntrypoint.InGame)]
    public class UIBuilderFragmentConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<UIBuilderFragmentExample>().AsSingleton();
            containerDefinition.MultiBind<EntityPanelModule>().ToProvider<EntityPanelModuleProvider>().AsSingleton();
        }
        
        private class EntityPanelModuleProvider : IProvider<EntityPanelModule>
        {
            private readonly UIBuilderFragmentExample _fragmentExample;
        
            public EntityPanelModuleProvider(UIBuilderFragmentExample fragmentExample)
            {
                _fragmentExample = fragmentExample;
            }
        
            public EntityPanelModule Get()
            {
                EntityPanelModule.Builder builder = new EntityPanelModule.Builder();
                builder.AddBottomFragment(_fragmentExample);
                return builder.Build();
            }
        }
    }
}