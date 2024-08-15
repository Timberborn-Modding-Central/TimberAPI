using System.Diagnostics;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;
using TimberApi.UIPresets.Buttons;
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
        _root = new VisualElement();
        
        _root.Add(_builder.Create<GameToggle>().SetLocKey("SWAG").Build());
        _root.Add(_builder.Create<GameToggle>().Small().SetLocKey("SWAG").Build());

        _builder.Initialize(_root);
        return _root;
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