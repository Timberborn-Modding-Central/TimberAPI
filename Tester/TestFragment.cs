using TimberApi.UIBuilderSystem;
using TimberApi.UIPresets.Buttons;
using Timberborn.BaseComponentSystem;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using UnityEngine.UIElements;

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
        return _root = _builder.Create<GameButton>().SetLocKey("AAAAAAAAAAAA").BuildAndInitialize();
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