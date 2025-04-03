using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.SettingBox;

public class SettingBoxToolGenerator : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        yield return SettingBoxTool();
    }

    private static GeneratedSpec SettingBoxTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            ToolSpec = new
            {
                Id = "SettingBox",
                Type = "GenericTool",
                Layout = "GrouplessRed",
                Order = 1000,
                NameLocKey = "Tool.FixedName",
                DescriptionLocKey = "Tool.FixedDescription",
                Icon = "Sprites/BottomBar/Options",
                DevMode = false,
                Hidden = false,
            },
            GenericToolSpec = new {
                ClassName = typeof(SettingBoxTool).FullName
            },
            BottomBarSpec = new
            {
                Section = 2,
            },
        });

        return new GeneratedSpec("Tools", "Tool.SettingBox", json);
    }
}