using System.Diagnostics;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;
using TimberApi.UIPresets.Builders;
using TimberApi.UIPresets.Buttons;
using TimberApi.UIPresets.Labels;
using TimberApi.UIPresets.Sliders;
using TimberApi.UIPresets.Toggles;
using Timberborn.BaseComponentSystem;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

namespace Tester;

public class TestFragment : IEntityPanelFragment
{
    private readonly UIBuilder _builder;
    
    private VisualElement _root = null!;

    public TestFragment(UIBuilder builder)
    {
        _builder = builder;
    }

    public VisualElement InitializeFragment()
    {
        return _builder.Create<VisualElementBuilder>()
            .AddComponent<FragmentBuilder>(builder => builder.AddComponent<GameTextLabel>(button => button.SetText("Workplace").Big()))
            .AddComponent<FragmentBuilder>(builder => builder.PalePurple().AddComponent<GameTextLabel>(button => button.SetText("Workplace").Big()))
            .AddComponent<FragmentBuilder>(builder => builder.Purple().AddComponent<GameTextLabel>(button => button.SetText("Workplace").Big()))
            .AddComponent<FragmentBuilder>(builder => builder.PurpleStriped().AddComponent<GameTextLabel>(button => button.SetText("Workplace").Big()))
            .AddComponent<FragmentBuilder>(builder => builder.Red().AddComponent<GameTextLabel>(button => button.SetText("Workplace").Big()))
            .AddComponent<FragmentBuilder>(builder => builder.RedStriped().AddComponent<GameTextLabel>(button => button.SetText("Workplace").Big()))
            .AddComponent<FragmentBuilder>(builder => builder.Blue().AddComponent<GameTextLabel>(button => button.SetText("Workplace").Big()))
            .AddComponent<FragmentBuilder>(builder => builder.Gray().AddComponent<GameTextLabel>(button => button.SetText("Workplace").Big()))
            .BuildAndInitialize();
    }

    public void ShowFragment(BaseComponent entity)
    {
        _root.ToggleDisplayStyle(true);
    }

    public void ClearFragment()
    {
    }

    public void UpdateFragment()
    {
    }
}