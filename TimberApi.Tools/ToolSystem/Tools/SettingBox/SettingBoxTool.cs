using Timberborn.Options;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.SettingBox;

public class SettingBoxTool : Tool, IUnselectableTool
{
    private readonly IOptionsBox _optionsBox;


    public SettingBoxTool(ToolGroup? toolGroup, IOptionsBox optionsBox)
    {
        ToolGroup = toolGroup;
        _optionsBox = optionsBox;
    }

    public override void Enter()
    {
        _optionsBox.Show();
    }

    public override void Exit()
    {
    }
}