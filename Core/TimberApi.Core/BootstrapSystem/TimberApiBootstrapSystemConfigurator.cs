using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Bindito.Core;
using Bindito.Unity;
using TimberApi.Common.Extensions;
using TimberApi.Common.SingletonSystem;
using TimberApi.Core.ConfigSystem;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Core.LoggingSystem;
using TimberApi.Core.ModLoaderSystem;
using TimberApi.New;
using TimberApi.New.Common;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

namespace TimberApi.Core.BootstrapSystem
{
    internal class TimberApiBootstrapSystemConfigurator : PrefabConfigurator
    {
        private static string _timberApiInternalDll = "TimberApi.Internal.dll";

        public static TimberApiBootstrapSystemConfigurator Instance = null!;

        /// <summary>
        /// TimberApi bootstrapConfigurator
        /// </summary>
        public override void Configure(IContainerDefinition containerDefinition)
        {
            // TimberAPI core features
            containerDefinition.Install(new LoggingSystemConfigurator());
            containerDefinition.Install(GetInstanceFromPrefab<ConsoleSystemConfigurator>());
            containerDefinition.Install(GetInstanceFromPrefab<ModLoaderSystemConfigurator>());
            containerDefinition.Install(new ConfigSystemConfigurator());

            // Start runner
            containerDefinition.Bind<TimberApiCoreRunner>().AsSingleton();

            // TimberAPI features
            containerDefinition.Bind<ISingletonRepository>().To<SingletonRepository>().AsSingleton();
            var instance = new SingletonListener();
            containerDefinition.Bind<SingletonListener>().ToInstance(instance);
            containerDefinition.AddInjectionListener(instance);
            containerDefinition.AddProvisionListener(instance);

            LoadAndInstallTimberApiInternal(containerDefinition);

            containerDefinition.Bind<SingletonRunner>().AsSingleton();
        }

        /// <summary>
        /// Separating core functionalities with features
        /// </summary>
        /// <param name="containerDefinition"></param>
        private static void LoadAndInstallTimberApiInternal(IContainerDefinition containerDefinition)
        {
            Assembly.LoadFile(Path.Combine(Paths.Core, _timberApiInternalDll));
            BootstrapConfigurator.Configure(containerDefinition);
        }

        /// <summary>
        /// Register prefabConfigurators
        /// </summary>
        private void AddPrefabConfigurators()
        {
            ConsoleSystemConfigurator.Prefab(gameObject);
            ModLoaderSystemConfigurator.Prefab(gameObject);
        }

        /// <summary>
        /// The first active monoBehaviour of TimberApi
        /// </summary>
        private void Awake()
        {
            try
            {
                if (Versions.GameVersion < Versions.TimberApiMinimumGameVersion)
                {
                    ShowCompatabilityErrorElement();
                    return;
                }

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


        /// <summary>
        /// Message box when TimberAPI version is not compatible with game version
        /// </summary>
        private void ShowCompatabilityErrorElement()
        {
            var uiDocument = gameObject.AddComponent<UIDocument>();
            uiDocument.panelSettings = Resources.FindObjectsOfTypeAll<UIDocument>().First(document => document != uiDocument).panelSettings;
            uiDocument.sortingOrder = 100000;

            var errorMessageWrapper = new VisualElement() { style = { unityFontStyleAndWeight = FontStyle.Bold, color = Color.white, fontSize = 20, width = 650, paddingLeft = 10, backgroundColor = Color.red, marginLeft = 50, marginTop = 50}};
            var errorMessage = new Label("Version of TimberAPI is not compatible with the game version");
            var timberApiVersion = new Label("TimberAPI version: " + Versions.TimberApiVersion) { style = { marginTop = -8 }};
            var minimumGameVersion = new Label("Minimum game version: " + Versions.TimberApiMinimumGameVersion) { style = { marginTop = -8 }};
            var gameVersion = new Label("Current game version: " + Versions.GameVersion) { style = { marginTop = -8 }};

            errorMessageWrapper.Add(errorMessage);
            errorMessageWrapper.Add(timberApiVersion);
            errorMessageWrapper.Add(minimumGameVersion);
            errorMessageWrapper.Add(gameVersion);
            uiDocument.rootVisualElement.Add(errorMessageWrapper);
        }
    }
}