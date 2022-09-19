using System;
using System.IO;
using Bindito.Core;
using Bindito.Unity;
using TimberApi.Common;
using TimberApi.Core.ConfigSystem;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Core.LoggingSystem;
using TimberApi.Core.ModLoaderSystem;
using TimberApi.Core.SingletonSystem;

namespace TimberApi.Core.BootstrapSystem
{
    internal class TimberApiBootstrapSystemConfigurator : PrefabConfigurator
    {
        public static TimberApiBootstrapSystemConfigurator Instance = null!;

        private void Awake()
        {
            try
            {
                Instance = this;
                AddPrefabConfigurators();
                BootstrapPatcher.Patch();
                SingletonSystemPatcher.Patch();
            }
            catch (Exception e)
            {
                File.WriteAllText(Path.Combine(Paths.Logs, $"TimberApiLoadException-{DateTime.Now:yyyy-MM-dd-HH\\hmm\\mss\\s}.log"), e.ToString());
                throw;
            }
        }

        public override void Configure(IContainerDefinition containerDefinition)
        {
            // TimberAPI core features
            containerDefinition.Install(new LoggingSystemConfigurator());
            containerDefinition.Install(GetInstanceFromPrefab<ConsoleSystemConfigurator>());
            containerDefinition.Install(GetInstanceFromPrefab<ModLoaderSystemConfigurator>());
            containerDefinition.Install(new ConfigSystemConfigurator());

            // Start runner
            containerDefinition.Bind<TimberApiCoreRunner>().AsSingleton();

            // TimberAPI Initialization
            containerDefinition.Install(new BootstrapConfigurator());
        }

        private void AddPrefabConfigurators()
        {
            ConsoleSystemConfigurator.Prefab(gameObject);
            ModLoaderSystemConfigurator.Prefab(gameObject);
        }
    }
}