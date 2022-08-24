using Bindito.Core;
using Bindito.Unity;
using TimberApi.Core.Common;
using TimberApi.Core.ModLoaderSystem.ObjectDeserializers;
using TimberApi.Core2.ModSystem;
using Timberborn.WorldSerialization;
using UnityEngine;

namespace TimberApi.Core.ModLoaderSystem
{
    public class ModLoaderSystemConfigurator : PrefabConfigurator
    {
        public override void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ObjectSaveReaderWriter>().AsSingleton();
            containerDefinition.Bind<ModObjectDeserializer>().AsSingleton();
            containerDefinition.Bind<ModDependencyObjectDeserializer>().AsSingleton();
            containerDefinition.Bind<ModLanguagePathObjectDeserializer>().AsSingleton();

            containerDefinition.Bind<IModDependencySorter>().To<TopologicalSorter>().AsSingleton();
            containerDefinition.Bind<ModLoader>().AsSingleton();
            containerDefinition.Bind<ModRepository>().ToInstance(GetInstanceFromPrefab<ModRepository>());
            containerDefinition.Bind<IModRepository>().ToInstance(GetInstanceFromPrefab<ModRepository>());
        }

        public static void Prefab(GameObject parent)
        {
            PrefabBuilder.Create<ModLoaderSystemConfigurator>("ModLoaderSystemConfigurator")
                .AddGameObject<ModRepository>("ModRepository")
                .FinishAndSetParent(parent);
        }
    }
}