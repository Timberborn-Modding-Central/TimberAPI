using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.SettingBox;

public class SettingBoxToolGenerator : ISpecificationGenerator
{
    public IEnumerable<GeneratedSpecification> Generate()
    {
        yield return SettingBoxTool();
    }

    private static GeneratedSpecification SettingBoxTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "SettingBox",
            Type = "SettingBoxTool",
            Layout = "GrouplessRed",
            Order = 1000,
            NameLocKey = "CAN NOT BE MODIFIED",
            DescriptionLocKey = "CAN NOT BE MODIFIED",
            Icon = "Sprites/BottomBar/Options",
            DevMode = false,
            Hidden = false,
            ToolInformation = new
            {
                BottomBarSection = 2
            }
        });

        return new GeneratedSpecification("Tools", "ToolSpecification.SettingBox", json);
    }
}