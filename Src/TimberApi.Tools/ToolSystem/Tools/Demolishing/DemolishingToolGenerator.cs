using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class DemolishingToolGenerator : ISpecificationGenerator
{
    public IEnumerable<GeneratedSpecification> Generate()
    {
        yield return CreateDemolishingToolGroup();
        yield return DemolishableSelectionTool();
        yield return DeleteRecoveredGoodStackTool();
        yield return DemolishableUnselectionTool();
        yield return BuildingDeconstructionTool();
        yield return EntityBlockObjectDeletionTool();
    }

    private static GeneratedSpecification EntityBlockObjectDeletionTool()
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

        return new GeneratedSpecification("Tools", "ToolSpecification.EntityBlockObjectDeletion", json);
    }

    private static GeneratedSpecification DeleteRecoveredGoodStackTool()
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

        return new GeneratedSpecification("Tools", "ToolSpecification.DeleteRecoveredGoodStack", json);
    }

    private static GeneratedSpecification BuildingDeconstructionTool()
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

        return new GeneratedSpecification("Tools", "ToolSpecification.BuildingDeconstruction", json);
    }

    private static GeneratedSpecification DemolishableSelectionTool()
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

        return new GeneratedSpecification("Tools", "ToolSpecification.DemolishableSelection", json);
    }

    private static GeneratedSpecification DemolishableUnselectionTool()
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

        return new GeneratedSpecification("Tools", "ToolSpecification.DemolishableUnselection", json);
    }

    private static GeneratedSpecification CreateDemolishingToolGroup()
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

        return new GeneratedSpecification("Tools", "ToolGroupSpecification.Demolishing", json);
    }
}