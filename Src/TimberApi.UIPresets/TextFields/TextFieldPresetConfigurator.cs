using Bindito.Core;

namespace TimberApi.UIPresets.TextFields;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class TextFieldPresetConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<DefaultTextField>().AsTransient();
    }
}