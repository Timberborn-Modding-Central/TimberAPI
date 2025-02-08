using TimberApi.Tools.ToolGroupSystem;
using Timberborn.ToolSystem;
using ToolGroupSpec = TimberApi.Tools.ToolGroupSystem.ToolGroupSpec;

namespace TimberApi.Tools.ToolGroupUI.Factories;

public class ToolGroupButtonGreenFactory(ToolGroupButtonFactory toolGroupButtonFactory) : IToolGroupButtonFactory
{
    public string Id => "Green";

    public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpec toolGroupSpecification)
    {
        return toolGroupButtonFactory.Create((ToolGroup)toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-03");
    }
}