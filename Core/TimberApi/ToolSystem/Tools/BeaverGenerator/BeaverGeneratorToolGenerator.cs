using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;

namespace TimberApi.ToolSystem.Tools.BeaverGenerator
{
    public class BeaverGeneratorToolGenerator : ISpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate()
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