using Bindito.Core;

namespace TimberApi.UIPresets.ListViews;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class ListViewPresetConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<DefaultListView>().AsTransient();
    }
}