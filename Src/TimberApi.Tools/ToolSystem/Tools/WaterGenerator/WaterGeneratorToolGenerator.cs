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
            Id = "WaterGenerator",
            Type = "GenericTool",
            Layout = "GrouplessRed",
            Order = 80,
            NameLocKey = "Cursor",
            DescriptionLocKey = "Cursor",
            Icon = "Sprites/BottomBar/WaterHeightBrushTool",
            DevMode = true,
            Hidden = false,
            ToolInformation = new
            {
                BottomBarSection = 0,
                ClassName = typeof(WaterHeightBrushTool).FullName
            }
        });

        yield return new GeneratedSpec("Root", "ToolSpecification.WaterGenerator", json);
    }
}