using Bindito.Core;

namespace TimberApi.BottomBarSystem.Patches;

[Context("Game")]
public class PatchConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<ToolGroupButtonPatcher>().AsSingleton();
    }
}