using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.SettingBox;

[Context("Game")]
public class SettingBoxToolConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<SettingBoxTool>().AsSingleton();
        MultiBind<ISpecGenerator>().To<SettingBoxToolGenerator>().AsSingleton();
    }
}