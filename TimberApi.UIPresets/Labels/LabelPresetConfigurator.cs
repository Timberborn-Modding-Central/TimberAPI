using Bindito.Core;

namespace TimberApi.UIPresets.Labels;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class LabelPresetConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<GameLabel>().AsTransient();
        containerDefinition.Bind<GameTextLabel>().AsTransient();
    }
}