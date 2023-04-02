using Timberborn.ConstructionMode;
using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.ToolGroupSystem
{
    public sealed class ApiToolGroup : ToolGroup, IConstructionModeEnabler
    {
        public string Id { get; }

        public string? GroupId { get; }

        public string Section { get; }

        public bool DevMode { get; }

        public ApiToolGroup(string id, string? groupId, string section, string displayNameLocKey, bool devMode, Sprite icon)
        {
            Id = id;
            DisplayNameLocKey = displayNameLocKey;
            Icon = icon;
            DevMode = devMode;
            Section = section;
            GroupId = groupId;
        }
    }
}