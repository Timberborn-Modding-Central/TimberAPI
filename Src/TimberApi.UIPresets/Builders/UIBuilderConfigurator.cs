using Bindito.Core;

namespace TimberApi.UIPresets.Builders;

[Context("Game")]
[Context("MainMenu")]
[Context("MapEditor")]
public class UIBuilderConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<FragmentBuilder>().AsTransient();
        Bind<BoxBuilder>().AsTransient();
    }
}