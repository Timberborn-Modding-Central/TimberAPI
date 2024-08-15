using System;
using System.Collections.Generic;
using HarmonyLib;
using TimberApi.DependencyContainerSystem;
using TimberApi.UIBuilderSystem;
using TimberApi.UIPresets.Buttons;
using TimberApi.UIPresets.Labels;
using TimberApi.UIPresets.ListViews;
using TimberApi.UIPresets.Toggles;
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

    public static List<string> Test = new List<string>() { "item1", "item2" };
    
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
                backgroundColor = Color.gray
            }
        };
        
        Console.WriteLine("Hell my console writeline");
        
        test.Add(_uiBuilder.Create<DefaultListView>().SetMakeItem(VisualElement).SetItemSource(Test).SetSelectionType(SelectionType.Single).Build());

        _uiBuilder.Initialize(test);
        __instance._root.Add(test);

        return false;
    }

    private static VisualElement VisualElement()
    {
        Debug.LogError("AAAAAAA");
        return _uiBuilder.Build<ArrowUpButton>();
    }
}