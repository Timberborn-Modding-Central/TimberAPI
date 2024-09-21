using System;
using System.Collections.Generic;
using HarmonyLib;
using TimberApi.DependencyContainerSystem;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIPresets.Builders;
using TimberApi.UIPresets.Buttons;
using TimberApi.UIPresets.Dropdowns;
using TimberApi.UIPresets.Labels;
using TimberApi.UIPresets.ListViews;
using TimberApi.UIPresets.ScrollViews;
using TimberApi.UIPresets.TextFields;
using TimberApi.UIPresets.Toggles;
using Timberborn.BatchControl;
using Timberborn.DropdownSystem;
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
    private static UIBuilder _uiBuilder = null!;

    public static bool Prefix(WelcomeScreenBox __instance)
    {
        _uiBuilder = DependencyContainer.GetInstance<UIBuilder>();
        
        
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
                backgroundColor = Color.gray,
                flexDirection = FlexDirection.Row,
            }
        };
        
        Console.WriteLine("Hell my console writeline");


        test.Add(_uiBuilder.Create<FragmentBuilder>()
            .AddComponent<DefaultTextField>()
            .AddComponent<DefaultTextField>(field => field.SetTextAlign(TextAnchor.MiddleLeft))
            .AddComponent<DefaultTextField>(field => field.SetTextAlign(TextAnchor.MiddleRight))
            .AddComponent<DefaultTextField>()
            .AddComponent<DefaultTextField>(field => field.Large())
            .Build());

        _uiBuilder.Initialize(test);
        __instance._root.Add(test);


        return false;
    }
}