using Bindito.Core;
using TimberApi.Internal.ModLoaderSystem.ObjectDeserializers;
using Timberborn.WorldSerialization;

namespace TimberApi.Internal.ModLoaderSystem
{
    public class ModLoaderConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ObjectSaveReaderWriter>().AsSingleton();
            containerDefinition.Bind<ModObjectDeserializer>().AsSingleton();
            containerDefinition.Bind<ModDependencyObjectDeserializer>().AsSingleton();
            containerDefinition.Bind<ModLanguagePathObjectDeserializer>().AsSingleton();

            // containerDefinition.Bind<LoadableModRepository>().AsSingleton();
            containerDefinition.Bind<ModLoader>().AsSingleton();
        }

        // public static void Prefab(GameObject parent)
        // {
        //     PrefabBuilder.Create<ModLoader>("ModLoaderConfigurator")
        //         .FinishAndSetParent(parent);
        // }
    }
}