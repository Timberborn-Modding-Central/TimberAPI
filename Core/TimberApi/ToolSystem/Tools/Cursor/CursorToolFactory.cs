using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.Cursor
{
    public class CursorToolFactory : IToolFactory
    {
        public string Id => "CursorTool";
        
        private readonly Timberborn.CursorToolSystem.CursorTool _cursorTool;

        public CursorToolFactory(Timberborn.CursorToolSystem.CursorTool cursorTool)
        {
            _cursorTool = cursorTool;
        }

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            return _cursorTool;
        }
    }
}