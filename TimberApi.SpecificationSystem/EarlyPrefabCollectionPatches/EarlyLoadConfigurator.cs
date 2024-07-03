using Bindito.Core;

namespace TimberApi.SpecificationSystem.EarlyPrefabCollectionPatches;

[Context("MapEditor")]
public class EarlyLoadConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<MapEditorEarlyLoadPrefabCollection>().AsSingleton();
    }
}

[Context("Game")]
public class EarlyLoadGameConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<GameEarlyLoadPrefabCollection>().AsSingleton();
    }
}