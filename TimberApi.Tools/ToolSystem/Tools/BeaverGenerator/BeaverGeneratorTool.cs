using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BeaverGenerator;

internal class BeaverGeneratorTool : ISpecificationGenerator
{
    public IEnumerable<GeneratedSpecification> Generate()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "BeaverGenerator",
            Type = "BeaverGeneratorTool",
            Layout = "GrouplessRed",
            Order = 60,
            NameLocKey = "Cursor",
            DescriptionLocKey = "Cursor",
            Icon = "Sprites/BottomBar/BeaverGeneratorTool",
            DevMode = true,
            Hidden = false,
            ToolInformation = new
            {
                BottomBarSection = 0
            }
        });

        yield return new GeneratedSpecification("tools", "ToolSpecification.BeaverGenerator", json);
    }
}