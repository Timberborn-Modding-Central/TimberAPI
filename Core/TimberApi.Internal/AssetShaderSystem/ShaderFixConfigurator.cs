using Bindito.Core;
using TimberApi.Core2.Common;
using TimberApi.Core2.ConfiguratorSystem;
using TimberApi.Internal.AssetShaderSystem.ShaderFix;

namespace TimberApi.Internal.AssetShaderSystem
{
    [Configurator(SceneEntrypoint.InGame | SceneEntrypoint.MapEditor)]
    public class ShaderFixSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IShaderFixApplier>().To<DirtShaderFixApplier>().AsSingleton();
            containerDefinition.MultiBind<IShaderFixApplier>().To<PathShaderFixApplier>().AsSingleton();
        }
    }

    [Configurator(SceneEntrypoint.All)]
    public class ShaderSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<AssetShaderFixer>().AsSingleton();
        }
    }
}