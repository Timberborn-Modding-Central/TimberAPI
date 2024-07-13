using TimberApi.Tools.ToolGroupSystem;
using Timberborn.ToolSystem;
using ToolGroupSpecification = Timberborn.ToolSystem.ToolGroupSpecification;

namespace TimberApi.Tools.ToolGroupUI.Factories;

public class ToolGroupButtonGreenFactory : IToolGroupButtonFactory
{
    private readonly ToolGroupButtonFactory _toolGroupButtonFactory;

    public ToolGroupButtonGreenFactory(ToolGroupButtonFactory toolGroupButtonFactory)
    {
        _toolGroupButtonFactory = toolGroupButtonFactory;
    }

    public string Id => "Green";

    public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
    {
        return _toolGroupButtonFactory.Create((ToolGroup) toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-03");
    }
}