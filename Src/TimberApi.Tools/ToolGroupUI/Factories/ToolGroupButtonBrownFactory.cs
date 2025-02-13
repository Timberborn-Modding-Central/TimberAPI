using TimberApi.Tools.ToolGroupSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolGroupUI.Factories;

public class ToolGroupButtonBrownFactory(ToolGroupButtonFactory toolGroupButtonFactory) : IToolGroupButtonFactory
{
    public string Id => "Brown";

    public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpec toolGroupSpec)
    {
        return toolGroupButtonFactory.Create((ToolGroup)toolGroup, toolGroup.Icon, "UI/Images/BottomBar/subbutton-bg-01");
    }
}