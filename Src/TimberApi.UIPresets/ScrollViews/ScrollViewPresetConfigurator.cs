using Bindito.Core;

namespace TimberApi.UIPresets.ScrollViews;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class ScrollViewPresetConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<DefaultScrollView>().AsTransient();
    }
}