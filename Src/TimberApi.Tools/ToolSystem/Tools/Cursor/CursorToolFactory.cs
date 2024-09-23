using Timberborn.CursorToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Cursor;

public class CursorToolFactory : IToolFactory
{
    private readonly CursorTool _cursorTool;

    public CursorToolFactory(CursorTool cursorTool)
    {
        _cursorTool = cursorTool;
    }

    public string Id => "CursorTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        _cursorTool.ToolGroup = toolGroup;

        return _cursorTool;
    }
}