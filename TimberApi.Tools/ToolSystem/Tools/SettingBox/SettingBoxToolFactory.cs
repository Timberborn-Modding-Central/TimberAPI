using Timberborn.Options;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.SettingBox;

public class SettingBoxToolFactory : IToolFactory
{
    private readonly IOptionsBox _optionsBox;

    public SettingBoxToolFactory(IOptionsBox optionsBox)
    {
        _optionsBox = optionsBox;
    }

    public string Id => "SettingBoxTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        return new SettingBoxTool(toolGroup, _optionsBox);
    }
}