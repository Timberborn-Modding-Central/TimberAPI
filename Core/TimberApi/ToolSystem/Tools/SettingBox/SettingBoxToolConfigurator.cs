using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;

namespace TimberApi.ToolSystem.Tools.SettingBox
{
    [Configurator(SceneEntrypoint.InGame)]
    public class SettingBoxToolConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IToolFactory>().To<SettingBoxToolFactory>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<SettingBoxToolGenerator>().AsSingleton();
        }
    }
}