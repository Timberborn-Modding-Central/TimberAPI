using TimberApi.ToolGroupSystem;
using UnityEngine;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarToolGroupSpecification : ToolGroupSpecification<BottomBarGroupInformation>
    {
        public BottomBarToolGroupSpecification(string id, string? groupId, string layout, int order, string nameLocKey, Sprite icon, string section, bool devModeTool, bool hidden, bool fallbackGroup,
            BottomBarGroupInformation groupInformation) : base(id, groupId, layout, order, nameLocKey, icon, section, devModeTool, hidden, fallbackGroup, groupInformation)
        {
        }

        public BottomBarToolGroupSpecification(ToolGroupSpecification<BottomBarGroupInformation> toolGroupSpecification) : base(toolGroupSpecification)
        {
        }
    }
}