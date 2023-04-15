using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.SettingBox
{
    public class SettingBoxToolFactory : IToolFactory
    {
        public string Id => "SettingBoxTool";

        private readonly EventBus _eventBus;

        private readonly ToolGroupManager _toolGroupManager;
        
        public SettingBoxToolFactory(EventBus eventBus, ToolGroupManager toolGroupManager)
        {
            _eventBus = eventBus;
            _toolGroupManager = toolGroupManager;
        }

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            return new SettingBoxTool(toolGroup, _eventBus, _toolGroupManager);
        }
    }
}