using Bindito.Core;

namespace TimberApi.UIPresets.ListViews;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class ListViewPresetConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<DefaultListView>().AsTransient();
    }
}