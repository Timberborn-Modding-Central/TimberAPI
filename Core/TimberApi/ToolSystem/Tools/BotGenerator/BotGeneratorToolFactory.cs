using Timberborn.BotsUI;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.BotGenerator
{
    public class BotGeneratorToolFactory : IToolFactory
    {
        public string Id => "BotGeneratorTool";

        private readonly BotGeneratorTool _botGeneratorTool;

        public BotGeneratorToolFactory(BotGeneratorTool botGeneratorTool)
        {
            _botGeneratorTool = botGeneratorTool;
        }

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            return _botGeneratorTool;
        }
    }
}