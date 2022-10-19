using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using Timberborn.BottomBarSystem;

namespace TimberAPIExample.Examples.AssetLoaderExample
{
    [Configurator(SceneEntrypoint.InGame)]
    public class AssetLoaderExampleConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<AssetLoaderExampleButton>().AsSingleton();
            containerDefinition.Bind<AssetLoaderExampleTool>().AsSingleton();
            containerDefinition.MultiBind<BottomBarModule>().ToProvider<BottomBarModuleProvider>().AsSingleton();
        }

        private class BottomBarModuleProvider : IProvider<BottomBarModule>
        {
            private readonly AssetLoaderExampleButton _assetLoaderExampleButton;

            public BottomBarModuleProvider(AssetLoaderExampleButton assetLoaderExampleButton) => _assetLoaderExampleButton = assetLoaderExampleButton;

            public BottomBarModule Get()
            {
                BottomBarModule.Builder builder = new();
                builder.AddRightSectionElement(_assetLoaderExampleButton);
                return builder.Build();
            }
        }
    }
}