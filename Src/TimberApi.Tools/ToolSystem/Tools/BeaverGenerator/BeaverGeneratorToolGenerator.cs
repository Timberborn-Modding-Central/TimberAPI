using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.BeaversUI;

namespace TimberApi.Tools.ToolSystem.Tools.BeaverGenerator;

internal class BeaverGeneratorToolGenerator : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        var json = JsonConvert.SerializeObject(new
        {
            ToolSpec = new
            {
                Id = "BeaverGenerator",
                Type = "GenericTool",
                Layout = "GrouplessRed",
                Order = 60,
                NameLocKey = "Tool.FixedName",
                DescriptionLocKey = "Tool.FixedDescription",
                Icon = "Sprites/BottomBar/BeaverGeneratorTool",
                DevMode = true,
                Hidden = false,
            },
            GenericToolSpec = new {
                ClassName = typeof(BeaverGeneratorTool).FullName
            },
            BottomBarSpec = new
            {
                Section = 0,
            }
        });

        yield return new GeneratedSpec("tools", "Tool.BeaverGenerator", json);
    }
}