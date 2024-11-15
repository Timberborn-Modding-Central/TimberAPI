using Timberborn.Options;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.SettingBox;

public class SettingBoxTool(IOptionsBox optionsBox) : Tool, IUnselectableTool
{
    public override void Enter()
    {
        optionsBox.Show();
    }

    public override void Exit()
    {
    }
}