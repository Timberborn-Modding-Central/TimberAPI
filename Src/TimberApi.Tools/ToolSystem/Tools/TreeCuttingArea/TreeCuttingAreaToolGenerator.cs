using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.ForestryUI;

namespace TimberApi.Tools.ToolSystem.Tools.TreeCuttingArea;

public class TreeCuttingAreaToolGenerator : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        yield return CreateCuttingTreeGroup();
        yield return TreeCuttingAreaSelectionTool();
        yield return TreeCuttingAreaUnselectionTool();
    }

    private static GeneratedSpec TreeCuttingAreaUnselectionTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            ToolSpec = new
            {
                Id = "TreeCuttingAreaUnselection",
                GroupId = "TreeCutting",
                Type = "GenericTool",
                Layout = "Default",
                Order = 1000,
                NameLocKey = "Tool.FixedName",
                DescriptionLocKey = "Tool.FixedDescription",
                Icon = "Sprites/BottomBar/CancelToolIcon",
                DevMode = false,
                Hidden = false,
            },
            GenericToolSpec = new
            {
                ClassName = typeof(TreeCuttingAreaUnselectionTool).FullName
            },
            BottomBarSpec = new
            {
                Section = 0,
            },
        });

        return new GeneratedSpec("Tools", "Tool.TreeCuttingAreaUnselection", json);
    }

    private static GeneratedSpec TreeCuttingAreaSelectionTool()
    {
        var json = JsonConvert.SerializeObject(new
        {
            ToolSpec = new
            {
                Id = "TreeCuttingAreaSelection",
                GroupId = "TreeCutting",
                Type = "GenericTool",
                Layout = "Default",
                Order = 0,
                NameLocKey = "Tool.FixedName",
                DescriptionLocKey = "Tool.FixedDescription",
                Icon = "Sprites/BottomBar/TreeCuttingAreaSelectionTool",
                DevMode = false,
                Hidden = false,
            },
            GenericToolSpec = new
            {
                ClassName = typeof(TreeCuttingAreaSelectionTool).FullName
            },
            BottomBarSpec = new
            {
                Section = 0,
            },
        });

        return new GeneratedSpec("Tools", "Tool.TreeCuttingAreaSelection", json);
    }

    private static GeneratedSpec CreateCuttingTreeGroup()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TimberApiToolGroupSpec = new
            {
                Id = "TreeCutting",
                Order = 10,
                NameLocKey = "ToolGroups.TreeCutting",
                Icon = "Sprites/BottomBar/TreeToolGroupIcon",
                FallbackGroup = false,
                Type = "TreeCuttingAreaToolGroup",
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

        return new GeneratedSpec("ToolGroups", "TimberApiToolGroups.TreeCutting", json);
    }
}