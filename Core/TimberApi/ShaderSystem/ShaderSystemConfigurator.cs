using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.ShaderSystem.ShaderAppliers;

namespace TimberApi.ShaderSystem
{
    [Configurator(SceneEntrypoint.InGame | SceneEntrypoint.MapEditor)]
    internal class ShaderApplierConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IShaderApplier>().To<DirtUrpApplier>().AsSingleton();
            containerDefinition.MultiBind<IShaderApplier>().To<PathShaderApplier>().AsSingleton();
        }
    }

    [Configurator(SceneEntrypoint.All)]
    internal class ShaderSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ShaderService>().AsSingleton();
        }
    }
}