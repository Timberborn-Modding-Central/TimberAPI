using TimberApi.Tools.ToolGroupSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolGroupUI.Factories;

public class ToolGroupButtonRedFactory(ToolGroupButtonFactory toolGroupButtonFactory) : IToolGroupButtonFactory
{
    public string Id => "Red";

    public ToolGroupButton Create(IToolGroup toolGroup, TimberApiToolGroupSpec timberApiToolGroupSpecification)
    {
        return toolGroupButtonFactory.Create((ToolGroup)toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-01");
    }
}