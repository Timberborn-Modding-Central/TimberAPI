using UnityEngine;

namespace TimberApi.ToolGroupSystem.ToolGroups.TreeCuttingArea
{
    public sealed class TreeCuttingAreaToolGroup : Timberborn.ForestryUI.TreeCuttingAreaToolGroup, IToolGroup
    {
        public string Id { get; }

        public string? GroupId { get; }

        public int Order { get; }

        public string Section { get; }

        public bool DevMode { get; }

        public TreeCuttingAreaToolGroup(string id, string? groupId, int order, string section, string displayNameLocKey, bool devMode, Sprite icon)
        {
            Id = id;
            DisplayNameLocKey = displayNameLocKey;
            Order = order;
            Icon = icon;
            DevMode = devMode;
            Section = section;
            GroupId = groupId;
        }
    }
}