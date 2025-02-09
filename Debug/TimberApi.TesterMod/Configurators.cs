using Bindito.Core;

namespace TimberApi.TesterMod;

[Context("Game")]
[Context("MainMenu")]
[Context("MapEditor")]
public class AllConfigurator : Configurator
{
    protected override void Configure()
    {
       
    }
}

[Context("Game")]
public class GameConfigurator : Configurator
{
    protected override void Configure()
    {
        
    }
}

[Context("MainMenu")]
public class MainMenuConfigurator : Configurator
{
    // public void Configure(IContainerDefinition containerDefinition)
    // {
    //     // containerDefinition.Bind<Tester>().AsSingleton();
    //     // containerDefinition.Bind<TestSpecificationDeserializer>().AsSingleton();
    //     // containerDefinition.MultiBind<ISpecificationGenerator>().To<TestSpecificationGenerator>().AsSingleton();
    // }

    protected override void Configure()
    {
    }
}

[Context("MapEditor")]
public class MapEditorConfigurator : Configurator
{
    protected override void Configure()
    {
    }
}