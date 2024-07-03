using TimberApi.Tools.ToolGroupSystem;
using Timberborn.ToolSystem;
using ToolGroupSpecification = Timberborn.ToolSystem.ToolGroupSpecification;

namespace TimberApi.Tools.ToolGroupUI.Factories;

public class ToolGroupButtonBlueFactory : IToolGroupButtonFactory
{
    private readonly ToolGroupButtonFactory _toolGroupButtonFactory;

    public ToolGroupButtonBlueFactory(ToolGroupButtonFactory toolGroupButtonFactory)
    {
        _toolGroupButtonFactory = toolGroupButtonFactory;
    }

    public string Id => "Blue";

    public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
    {
        return _toolGroupButtonFactory.Create((ToolGroup) toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-02");
    }
}