using HarmonyLib;
using TimberApi.DependencyContainerSystem;
using TimberApi.UIBuilderSystem;
using TimberApi.UIPresets.Buttons;
using TimberApi.UIPresets.Sliders;
using Timberborn.CoreUI;
using Timberborn.MainMenuScene;
using Timberborn.ModManagerScene;
using UnityEngine;
using UnityEngine.UIElements;

namespace Tester;

public class ModStarter : IModStarter
{
    public void StartMod()
    {
        var harmony = new Harmony("TimberApi.Testing");

        harmony.PatchAll();
    }
}

[HarmonyPatch(typeof(WelcomeScreenBox), nameof(WelcomeScreenBox.Load))]
public static class ModPatcher
{
    public static bool Prefix(WelcomeScreenBox __instance)
    {
        var uiBuilder = DependencyContainer.GetInstance<UIBuilder>();
        
        
        __instance._root = new VisualElement
        {
            style =
            {
                backgroundImage = new StyleBackground(Resources.Load<Sprite>("UIImages/core/default-thumbnail")),
                width = new Length(100, Length.Unit.Percent),
                height = new Length(100, Length.Unit.Percent),
                justifyContent = Justify.Center,
                alignItems = Align.Center
            }
        };
        var test = new VisualElement
        {
            style =
            {
                width = 600,
                paddingBottom = 20,
                paddingRight = 20,
                paddingLeft = 20,
                paddingTop = 20,
                backgroundColor = Color.gray
            }
        };
        
        test.Add(uiBuilder.Create<MainMenuSlider>().SetLowValue(10).SetHighValue(20).Build());
        test.Add(uiBuilder.Create<MainMenuSlider>().SetLowValue(10).SetHighValue(20).Small().Build());
        test.Add(uiBuilder.Create<MainMenuSlider>().SetLowValue(10).SetHighValue(20).Diamond().Build());
        test.Add(uiBuilder.Create<MainMenuSlider>().SetLowValue(10).SetHighValue(20).Diamond().Small().Build());
        
        test.Add(uiBuilder.Create<MainMenuTextSlider>().SetLowValue(10).SetHighValue(20).SetLabel("Swag").Build());
        test.Add(uiBuilder.Create<MainMenuTextSlider>().SetLowValue(10).SetHighValue(20).SetLabel("Swag").Small().Build());
        test.Add(uiBuilder.Create<MainMenuTextSlider>().SetLowValue(10).SetHighValue(20).SetLabel("Swag").Diamond().Build());
        test.Add(uiBuilder.Create<MainMenuTextSlider>().SetLowValue(10).SetHighValue(20).SetLabel("Swag").Diamond().Small().Build());

        test.Add(uiBuilder.Create<GameSlider>().SetLowValue(10).SetHighValue(20).SetLocKey("Swag").Build());
        test.Add(uiBuilder.Create<GameSlider>().SetLowValue(10).SetHighValue(20).SetLocKey("Swag").Small().Build());
        test.Add(uiBuilder.Create<GameSlider>().SetLowValue(10).SetHighValue(20).SetLocKey("Swag").Diamond().Build());
        test.Add(uiBuilder.Create<GameSlider>().SetLowValue(10).SetHighValue(20).SetLocKey("Swag").Diamond().Small().Build());
        
        test.Add(uiBuilder.Create<GameTextSlider>().SetLowValue(10).SetHighValue(20).SetLabel("Swag").Build());
        test.Add(uiBuilder.Create<GameTextSlider>().SetLowValue(10).SetHighValue(20).SetLabel("Swag").Small().Build());
        test.Add(uiBuilder.Create<GameTextSlider>().SetLowValue(10).SetHighValue(20).SetLabel("Swag").Diamond().Build());
        test.Add(uiBuilder.Create<GameTextSlider>().SetLowValue(10).SetHighValue(20).SetLabel("Swag").Diamond().Small().Build());
        
        uiBuilder.Initialize(test);
        __instance._root.Add(test);
        
        
        
        return false;
    }
}