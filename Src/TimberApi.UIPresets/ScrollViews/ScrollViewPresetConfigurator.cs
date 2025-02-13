using Bindito.Core;

namespace TimberApi.UIPresets.ScrollViews;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class ScrollViewPresetConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<DefaultScrollView>().AsTransient();
    }
}