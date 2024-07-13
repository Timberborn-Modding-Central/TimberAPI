using Timberborn.BeaversUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BeaverGenerator;

internal class BeaverGeneratorToolFactory : IToolFactory
{
    public string Id => "BeaverGeneratorTool";
        
    private readonly Timberborn.BeaversUI.BeaverGeneratorTool _beaverGeneratorTool;

    public BeaverGeneratorToolFactory(Timberborn.BeaversUI.BeaverGeneratorTool beaverGeneratorTool)
    {
        _beaverGeneratorTool = beaverGeneratorTool;
    }
        
    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        return _beaverGeneratorTool;
    }
}