using System.Linq;
using TimberApi.Tools.ToolSystem;
using TimberApi.UIPresets.Sliders;
using Timberborn.SingletonSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace Tester;

public class Test : ILoadableSingleton
{
    private readonly ToolService _toolService;

    public Test(ToolService toolService)
    {
        _toolService = toolService;
    }

    public void Load()
    {
        
        Debug.LogWarning($"Tool size is: {_toolService.Tools.Count()}");
    }
}

public class MyMinMax : GameTextMinMaxSlider<MyMinMax>
{
    protected override MyMinMax BuilderInstance => this;
    
    protected override MinMaxSlider InitializeRoot()
    {
        base.InitializeRoot();

        return MinMaxSliderBuilder.SetPadding(12).Build();
    }
}