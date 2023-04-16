using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;

namespace TimberApi.ToolSystem.Tools.TreeCuttingArea
{
    public class TreeCuttingAreaToolGenerator : ISpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate()
        {
            yield return CreateCuttingTreeGroup();
            yield return TreeCuttingAreaSelectionTool();
            yield return TreeCuttingAreaUnselectionTool();
        }

        private static GeneratedSpecification TreeCuttingAreaUnselectionTool()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "TreeCuttingAreaUnselection",
                GroupId = "TreeCutting",
                Type = "TreeCuttingAreaUnselectionTool",
                Layout = "Default",
                Order = 1000,
                NameLocKey = "CAN NOT BE MODIFIED",
                DescriptionLocKey = "CAN NOT BE MODIFIED",
                Icon = "Sprites/BottomBar/CancelToolIcon",
                DevModeTool = false,
                Hidden = false,
                FallbackGroup = false,
                ToolInformation = new
                {
                    BottomBarSection = 0
                }
            });

            return new GeneratedSpecification(json, "TreeCuttingAreaUnselection", "ToolSpecification");
        }

        private static GeneratedSpecification TreeCuttingAreaSelectionTool()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "TreeCuttingAreaSelection",
                GroupId = "TreeCutting",
                Type = "TreeCuttingAreaSelectionTool",
                Layout = "Default",
                Order = 0,
                NameLocKey = "CAN NOT BE MODIFIED",
                DescriptionLocKey = "CAN NOT BE MODIFIED",
                Icon = "Sprites/BottomBar/TreeCuttingAreaSelectionTool",
                DevModeTool = false,
                Hidden = false,
                FallbackGroup = false,
                ToolInformation = new
                {
                    BottomBarSection = 0
                }
            });

            return new GeneratedSpecification(json, "TreeCuttingAreaSelection", "ToolSpecification");
        }

        private static GeneratedSpecification CreateCuttingTreeGroup()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "TreeCutting",
                Layout = "Blue",
                Order = 10,
                Type = "TreeCuttingAreaToolGroup",
                NameLocKey = "ToolGroups.TreeCutting",
                Icon = "Sprites/BottomBar/TreeToolGroupIcon",
                Section = "BottomBar",
                DevMode = false,
                Hidden = false,
                FallbackGroup = false,
                GroupInformation = new
                {
                    BottomBarSection = 0
                }
            });

            return new GeneratedSpecification(json, "TreeCutting", "ToolGroupSpecification");
        }
    }
}