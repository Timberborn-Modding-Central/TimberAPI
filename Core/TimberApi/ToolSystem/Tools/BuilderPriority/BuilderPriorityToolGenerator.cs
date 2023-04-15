using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using Timberborn.PrioritySystem;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace TimberApi.ToolSystem.Tools.BuilderPriority
{
    public class BuilderPriorityToolGenerator : ISpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate()
        {
            foreach (var priority in Priorities.Ascending)
            {
                var json = JsonConvert.SerializeObject(new
                {
                    Id = priority,
                    GroupId = "Priority",
                    Type = "PriorityTool",
                    Layout = "Brown",
                    Order = (int) priority,
                    Icon = $"Sprites/Priority/Buttons/{priority}",
                    NameLocKey = "CAN NOT BE MODIFIED",
                    DescriptionLocKey = "CAN NOT BE MODIFIED",
                    Hidden = false,
                    DevModeTool = false,
                    FallbackGroup = false,
                    ToolInformation = new
                    {
                        Priority = priority
                    }
                });
                
                yield return new GeneratedSpecification(json, priority.ToString(), "ToolSpecification");
            }
            
            yield return CreatePriorityToolGroup();
        }

        private static GeneratedSpecification CreatePriorityToolGroup()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "Priority",
                Layout = "Blue",
                Order = 40,
                Type = "DefaultToolGroup",
                NameLocKey = "ToolGroups.Priority",
                Icon = "Sprites/BottomBar/PriorityToolGroupIcon",
                Section = "BottomBar",
                DevMode = false,
                Hidden = false,
                FallbackGroup = false,
                GroupInformation = new
                {
                    BottomBarSection = 0
                }
            });
            
            return new GeneratedSpecification(json, "Priority", "ToolGroupSpecification");
        }
    }
}