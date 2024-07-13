using Bindito.Core;
using TimberApi.Tools.ToolGroupUI.Factories;

namespace TimberApi.Tools.ToolGroupUI;

[Context("Game")]
[Context("MapEditor")]
public class ToolGroupUIConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<ToolGroupButtonFactoryService>().AsSingleton();
        containerDefinition.Bind<ToolGroupButtonFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolGroupButtonFactory>().To<ToolGroupButtonRedFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolGroupButtonFactory>().To<ToolGroupButtonBrownFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolGroupButtonFactory>().To<ToolGroupButtonBlueFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolGroupButtonFactory>().To<ToolGroupButtonGreenFactory>().AsSingleton();
    }
}