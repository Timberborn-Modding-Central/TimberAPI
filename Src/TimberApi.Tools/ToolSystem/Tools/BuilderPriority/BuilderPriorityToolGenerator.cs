using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.PrioritySystem;

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
                    NameLocKey = "CAN NOT BE MODIFIED",
                    DescriptionLocKey = "CAN NOT BE MODIFIED",
                    Hidden = false,
                    DevMode = false,
                },
                BuilderPriorityToolSpec = new
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
            ToolGroupSpec = new
            {
                Id = "Priority",
                Order = 50,
                NameLocKey = "ToolGroups.Priority",
                Icon = "Sprites/BottomBar/PriorityToolGroupIcon",
                FallbackGroup = false,
            },
            ToolGroupExtensionSpec = new
            {
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

        return new GeneratedSpec("Tools", "ToolGroupSpecification.Priority", json);
    }
}