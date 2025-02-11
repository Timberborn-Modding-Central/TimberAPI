using TimberApi.Tools.ToolGroupSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolGroupUI.Factories;

public class ToolGroupButtonBlueFactory(ToolGroupButtonFactory toolGroupButtonFactory) : IToolGroupButtonFactory
{
    public string Id => "Blue";

    public ToolGroupButton Create(IToolGroup toolGroup, TimberApiToolGroupSpec timberApiToolGroupSpec)
    {
        return toolGroupButtonFactory.Create((ToolGroup)toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-02");
    }
}