using Bindito.Core;
using Timberborn.EntityPanelSystem;
using TimberbornAPI.DependencySystem;

namespace TimberAPIExample.Examples.UIBuilderExample
{
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