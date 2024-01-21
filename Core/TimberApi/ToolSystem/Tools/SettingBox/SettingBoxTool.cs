using TimberApi.ToolGroupSystem;
using Timberborn.Options;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.SettingBox
{
    public class SettingBoxTool : Tool, IUnselectableTool
    {
        private readonly ToolGroupManager _toolGroupManager;

        private readonly IOptionsBox _optionsBox;

        public SettingBoxTool(ToolGroup? toolGroup, ToolGroupManager toolGroupManager, IOptionsBox optionsBox)
        {
            ToolGroup = toolGroup;
            _toolGroupManager = toolGroupManager;
            _optionsBox = optionsBox;
        }

        public override void Enter()
        {
            _toolGroupManager.SwitchToolGroup(new ExitingToolGroup());
            _optionsBox.Show();
        }

        public override void Exit()
        {
        }
    }
}