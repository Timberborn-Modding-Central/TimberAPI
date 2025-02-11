using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class DemolishingToolGenerator : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        yield return CreateDemolishingToolGroup();
        yield return DemolishableSelectionTool();
        yield return DeleteRecoveredGoodStackTool();
        yield return DemolishableUnselectionTool();
        yield return BuildingDeconstructionTool();
        yield return EntityBlockObjectDeletionTool();
    }

    private static GeneratedSpec EntityBlockObjectDeletionTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "EntityBlockObjectDeletion",
            GroupId = "Demolishing",
            Type = "EntityBlockObjectDeletionTool",
            Layout = "Default",
            Order = 30,
            NameLocKey = "CAN NOT BE MODIFIED",
            DescriptionLocKey = "CAN NOT BE MODIFIED",
            Icon = "Sprites/BottomBar/DeleteObjectIcon",
            DevMode = false,
            Hidden = false
        });

        return new GeneratedSpec("Tools", "ToolSpecification.EntityBlockObjectDeletion", json);
    }

    private static GeneratedSpec DeleteRecoveredGoodStackTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "DeleteRecoveredGoodStack",
            GroupId = "Demolishing",
            Type = "DeleteRecoveredGoodStackTool",
            Layout = "Default",
            Order = 10,
            NameLocKey = "CAN NOT BE MODIFIED",
            DescriptionLocKey = "CAN NOT BE MODIFIED",
            Icon = "Sprites/BottomBar/DeleteRecoveredGoodStackToolIcon",
            DevMode = false,
            Hidden = false
        });

        return new GeneratedSpec("Tools", "ToolSpecification.DeleteRecoveredGoodStack", json);
    }

    private static GeneratedSpec BuildingDeconstructionTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "BuildingDeconstruction",
            GroupId = "Demolishing",
            Type = "BuildingDeconstructionTool",
            Layout = "Default",
            Order = 0,
            NameLocKey = "CAN NOT BE MODIFIED",
            DescriptionLocKey = "CAN NOT BE MODIFIED",
            Icon = "Sprites/BottomBar/DeleteObjectIcon",
            DevMode = false,
            Hidden = false
        });

        return new GeneratedSpec("Tools", "ToolSpecification.BuildingDeconstruction", json);
    }

    private static GeneratedSpec DemolishableSelectionTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "DemolishableSelection",
            GroupId = "Demolishing",
            Type = "DemolishableSelectionTool",
            Layout = "Default",
            Order = 20,
            NameLocKey = "CAN NOT BE MODIFIED",
            DescriptionLocKey = "CAN NOT BE MODIFIED",
            Icon = "Sprites/BottomBar/DemolishResourcesTool",
            DevMode = false,
            Hidden = false
        });

        return new GeneratedSpec("Tools", "ToolSpecification.DemolishableSelection", json);
    }

    private static GeneratedSpec DemolishableUnselectionTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "DemolishableUnselection",
            GroupId = "Demolishing",
            Type = "DemolishableUnselectionTool",
            Layout = "Default",
            Order = 1000,
            NameLocKey = "CAN NOT BE MODIFIED",
            DescriptionLocKey = "CAN NOT BE MODIFIED",
            Icon = "Sprites/BottomBar/CancelToolIcon",
            DevMode = false,
            Hidden = false
        });

        return new GeneratedSpec("Tools", "ToolSpecification.DemolishableUnselection", json);
    }

    private static GeneratedSpec CreateDemolishingToolGroup()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "Demolishing",
            Layout = "Blue",
            Order = 40,
            Type = "ConstructionModeToolGroup",
            NameLocKey = "ToolGroups.Demolishing",
            Icon = "Sprites/BottomBar/DeleteGroupIcon",
            Section = "BottomBar",
            DevMode = false,
            Hidden = false,
            FallbackGroup = false,
            GroupInformation = new
            {
                BottomBarSection = 0
            }
        });

        return new GeneratedSpec("Tools", "ToolGroupSpecification.Demolishing", json);
    }
}