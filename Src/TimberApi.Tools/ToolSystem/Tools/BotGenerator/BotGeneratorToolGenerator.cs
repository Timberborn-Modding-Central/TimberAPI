using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.BotsUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BotGenerator;

public class BotGeneratorToolGenerator : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "BotGenerator",
            Type = "GenericTool",
            Layout = "GrouplessRed",
            Order = 70,
            NameLocKey = "Cursor",
            DescriptionLocKey = "Cursor",
            Icon = "Sprites/BottomBar/BotGeneratorTool",
            DevMode = true,
            Hidden = false,
            ToolInformation = new
            {
                BottomBarSection = 0,
                ClassName = typeof(BotGeneratorTool).FullName
            }
        });
        
        yield return new GeneratedSpec("Tools", "ToolSpecification.BotGenerator", json);
    }
}