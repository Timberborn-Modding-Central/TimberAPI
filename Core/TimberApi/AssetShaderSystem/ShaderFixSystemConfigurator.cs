using Bindito.Core;
using TimberApi.AssetShaderSystem.ShaderFix;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace TimberApi.AssetShaderSystem
{
    [Configurator(SceneEntrypoint.InGame | SceneEntrypoint.MapEditor)]
    internal class ShaderFixSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IShaderFixApplier>().To<DirtShaderFixApplier>().AsSingleton();
            containerDefinition.MultiBind<IShaderFixApplier>().To<PathShaderFixApplier>().AsSingleton();
        }
    }

    [Configurator(SceneEntrypoint.All)]
    internal class ShaderSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<AssetShaderFixer>().AsSingleton();
        }
    }
}