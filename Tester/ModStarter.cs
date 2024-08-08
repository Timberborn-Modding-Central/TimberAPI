using HarmonyLib;
using TimberApi.DependencyContainerSystem;
using TimberApi.UIBuilderSystem;
using TimberApi.UIPresets.Buttons;
using TimberApi.UIPresets.Sliders;
using TimberApi.UIPresets.Toggles;
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
        
        test.Add(uiBuilder.Create<GameMinMaxSlider>().SetLowLimit(1).SetHighLimit(20).SetValue(new Vector2(5, 10)).SetLocKey("Swa").Build());
        test.Add(uiBuilder.Create<GameMinMaxSlider>().SetLowLimit(1).SetHighLimit(20).SetValue(new Vector2(5, 10)).SetLocKey("Swa").Small().Build());

        test.Add(uiBuilder.Create<GameMinMaxSlider>().SetLowLimit(1).SetHighLimit(20).SetValue(new Vector2(5, 10)).SetLocKey("Swa").Diamond().Build());
        test.Add(uiBuilder.Create<GameMinMaxSlider>().SetLowLimit(1).SetHighLimit(20).SetValue(new Vector2(5, 10)).SetLocKey("Swa").Diamond().Small().Build());
        
        test.Add(uiBuilder.Create<GameTextMinMaxSlider>().SetLowLimit(1).SetHighLimit(20).SetValue(new Vector2(5, 10)).SetLabel("Swa").Build());
        test.Add(uiBuilder.Create<GameTextMinMaxSlider>().SetLowLimit(1).SetHighLimit(20).SetValue(new Vector2(5, 10)).SetLabel("Swa").Small().Build());

        test.Add(uiBuilder.Create<GameTextMinMaxSlider>().SetLowLimit(1).SetHighLimit(20).SetValue(new Vector2(5, 10)).SetLabel("Swa").Diamond().Build());
        test.Add(uiBuilder.Create<GameTextMinMaxSlider>().SetLowLimit(1).SetHighLimit(20).SetValue(new Vector2(5, 10)).SetLabel("Swa").Diamond().Small().Build());

        uiBuilder.Initialize(test);
        __instance._root.Add(test);

        return false;
    }

}