using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.ToolGroupSystem
{
    public class ApiToolGroup : ToolGroup
    {
        public string Id { get; }

        public string? GroupId { get; }

        public string Section { get; }

        public bool DevMode { get; }

        public ApiToolGroup(string id, string? groupId, string section, string displayNameLocKey, bool devMode, Sprite icon)
        {
            Id = id;
            base.DisplayNameLocKey = displayNameLocKey;
            Icon = icon;
            DevMode = devMode;
            Section = section;
            GroupId = groupId;
        }
    }
}