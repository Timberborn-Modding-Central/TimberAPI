using Timberborn.CursorToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Cursor;

public class CursorToolFactory(CursorTool cursorTool) : IToolFactory
{
    public string Id => "CursorTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        cursorTool.ToolGroup = toolGroup;

        return cursorTool;
    }
}