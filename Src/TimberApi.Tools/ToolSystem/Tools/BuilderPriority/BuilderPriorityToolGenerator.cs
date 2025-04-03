using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.BlueprintSystem;
using Timberborn.PrioritySystem;
using UnityEngine;

namespace TimberApi.Tools.ToolSystem.Tools.BuilderPriority;

public class BuilderPriorityToolGenerator : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        foreach (var priority in Priorities.Ascending)
        {
            var json = JsonConvert.SerializeObject(new
            {
                ToolSpec = new
                {
                    Id = priority,
                    GroupId = "Priority",
                    Type = "PriorityTool",
                    Layout = "Default",
                    Order = (int)priority,
                    Icon = $"Sprites/Priority/Buttons/{priority}",
                    NameLocKey = "Tool.FixedName",
                    DescriptionLocKey = "Tool.FixedDescription",
                    Hidden = false,
                    DevMode = false,
                },
                PriorityToolSpec = new
                {
                    Priority = priority
                }
            });
        
            yield return new GeneratedSpec("Tools", $"Tool.{priority.ToString()}", json);
        }

        yield return CreatePriorityToolGroup();
    }

    private static GeneratedSpec CreatePriorityToolGroup()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TimberApiToolGroupSpec = new
            {
                Id = "Priority",
                Order = 50,
                NameLocKey = "ToolGroups.Priority",
                Icon = "Sprites/BottomBar/PriorityToolGroupIcon",
                FallbackGroup = false,
                Type = "BuilderPriorityToolGroup",
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

        return new GeneratedSpec("ToolGroups", "TimberApiToolGroup.Priority", json);
    }
}