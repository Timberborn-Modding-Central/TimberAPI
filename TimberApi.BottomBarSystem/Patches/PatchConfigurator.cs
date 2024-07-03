using Bindito.Core;

namespace TimberApi.BottomBarSystem.Patches;

[Context("Game")]
[Context("MapEditor")]
public class PatchConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<ToolGroupButtonPatcher>().AsSingleton();
    }
}