using Bindito.Core;

namespace TimberApi.BottomBarSystem.Patches;

[Context("Game")]
public class PatchConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<ToolGroupButtonPatcher>().AsSingleton();
    }
}