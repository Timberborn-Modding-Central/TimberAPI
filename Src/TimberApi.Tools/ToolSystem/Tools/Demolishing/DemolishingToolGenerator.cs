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
            ToolSpec = new
            {
                Id = "EntityBlockObjectDeletion",
                GroupId = "Demolishing",
                Type = "EntityBlockObjectDeletionTool",
                Layout = "Default",
                Order = 30,
                NameLocKey = "Tool.FixedName",
                DescriptionLocKey = "Tool.FixedDescription",
                Icon = "Sprites/BottomBar/DeleteObjectIcon",
                DevMode = false,
                Hidden = false
            },
        });

        return new GeneratedSpec("Tools", "Tool.EntityBlockObjectDeletion", json);
    }

    private static GeneratedSpec DeleteRecoveredGoodStackTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            ToolSpec = new
            {
                Id = "DeleteRecoveredGoodStack",
                GroupId = "Demolishing",
                Type = "DeleteRecoveredGoodStackTool",
                Layout = "Default",
                Order = 10,
                NameLocKey = "Tool.FixedName",
                DescriptionLocKey = "Tool.FixedDescription",
                Icon = "Sprites/BottomBar/DeleteRecoveredGoodStackToolIcon",
                DevMode = false,
                Hidden = false,
            },
            BottomBarSpec = new
            {
                Section = 1,
            },
        });

        return new GeneratedSpec("Tools", "Tool.DeleteRecoveredGoodStack", json);
    }

    private static GeneratedSpec BuildingDeconstructionTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            ToolSpec = new
            {
                Id = "BuildingDeconstruction",
                GroupId = "Demolishing",
                Type = "BuildingDeconstructionTool",
                Layout = "Default",
                Order = 0,
                NameLocKey = "Tool.FixedName",
                DescriptionLocKey = "Tool.FixedDescription",
                Icon = "Sprites/BottomBar/DeleteObjectIcon",
                DevMode = false,
                Hidden = false,
            },
            BottomBarSpec = new
            {
                Section = 1,
            },
        });

        return new GeneratedSpec("Tools", "Tool.BuildingDeconstruction", json);
    }

    private static GeneratedSpec DemolishableSelectionTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            ToolSpec = new
            {
                Id = "DemolishableSelection",
                GroupId = "Demolishing",
                Type = "DemolishableSelectionTool",
                Layout = "Default",
                Order = 20,
                NameLocKey = "Tool.FixedName",
                DescriptionLocKey = "Tool.FixedDescription",
                Icon = "Sprites/BottomBar/DemolishResourcesTool",
                DevMode = false,
                Hidden = false
            },
            BottomBarSpec = new
            {
                Section = 1,
            }
        });

        return new GeneratedSpec("Tools", "Tool.DemolishableSelection", json);
    }

    private static GeneratedSpec DemolishableUnselectionTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            ToolSpec = new
            {
                Id = "DemolishableUnselection",
                GroupId = "Demolishing",
                Type = "DemolishableUnselectionTool",
                Layout = "Default",
                Order = 1000,
                NameLocKey = "Tool.FixedName",
                DescriptionLocKey = "Tool.FixedDescription",
                Icon = "Sprites/BottomBar/CancelToolIcon",
                DevMode = false,
                Hidden = false
            },
            BottomBarSpec = new
            {
                Section = 1,
            }
        });

        return new GeneratedSpec("Tools", "Tool.DemolishableUnselection", json);
    }

    private static GeneratedSpec CreateDemolishingToolGroup()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TimberApiToolGroupSpec = new
            {
                Id = "Demolishing",
                Order = 40,
                NameLocKey = "ToolGroups.Demolishing",
                Icon = "Sprites/BottomBar/DeleteGroupIcon",
                FallbackGroup = false,
                Type = "ConstructionModeToolGroup",
                Layout = "Blue",
                Section = "BottomBar",
                DevMode = false,
                Hidden = false,
            },
            BottomBarSpec = new
            {
                Section = 0,
            }
        });

        return new GeneratedSpec("ToolGroups", "TimberApiToolGroup.Demolishing", json);
    }
}