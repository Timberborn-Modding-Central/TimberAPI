using Timberborn.BeaversUI;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.BeaverGenerator
{
    public class BeaverGeneratorToolFactory : IToolFactory
    {
        public string Id => "BeaverGeneratorTool";
        
        private readonly BeaverGeneratorTool _beaverGeneratorTool;

        public BeaverGeneratorToolFactory(BeaverGeneratorTool beaverGeneratorTool)
        {
            _beaverGeneratorTool = beaverGeneratorTool;
        }
        
        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            return _beaverGeneratorTool;
        }
    }
}