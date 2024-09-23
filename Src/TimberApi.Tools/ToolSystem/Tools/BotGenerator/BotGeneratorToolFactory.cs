using Timberborn.BotsUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BotGenerator;

public class BotGeneratorToolFactory : IToolFactory
{
    private readonly BotGeneratorTool _botGeneratorTool;

    public BotGeneratorToolFactory(BotGeneratorTool botGeneratorTool)
    {
        _botGeneratorTool = botGeneratorTool;
    }

    public string Id => "BotGeneratorTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        return _botGeneratorTool;
    }
}