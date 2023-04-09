using Timberborn.PlantingUI;
using UnityEngine;

namespace TimberApi.ToolGroupSystem.ToolGroups.PlantingMode
{
    public class PlantingModeToolGroup : ApiToolGroup, IPlantingToolGroup
    {
        public PlantingModeToolGroup(string id, string? groupId, string section, string displayNameLocKey, bool devMode, Sprite icon)
            : base(id, groupId, section, displayNameLocKey, devMode, icon)
        {
        }
    }
}