using Bindito.Core;

namespace TimberApi.TesterMod;

[Context("Game")]
[Context("MainMenu")]
[Context("MapEditor")]
public class AllConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<TestClass>().AsSingleton();
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
    // protected override void Configure()
    // {
    //     // Bind<Tester>().AsSingleton();
    //     // Bind<TestSpecificationDeserializer>().AsSingleton();
    //     // MultiBind<ISpecGenerator>().To<TestSpecificationGenerator>().AsSingleton();
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