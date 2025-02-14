using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.CancelPlanting;

public class CancelPlantingToolGenerator : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        yield return FieldsCancelPlantingTool();
        yield return ForestryCancelPlantingTool();
    }

    private static GeneratedSpec ForestryCancelPlantingTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            ToolSpec = new
            {
                Id = "ForestryCancelPlanting",
                GroupId = "Forestry",
                Type = "CancelPlantingTool",
                Layout = "Default",
                Order = 1000,
                NameLocKey = "CAN NOT BE MODIFIED",
                DescriptionLocKey = "CAN NOT BE MODIFIED",
                Icon = "Sprites/BottomBar/CancelToolIcon",
                DevMode = false,
                Hidden = false
            }
        });

        return new GeneratedSpec("Tools", "Tool.ForestryCancelPlanting", json);
    }

    private static GeneratedSpec FieldsCancelPlantingTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "FieldsCancelPlanting",
            GroupId = "Fields",
            Type = "CancelPlantingTool",
            Layout = "Default",
            Order = 1000,
            NameLocKey = "CAN NOT BE MODIFIED",
            DescriptionLocKey = "CAN NOT BE MODIFIED",
            Icon = "Sprites/BottomBar/CancelToolIcon",
            DevMode = false,
            Hidden = false
        });

        return new GeneratedSpec("Tools", "Tool.FieldsCancelPlanting", json);
    }
}