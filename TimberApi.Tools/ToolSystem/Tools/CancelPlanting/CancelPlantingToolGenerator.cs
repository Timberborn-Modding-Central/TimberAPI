using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.CancelPlanting;

public class CancelPlantingToolGenerator : ISpecificationGenerator
{
    public IEnumerable<GeneratedSpecification> Generate()
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
            Layout = "Default",
            Order = 1000,
            NameLocKey = "CAN NOT BE MODIFIED",
            DescriptionLocKey = "CAN NOT BE MODIFIED",
            Icon = "Sprites/BottomBar/CancelToolIcon",
            DevMode = false,
            Hidden = false
        });

        return new GeneratedSpecification("Tools", "ToolSpecification.ForestryCancelPlanting", json);
    }

    private static GeneratedSpecification FieldsCancelPlantingTool()
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

        return new GeneratedSpecification("Tools", "ToolSpecification.FieldsCancelPlanting", json);
    }
}