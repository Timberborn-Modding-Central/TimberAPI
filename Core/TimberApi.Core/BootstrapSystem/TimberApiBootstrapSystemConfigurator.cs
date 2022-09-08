using System;
using System.IO;
using System.Linq;
using Bindito.Core;
using Bindito.Unity;
using TimberApi.Common;
using TimberApi.Common.SingletonSystem;
using TimberApi.Core.ConfigSystem;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Core.LoggingSystem;
using TimberApi.Core.ModLoaderSystem;
using TimberApi.New;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Core.BootstrapSystem
{
    internal class TimberApiBootstrapSystemConfigurator : PrefabConfigurator
    {
        public static TimberApiBootstrapSystemConfigurator Instance = null!;

        public override void Configure(IContainerDefinition containerDefinition)
        {
            // TimberAPI core features
            containerDefinition.Install(new LoggingSystemConfigurator());
            containerDefinition.Install(GetInstanceFromPrefab<ConsoleSystemConfigurator>());
            containerDefinition.Install(GetInstanceFromPrefab<ModLoaderSystemConfigurator>());
            containerDefinition.Install(new ConfigSystemConfigurator());

            // Start runner
            containerDefinition.Bind<TimberApiCoreRunner>().AsSingleton();

            // TimberAPI.New Initialization
            containerDefinition.Bind<ISingletonRepository>().To<SingletonRepository>().AsSingleton();
            var instance = new SingletonListener();
            containerDefinition.Bind<SingletonListener>().ToInstance(instance);
            containerDefinition.AddInjectionListener(instance);
            containerDefinition.AddProvisionListener(instance);

            containerDefinition.Install(new BootstrapConfigurator());

            containerDefinition.Bind<SingletonRunner>().AsSingleton();
        }

        private void AddPrefabConfigurators()
        {
            ConsoleSystemConfigurator.Prefab(gameObject);
            ModLoaderSystemConfigurator.Prefab(gameObject);
        }

        private void Awake()
        {
            try
            {
                Instance = this;
                AddPrefabConfigurators();
                BootstrapPatch.Apply();
            }
            catch (Exception e)
            {
                File.WriteAllText(Path.Combine(Paths.Logs, $"TimberApiLoadException-{DateTime.Now:yyyy-MM-dd-HH\\hmm\\mss\\s}.log"), e.ToString());
                throw;
            }
        }
    }
}