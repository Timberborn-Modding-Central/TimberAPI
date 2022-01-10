using Bindito.Core;
using Timberborn.BottomBarSystem;
using TimberbornAPI.DependencySystem;

namespace TimberAPIExample.Examples.AssetLoaderExample
{
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