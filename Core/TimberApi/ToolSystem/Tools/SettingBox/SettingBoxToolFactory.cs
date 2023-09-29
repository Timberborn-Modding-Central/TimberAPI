using Timberborn.Options;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.SettingBox
{
    public class SettingBoxToolFactory : IToolFactory
    {
        private readonly IOptionsBox _optionsBox;

        private readonly ToolGroupManager _toolGroupManager;

        public SettingBoxToolFactory(ToolGroupManager toolGroupManager, IOptionsBox optionsBox)
        {
            _toolGroupManager = toolGroupManager;
            _optionsBox = optionsBox;
        }

        public string Id => "SettingBoxTool";

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            return new SettingBoxTool(toolGroup, _toolGroupManager, _optionsBox);
        }
    }
}