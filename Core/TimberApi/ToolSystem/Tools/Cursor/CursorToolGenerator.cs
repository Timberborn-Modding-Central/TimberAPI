using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using Timberborn.PrefabSystem;

namespace TimberApi.ToolSystem.Tools.Cursor
{
    public class CursorToolGenerator : IObjectSpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate(ObjectCollectionService objectCollectionService)
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