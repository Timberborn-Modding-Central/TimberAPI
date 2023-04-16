using TimberApi.ToolGroupSystem;
using Timberborn.Options;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.SettingBox
{
    public class SettingBoxTool : Tool
    {
        private readonly EventBus _eventBus;

        private readonly ToolGroupManager _toolGroupManager;

        public SettingBoxTool(ToolGroup? toolGroup, EventBus eventBus, ToolGroupManager toolGroupManager)
        {
            ToolGroup = toolGroup;
            _eventBus = eventBus;
            _toolGroupManager = toolGroupManager;
        }

        public override void Enter()
        {
            _toolGroupManager.SwitchToolGroup(new ExitingTool());
            _eventBus.Post(new ShowOptionsEvent());
        }

        public override void Exit()
        {
        }
    }
}