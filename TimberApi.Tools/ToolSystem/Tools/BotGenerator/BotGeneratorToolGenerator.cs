using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BotGenerator;

public class BotGeneratorToolGenerator : ISpecificationGenerator
{
    public IEnumerable<GeneratedSpecification> Generate()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "BotGenerator",
            Type = "BotGeneratorTool",
            Layout = "GrouplessRed",
            Order = 70,
            NameLocKey = "Cursor",
            DescriptionLocKey = "Cursor",
            Icon = "Sprites/BottomBar/BotGeneratorTool",
            DevMode = true,
            Hidden = false,
            ToolInformation = new
            {
                BottomBarSection = 0
            }
        });

        yield return new GeneratedSpecification("Tools", "ToolSpecification.BotGenerator", json);
    }
}