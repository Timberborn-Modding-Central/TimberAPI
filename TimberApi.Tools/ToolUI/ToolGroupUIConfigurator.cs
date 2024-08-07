using Bindito.Core;
using TimberApi.Tools.ToolUI.Factories;

namespace TimberApi.Tools.ToolUI;

[Context("Game")]
[Context("MapEditor")]
public class ToolGroupUIConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<ToolButtonFactoryService>().AsSingleton();

        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonBlueFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonRedFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonGreenFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonBrownFactory>().AsSingleton();

        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonGrouplessBrownFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonGrouplessGreenFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonGrouplessRedFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonGrouplessBlueFactory>().AsSingleton();

        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonWonderBrownFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonWonderGreenFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonWonderRedFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonWonderBlueFactory>().AsSingleton();

        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonWonderFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonDefaultFactory>().AsSingleton();
    }
}