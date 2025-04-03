using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.WaterBrushesUI;

namespace TimberApi.Tools.ToolSystem.Tools.WaterGenerator;

public class WaterGeneratorToolGenerator : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        var json = JsonConvert.SerializeObject(new
        {
            ToolSpec = new
            {
                Id = "WaterGenerator",
                Type = "GenericTool",
                Layout = "GrouplessRed",
                Order = 80,
                NameLocKey = "Tool.FixedName",
                DescriptionLocKey = "Tool.FixedDescription",
                Icon = "Sprites/BottomBar/WaterHeightBrushTool",
                DevMode = true,
                Hidden = false,
            },
            GenericToolSpec = new {
                ClassName = typeof(WaterHeightBrushTool).FullName
            },
            BottomBarSpec = new
            {
                Section = 0,
            },
        });

        yield return new GeneratedSpec("Root", "Tool.WaterGenerator", json);
    }
}