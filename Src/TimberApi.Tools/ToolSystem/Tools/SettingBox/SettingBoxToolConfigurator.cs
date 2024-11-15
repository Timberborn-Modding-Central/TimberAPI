using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.SettingBox;

[Context("Game")]
public class SettingBoxToolConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<SettingBoxTool>().AsSingleton();
        containerDefinition.MultiBind<ISpecificationGenerator>().To<SettingBoxToolGenerator>().AsSingleton();
    }
}