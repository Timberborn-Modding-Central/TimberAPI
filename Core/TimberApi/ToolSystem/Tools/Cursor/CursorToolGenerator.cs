using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;

namespace TimberApi.ToolSystem.Tools.Cursor
{
    public class CursorToolGenerator : ISpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "Cursor",
                Type = "CursorTool",
                Layout = "GrouplessRed",
                Order = 0,
                NameLocKey = "Cursor",
                DescriptionLocKey = "Cursor",
                Icon = "Sprites/BottomBar/Cursor",
                DevModeTool = false,
                Hidden = false,
                FallbackGroup = false,
                ToolInformation = new
                {
                    BottomBarSection = 0
                }
            });

            yield return new GeneratedSpecification(json, "Cursor", "ToolSpecification");
        }
    }
}