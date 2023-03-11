using UnityEngine;

namespace TimberApi.ToolGroupSystem
{
    public class ToolGroupSpecification : Timberborn.ToolSystem.ToolGroupSpecification
    {
        public string? GroupId { get; }

        public string Layout { get; }

        public string Section { get; }

        public bool DevModeTool { get; }

        public bool Hidden { get; }

        public ToolGroupSpecification(string id, string? groupId, string layout, int order, string nameLocKey, Sprite icon, string section, bool devModeTool, bool hidden, bool fallbackGroup)
            : base(id, order, nameLocKey, icon, fallbackGroup)
        {
            GroupId = groupId;
            Layout = layout;
            Section = section;
            DevModeTool = devModeTool;
            Hidden = hidden;
        }

        public ToolGroupSpecification(ToolGroupSpecification toolGroupSpecification)
            : base(toolGroupSpecification.Id, toolGroupSpecification.Order, toolGroupSpecification.NameLocKey, toolGroupSpecification.Icon, toolGroupSpecification.FallbackGroup)
        {
            GroupId = toolGroupSpecification.GroupId;
            Layout = toolGroupSpecification.Layout;
            Section = toolGroupSpecification.Section;
            DevModeTool = toolGroupSpecification.DevModeTool;
            Hidden = toolGroupSpecification.Hidden;
        }
    }

    public class ToolGroupSpecification<T> : ToolGroupSpecification
    {
        public T GroupInformation { get; }

        public ToolGroupSpecification(string id, string? groupId, string layout, int order, string nameLocKey, Sprite icon, string section, bool devModeTool, bool hidden, bool fallbackGroup, T groupInformation)
            : base(id, groupId, layout, order, nameLocKey, icon, section, devModeTool, hidden, fallbackGroup)
        {
            GroupInformation = groupInformation;
        }

        public ToolGroupSpecification(ToolGroupSpecification<T> toolGroupSpecification) : base(toolGroupSpecification)
        {
            GroupInformation = toolGroupSpecification.GroupInformation;
        }
    }
}