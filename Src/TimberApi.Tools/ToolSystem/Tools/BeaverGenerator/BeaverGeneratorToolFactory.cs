using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BeaverGenerator;

internal class BeaverGeneratorToolFactory(Timberborn.BeaversUI.BeaverGeneratorTool beaverGeneratorTool)
    : IToolFactory
{
    public string Id => "BeaverGeneratorTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        return beaverGeneratorTool;
    }
}