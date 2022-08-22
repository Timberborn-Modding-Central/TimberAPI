using Bindito.Core;
using TimberApi.Core.ModLoaderSystem.ObjectDeserializers;
using TimberApi.Core2.ModSystem;
using Timberborn.WorldSerialization;

namespace TimberApi.Core.ModLoaderSystem
{
    public class ModLoaderSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ObjectSaveReaderWriter>().AsSingleton();
            containerDefinition.Bind<ModObjectDeserializer>().AsSingleton();
            containerDefinition.Bind<ModDependencyObjectDeserializer>().AsSingleton();
            containerDefinition.Bind<ModLanguagePathObjectDeserializer>().AsSingleton();

            containerDefinition.Bind<IModDependencySorter>().To<TopologicalSorter>().AsSingleton();
            containerDefinition.Bind<ModLoader>().AsSingleton();
            containerDefinition.Bind<ModRepository>().AsSingleton();
            containerDefinition.Bind<IModRepository>().To<ModRepository>().AsSingleton();
        }
    }
}