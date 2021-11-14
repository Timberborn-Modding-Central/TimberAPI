using Bindito.Core;
using TimberAPIExample.AutoConfiguratorInstaller;
using Timberborn.BottomBarSystem;

namespace TimberAPIExample.Examples.AssetLoaderExample
{
    public class AssetLoaderExampleConfigurator : IInGameConfigurator
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

            public BottomBarModuleProvider(AssetLoaderExampleButton assetLoaderExampleButton) => this._assetLoaderExampleButton = assetLoaderExampleButton;

            public BottomBarModule Get()
            {
                BottomBarModule.Builder builder = new BottomBarModule.Builder();
                builder.AddRightSectionElement((IBottomBarElementProvider)this._assetLoaderExampleButton);
                return builder.Build();
            }
        }
    }
}