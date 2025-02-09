using Bindito.Core;

namespace TimberApi.UIPresets.Builders;

[Context("Game")]
[Context("MainMenu")]
[Context("MapEditor")]
public class UIBuilderConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<FragmentBuilder>().AsTransient();
        containerDefinition.Bind<BoxBuilder>().AsTransient();
    }
}