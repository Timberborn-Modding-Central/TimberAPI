using System.Collections.Generic;
using TimberApi.ToolGroupSystem;
using UnityEngine;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarToolGroupSpecification : ToolGroupSpecification<BottomBarGroupInformation>
    {
        public BottomBarToolGroupSpecification(string id, string? groupId, string layout, int order, string nameLocKey, Sprite icon, List<string> toolIds, string section, bool requireDevelopmentMode, bool hidden, bool fallbackGroup,
            BottomBarGroupInformation groupInformation) : base(id, groupId, layout, order, nameLocKey, icon, toolIds, section, requireDevelopmentMode, hidden, fallbackGroup, groupInformation)
        {
        }

        public BottomBarToolGroupSpecification(ToolGroupSpecification<BottomBarGroupInformation> toolGroupSpecification) : base(toolGroupSpecification)
        {
        }
    }
}