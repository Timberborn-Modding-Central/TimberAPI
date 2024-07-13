using TimberApi.Tools.ToolGroupSystem;
using Timberborn.ToolSystem;
using ToolGroupSpecification = Timberborn.ToolSystem.ToolGroupSpecification;

namespace TimberApi.Tools.ToolGroupUI.Factories;

public class ToolGroupButtonRedFactory : IToolGroupButtonFactory
{
    private readonly ToolGroupButtonFactory _toolGroupButtonFactory;

    public ToolGroupButtonRedFactory(ToolGroupButtonFactory toolGroupButtonFactory)
    {
        _toolGroupButtonFactory = toolGroupButtonFactory;
    }

    public string Id => "Red";

    public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
    {
        return _toolGroupButtonFactory.Create((ToolGroup) toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-01");
    }
}