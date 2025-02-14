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
            ToolSpec = new
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
            },
            GenericToolSpec = new {
                ClassName = typeof(BotGeneratorTool).FullName
            },
            BottomBarSpec = new
            {
                Section = 0,
            }
            
        });
        
        yield return new GeneratedSpec("Tools", "Tool.BotGenerator", json);
    }
}