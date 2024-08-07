using Bindito.Core;

namespace TimberApi.UIPresets.Sliders;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class SliderConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<MainMenuSliderInt>().AsTransient();
        containerDefinition.Bind<MainMenuTextSliderInt>().AsTransient();
        
        containerDefinition.Bind<GameSliderInt>().AsTransient();
        containerDefinition.Bind<GameTextSliderInt>().AsTransient();
        
        containerDefinition.Bind<MainMenuSlider>().AsTransient();
        containerDefinition.Bind<MainMenuTextSlider>().AsTransient();
        
        containerDefinition.Bind<GameSlider>().AsTransient();
        containerDefinition.Bind<GameTextSlider>().AsTransient();
    }
}