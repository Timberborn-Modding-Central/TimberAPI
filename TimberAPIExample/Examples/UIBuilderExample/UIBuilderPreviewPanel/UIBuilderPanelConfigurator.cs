using Bindito.Core;
using HarmonyLib;
using TimberAPIExample.AutoConfiguratorInstaller;
using TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews;
using Timberborn.Options;
using TimberbornAPI.UIBuilderSystem;
using UnityEngine.UIElements;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel
{
    public class UIBuilderPanelConfigurator : IInGameConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<UIBuilderPreviewBox>().AsSingleton();
            containerDefinition.MultiBind<IUIBuilderPreview>().To<FragmentBackgroundPreview>().AsSingleton();
        }
    }
    
    [HarmonyPatch(typeof(OptionsBox), "GetPanel")]
    public static class MainMenuPanelPatch
    {
        private static void Postfix(ref VisualElement __result)
        {
            ElementFactory elementFactory = new ElementFactory();
            VisualElement root = __result.Query("OptionsBox");
            Button button = elementFactory.Button(new[] {"menu-button"}, "UI Previews");
            button.text = "UI Builder preview";
            button.clicked += UIBuilderPreviewBox.OpenPreviewBoxDelegate;
            root.Insert(6, button);
        }
    }
}