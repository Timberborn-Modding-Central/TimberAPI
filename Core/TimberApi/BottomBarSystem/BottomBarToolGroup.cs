using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.BottomBarSystem
{
    public sealed class BottomBarToolGroup : ToolGroup
    {
        public string Id { get; }

        public bool DevModeToolGroup { get; }

        public BottomBarToolGroup(string id, string displayNameLocKey, bool devModeToolGroup, Sprite icon)
        {
            Id = id;
            DisplayNameLocKey = displayNameLocKey;
            Icon = icon;
            DevModeToolGroup = devModeToolGroup;
        }
    }
}