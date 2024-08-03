using Bindito.Core;

namespace TimberApi.UIPresets.Sliders;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class SliderConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<SliderTest>().AsTransient();
    }
}