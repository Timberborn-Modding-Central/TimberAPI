using Timberborn.BotsUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BotGenerator;

public class BotGeneratorToolFactory(BotGeneratorTool botGeneratorTool) : IToolFactory
{
    public string Id => "BotGeneratorTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        return botGeneratorTool;
    }
}