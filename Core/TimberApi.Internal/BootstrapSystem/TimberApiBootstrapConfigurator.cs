using System;
using System.IO;
using System.Linq;
using Bindito.Core;
using Bindito.Unity;
using TimberApi.Internal.Common;
using TimberApi.Internal.DependencyContainerSystem;
using TimberApi.Internal.LoggingSystem;
using TimberApi.Internal.ModLoaderSystem;
using TimberApi.Internal.TimberApiVisualizer;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Internal.BootstrapSystem
{
    internal class TimberApiBootstrapConfigurator : PrefabConfigurator
    {
        public static TimberApiBootstrapConfigurator Instance = null!;

        /// <summary>
        /// TimberApi bootstrapConfigurator
        /// </summary>
        public override void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Install(new DependencyContainerConfigurator());
            containerDefinition.Install(GetInstanceFromPrefab<LoggingConfigurator>());
            containerDefinition.Bind<Visualizer>().AsSingleton();
            containerDefinition.Install(new ModLoaderConfigurator());
        }

        /// <summary>
        /// Register prefabConfigurators
        /// </summary>
        private void AddPrefabConfigurators()
        {
            LoggingConfigurator.Prefab(gameObject);
        }


        /// <summary>
        /// The first active monoBehaviour of TimberApi
        /// </summary>
        private void Awake()
        {
            try
            {
                if (TimberApiVersions.GameVersion < TimberApiVersions.MinimumGameVersion)
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


        private void ShowCompatabilityErrorElement()
        {
            var uiDocument = gameObject.AddComponent<UIDocument>();
            uiDocument.panelSettings = Resources.FindObjectsOfTypeAll<UIDocument>().First(document => document != uiDocument).panelSettings;
            uiDocument.sortingOrder = 100000;

            var errorMessageWrapper = new VisualElement() { style = { unityFontStyleAndWeight = FontStyle.Bold, color = Color.white, fontSize = 20, width = 650, paddingLeft = 10, backgroundColor = Color.red, marginLeft = 50, marginTop = 50}};
            var errorMessage = new Label("Version of TimberAPI is not compatible with the game version");
            var timberApiVersion = new Label("TimberAPI version: " + TimberApiVersions.TimberApiVersion) { style = { marginTop = -8 }};
            var minimumGameVersion = new Label("Minimum game version: " + TimberApiVersions.MinimumGameVersion) { style = { marginTop = -8 }};
            var gameVersion = new Label("Current game version: " + TimberApiVersions.GameVersion) { style = { marginTop = -8 }};

            errorMessageWrapper.Add(errorMessage);
            errorMessageWrapper.Add(timberApiVersion);
            errorMessageWrapper.Add(minimumGameVersion);
            errorMessageWrapper.Add(gameVersion);
            uiDocument.rootVisualElement.Add(errorMessageWrapper);
        }
    }
}