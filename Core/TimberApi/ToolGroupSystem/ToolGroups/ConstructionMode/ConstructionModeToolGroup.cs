using Timberborn.ConstructionMode;
using UnityEngine;

namespace TimberApi.ToolGroupSystem.ToolGroups.ConstructionMode
{
    public class ConstructionModeToolGroup : ApiToolGroup, IConstructionModeEnabler
    {
        public ConstructionModeToolGroup(string id, string? groupId, string section, string displayNameLocKey, bool devMode, Sprite icon)
            : base(id, groupId, section, displayNameLocKey, devMode, icon)
        {
        }
    }
}