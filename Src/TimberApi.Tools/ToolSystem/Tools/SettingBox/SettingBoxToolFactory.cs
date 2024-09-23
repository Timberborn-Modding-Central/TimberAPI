using Timberborn.Options;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.SettingBox;

public class SettingBoxToolFactory(IOptionsBox optionsBox) : IToolFactory
{
    public string Id => "SettingBoxTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        return new SettingBoxTool(toolGroup, optionsBox);
    }
}