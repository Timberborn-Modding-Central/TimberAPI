using TimberApi.Tools.ToolGroupSystem;
using Timberborn.ToolSystem;
using ToolGroupSpec = TimberApi.Tools.ToolGroupSystem.ToolGroupSpec;

namespace TimberApi.Tools.ToolGroupUI.Factories;

public class ToolGroupButtonRedFactory(ToolGroupButtonFactory toolGroupButtonFactory) : IToolGroupButtonFactory
{
    public string Id => "Red";

    public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpec toolGroupSpecification)
    {
        return toolGroupButtonFactory.Create((ToolGroup)toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-01");
    }
}