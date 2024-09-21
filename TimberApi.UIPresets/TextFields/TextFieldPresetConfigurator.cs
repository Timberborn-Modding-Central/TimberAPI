using Bindito.Core;

namespace TimberApi.UIPresets.TextFields;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class TextFieldPresetConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<DefaultTextField>().AsTransient();
    }
}