using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;

namespace TimberApi.ToolSystem.Tools.WaterGenerator
{
    public class WaterGeneratorToolGenerator : ISpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "WaterGenerator",
                Type = "WaterGeneratorTool",
                Layout = "GrouplessRed",
                Order = 80,
                NameLocKey = "Cursor",
                DescriptionLocKey = "Cursor",
                Icon = "Sprites/BottomBar/WaterHeightBrushTool",
                DevMode = true,
                Hidden = false,
                ToolInformation = new
                {
                    BottomBarSection = 0
                }
            });

            yield return new GeneratedSpecification(json, "WaterGenerator", "ToolSpecification");
        }
    }
}