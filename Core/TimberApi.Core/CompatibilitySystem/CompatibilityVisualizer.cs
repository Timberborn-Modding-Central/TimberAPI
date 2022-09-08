using System.Linq;
using TimberApi.Common;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Core.CompatibilitySystem
{
    public class CompatibilityVisualizer : MonoBehaviour
    {
        private void Awake()
        {
            ShowCompatibilityErrorElement();
        }

        private void ShowCompatibilityErrorElement()
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