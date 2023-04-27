using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;

namespace TimberApi.ToolSystem.Tools.BotGenerator
{
    public class BotGeneratorToolGenerator : ISpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate()
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
                DevModeTool = true,
                Hidden = false,
                FallbackGroup = false,
                ToolInformation = new
                {
                    BottomBarSection = 0
                }
            });

            yield return new GeneratedSpecification(json, "BotGenerator", "ToolSpecification");
        }
    }
}