using Bindito.Core;

namespace TimberApi.UIPresets.Sliders;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class SliderPresetConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<MainMenuSliderInt>().AsTransient();
        Bind<MainMenuTextSliderInt>().AsTransient();
        
        Bind<GameSliderInt>().AsTransient();
        Bind<GameTextSliderInt>().AsTransient();
        
        Bind<MainMenuSlider>().AsTransient();
        Bind<MainMenuTextSlider>().AsTransient();
        
        Bind<GameSlider>().AsTransient();
        Bind<GameTextSlider>().AsTransient();
        
        Bind<GameMinMaxSlider>().AsTransient();
        Bind<GameTextMinMaxSlider>().AsTransient();
    }
}