using TimberApi.Tools.ToolGroupSystem;
using Timberborn.ToolSystem;
using ToolGroupSpecification = Timberborn.ToolSystem.ToolGroupSpecification;

namespace TimberApi.Tools.ToolGroupUI.Factories;

public class ToolGroupButtonBrownFactory : IToolGroupButtonFactory
{
    private readonly ToolGroupButtonFactory _toolGroupButtonFactory;

    public ToolGroupButtonBrownFactory(ToolGroupButtonFactory toolGroupButtonFactory)
    {
        _toolGroupButtonFactory = toolGroupButtonFactory;
    }

    public string Id => "Brown";

    public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
    {
        return _toolGroupButtonFactory.Create((ToolGroup) toolGroup, toolGroup.Icon, "UI/Images/BottomBar/subbutton-bg-01");
    }
}