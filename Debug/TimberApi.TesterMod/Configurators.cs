using Bindito.Core;

namespace TimberApi.TesterMod;

[Context("Game")]
[Context("MainMenu")]
[Context("MapEditor")]
public class AllConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        
    }
}

[Context("Game")]
public class GameConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        
    }
}

[Context("MainMenu")]
public class MainMenuConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        
    }
}

[Context("MapEditor")]
public class MapEditorConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        
    }
}