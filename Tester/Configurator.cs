using Bindito.Core;
using Timberborn.BeaversUI;
using Timberborn.EntityPanelSystem;

namespace Tester;

[Context("Game")]
public class Configurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<Test>().AsSingleton();
        containerDefinition.Bind<TestFragment>().AsSingleton();
        containerDefinition.MultiBind<EntityPanelModule>().ToProvider<EntityPanelModuleProvider>().AsSingleton();

    }
    
    public class EntityPanelModuleProvider : IProvider<EntityPanelModule>
    {
        private readonly TestFragment _testFragment;

        public EntityPanelModuleProvider(TestFragment testFragment)
        {
            _testFragment = testFragment;
        }

        public EntityPanelModule Get()
        {
            EntityPanelModule.Builder builder = new EntityPanelModule.Builder();
            builder.AddMiddleFragment(_testFragment);
            return builder.Build();
        }
    }
}