using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;

namespace TimberApi.ToolSystem.Tools.CancelPlanting
{
    public class CancelPlantingToolGenerator : ISpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate()
        {
            yield return FieldsCancelPlantingTool();
            yield return ForestryCancelPlantingTool();
        }
        
        private static GeneratedSpecification ForestryCancelPlantingTool()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "ForestryCancelPlanting",
                GroupId = "Forestry",
                Type = "CancelPlantingTool",
                Layout = "Brown",
                Order = 1000,
                NameLocKey = "CAN NOT BE MODIFIED",
                DescriptionLocKey = "CAN NOT BE MODIFIED",
                Icon = "Sprites/BottomBar/CancelToolIcon",
                DevModeTool = false,
                Hidden = false,
                FallbackGroup = false,
            });

            return new GeneratedSpecification(json, "TreeCuttingAreaUnselection", "ToolSpecification");
        }
        
        private static GeneratedSpecification FieldsCancelPlantingTool()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "FieldsCancelPlanting",
                GroupId = "Fields",
                Type = "CancelPlantingTool",
                Layout = "Brown",
                Order = 1000,
                NameLocKey = "CAN NOT BE MODIFIED",
                DescriptionLocKey = "CAN NOT BE MODIFIED",
                Icon = "Sprites/BottomBar/CancelToolIcon",
                DevModeTool = false,
                Hidden = false,
                FallbackGroup = false,
            });

            return new GeneratedSpecification(json, "TreeCuttingAreaSelection", "ToolSpecification");
        }
    }
}