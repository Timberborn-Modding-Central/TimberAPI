using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.ToolGroupSystem
{
    public class ApiToolGroup : ToolGroup, IToolGroup
    {
        public ApiToolGroup(string id, string? groupId, int order, string section, string displayNameLocKey, bool devMode, Sprite icon)
        {
            Id = id;
            base.DisplayNameLocKey = displayNameLocKey;
            Order = order;
            Icon = icon;
            DevMode = devMode;
            Section = section;
            GroupId = groupId;
        }

        public string Id { get; }

        public string? GroupId { get; }

        public int Order { get; }

        public string Section { get; }

        public bool DevMode { get; }
    }
}