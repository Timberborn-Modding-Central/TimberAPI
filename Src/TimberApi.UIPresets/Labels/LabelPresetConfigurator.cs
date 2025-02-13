using Bindito.Core;

namespace TimberApi.UIPresets.Labels;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class LabelPresetConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<GameLabel>().AsTransient();
        Bind<GameTextLabel>().AsTransient();
    }
}