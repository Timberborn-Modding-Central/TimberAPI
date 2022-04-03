using Bindito.Core;
using HarmonyLib;
using TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews;
using Timberborn.MainMenuScene;
using Timberborn.Options;
using UnityEngine.UIElements;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel
{
    public class UIBuilderPanelConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<UIBuilderPreviewBox>().AsSingleton();
            containerDefinition.MultiBind<IUIBuilderPreview>().To<BackgroundPreview>().AsSingleton();
            containerDefinition.MultiBind<IUIBuilderPreview>().To<ButtonPreview>().AsSingleton();
            containerDefinition.MultiBind<IUIBuilderPreview>().To<TogglePreview>().AsSingleton();
            containerDefinition.MultiBind<IUIBuilderPreview>().To<SliderPreview>().AsSingleton();
            containerDefinition.MultiBind<IUIBuilderPreview>().To<VisualElementBuilderPreview>().AsSingleton();
            containerDefinition.MultiBind<IUIBuilderPreview>().To<LabelPreview>().AsSingleton();
            containerDefinition.MultiBind<IUIBuilderPreview>().To<ListViewPreview>().AsSingleton();
            containerDefinition.MultiBind<IUIBuilderPreview>().To<CustomPreview>().AsSingleton();
            containerDefinition.MultiBind<IUIBuilderPreview>().To<TextFieldPreview>().AsSingleton();
        }
    }
    
    [HarmonyPatch(typeof(OptionsBox), "GetPanel")]
    public static class InGameMenuPanelPatch
    {
        private static void Postfix(ref VisualElement __result)
        {
            VisualElement root = __result.Query("OptionsBox");
            Button button = new Button() { classList = { "menu-button" }};
            button.text = "UI Builder preview";
            button.clicked += UIBuilderPreviewBox.OpenPreviewBoxDelegate;
            root.Insert(6, button);
        }
    }
    
    [HarmonyPatch(typeof(MainMenuPanel), "GetPanel")]
    public static class MainMenuPanelPatch
    {
        private static void Postfix(ref VisualElement __result)
        {
            VisualElement root = __result.Query("MainMenuPanel");
            Button button = new Button() { classList = { "menu-button" }};
            button.text = "UI Builder preview";
            button.clicked += UIBuilderPreviewBox.OpenPreviewBoxDelegate;
            root.Insert(6, button);
        }
    }
}