using Bindito.Core;
using TimberApi.Tools.ToolUI.Factories;

namespace TimberApi.Tools.ToolUI;

[Context("Game")]
[Context("MapEditor")]
public class ToolGroupUIConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<ToolButtonFactoryService>().AsSingleton();

        MultiBind<IToolButtonFactory>().To<ToolButtonBlueFactory>().AsSingleton();
        MultiBind<IToolButtonFactory>().To<ToolButtonRedFactory>().AsSingleton();
        MultiBind<IToolButtonFactory>().To<ToolButtonGreenFactory>().AsSingleton();
        MultiBind<IToolButtonFactory>().To<ToolButtonBrownFactory>().AsSingleton();

        MultiBind<IToolButtonFactory>().To<ToolButtonGrouplessBrownFactory>().AsSingleton();
        MultiBind<IToolButtonFactory>().To<ToolButtonGrouplessGreenFactory>().AsSingleton();
        MultiBind<IToolButtonFactory>().To<ToolButtonGrouplessRedFactory>().AsSingleton();
        MultiBind<IToolButtonFactory>().To<ToolButtonGrouplessBlueFactory>().AsSingleton();

        MultiBind<IToolButtonFactory>().To<ToolButtonWonderBrownFactory>().AsSingleton();
        MultiBind<IToolButtonFactory>().To<ToolButtonWonderGreenFactory>().AsSingleton();
        MultiBind<IToolButtonFactory>().To<ToolButtonWonderRedFactory>().AsSingleton();
        MultiBind<IToolButtonFactory>().To<ToolButtonWonderBlueFactory>().AsSingleton();

        MultiBind<IToolButtonFactory>().To<ToolButtonWonderFactory>().AsSingleton();
        MultiBind<IToolButtonFactory>().To<ToolButtonDefaultFactory>().AsSingleton();
    }
}