using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.BeaversUI;

namespace TimberApi.Tools.ToolSystem.Tools.BeaverGenerator;

internal class BeaverGeneratorToolGenerator : ISpecificationGenerator
{
    public IEnumerable<GeneratedSpecification> Generate()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "BeaverGenerator",
            Type = "GenericTool",
            Layout = "GrouplessRed",
            Order = 60,
            NameLocKey = "Cursor",
            DescriptionLocKey = "Cursor",
            Icon = "Sprites/BottomBar/BeaverGeneratorTool",
            DevMode = true,
            Hidden = false,
            ToolInformation = new
            {
                BottomBarSection = 0,
                ClassName = typeof(BeaverGeneratorTool).FullName
            }
        });

        yield return new GeneratedSpecification("tools", "ToolSpecification.BeaverGenerator", json);
    }
}