using System.Collections.Generic;
using UnityEngine;

namespace TimberApi.ToolGroupSystem
{
    public class ToolGroupSpecification : Timberborn.ToolSystem.ToolGroupSpecification
    {
        public string? GroupId { get; }

        public string Layout { get; set; }

        public List<string> ToolIds { get; }

        public string Section { get; }

        public bool RequireDevelopmentMode { get; }

        public bool Hidden { get; }

        public ToolGroupSpecification(string id, string? groupId, string layout, int order, string nameLocKey, Sprite icon, List<string> toolIds, string section, bool requireDevelopmentMode, bool hidden, bool fallbackGroup)
            : base(id, order, nameLocKey, icon, fallbackGroup)
        {
            GroupId = groupId;
            Layout = layout;
            ToolIds = toolIds;
            Section = section;
            RequireDevelopmentMode = requireDevelopmentMode;
            Hidden = hidden;
        }

        public ToolGroupSpecification(ToolGroupSpecification toolGroupSpecification)
            : base(toolGroupSpecification.Id, toolGroupSpecification.Order, toolGroupSpecification.NameLocKey, toolGroupSpecification.Icon, toolGroupSpecification.FallbackGroup)
        {
            GroupId = toolGroupSpecification.GroupId;
            Layout = toolGroupSpecification.Layout;
            ToolIds = toolGroupSpecification.ToolIds;
            Section = toolGroupSpecification.Section;
            RequireDevelopmentMode = toolGroupSpecification.RequireDevelopmentMode;
            Hidden = toolGroupSpecification.Hidden;
        }
    }

    public class ToolGroupSpecification<T> : ToolGroupSpecification
    {
        public T GroupInformation { get; }

        public ToolGroupSpecification(string id, string? groupId, string layout, int order, string nameLocKey, Sprite icon, List<string> toolIds, string section, bool requireDevelopmentMode, bool hidden, bool fallbackGroup, T groupInformation)
            : base(id, groupId, layout, order, nameLocKey, icon, toolIds, section, requireDevelopmentMode, hidden, fallbackGroup)
        {
            GroupInformation = groupInformation;
        }

        public ToolGroupSpecification(ToolGroupSpecification<T> toolGroupSpecification) : base(toolGroupSpecification)
        {
            GroupInformation = toolGroupSpecification.GroupInformation;
        }
    }
}