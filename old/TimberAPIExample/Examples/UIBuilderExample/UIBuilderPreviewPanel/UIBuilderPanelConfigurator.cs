using TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews;

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
            UIBuilder uiBuilder = TimberAPI.DependencyContainer.GetInstance<UIBuilder>();
            LocalizableButton button = uiBuilder.Presets().Buttons().Button("menu.uipreview", new Length(244, Length.Unit.Pixel));
            button.clicked += UIBuilderPreviewBox.OpenPreviewBoxDelegate;
            uiBuilder.InitializeVisualElement(button);
            root.Insert(6, button);
        }
    }
    
    [HarmonyPatch(typeof(MainMenuPanel), "GetPanel")]
    public static class MainMenuPanelPatch
    {
        private static void Postfix(ref VisualElement __result)
        {
            VisualElement root = __result.Query("MainMenuPanel");
            UIBuilder uiBuilder = TimberAPI.DependencyContainer.GetInstance<UIBuilder>();
            LocalizableButton button = uiBuilder.Presets().Buttons().Button("menu.uipreview", new Length(244, Length.Unit.Pixel));
            button.clicked += UIBuilderPreviewBox.OpenPreviewBoxDelegate;
            uiBuilder.InitializeVisualElement(button);
            root.Insert(6, button);
        }
    }
}