using Bindito.Core;
using TimberApi.Tools.ToolGroupUI.Factories;

namespace TimberApi.Tools.ToolGroupUI;

[Context("Game")]
[Context("MapEditor")]
public class ToolGroupUIConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<ToolGroupButtonFactoryService>().AsSingleton();
        Bind<ToolGroupButtonFactory>().AsSingleton();
        MultiBind<IToolGroupButtonFactory>().To<ToolGroupButtonRedFactory>().AsSingleton();
        MultiBind<IToolGroupButtonFactory>().To<ToolGroupButtonBrownFactory>().AsSingleton();
        MultiBind<IToolGroupButtonFactory>().To<ToolGroupButtonBlueFactory>().AsSingleton();
        MultiBind<IToolGroupButtonFactory>().To<ToolGroupButtonGreenFactory>().AsSingleton();
    }
}