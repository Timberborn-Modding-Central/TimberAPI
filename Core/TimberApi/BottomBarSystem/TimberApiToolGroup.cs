using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.BottomBarSystem
{
    public sealed class BottomBarToolGroup : ToolGroup
    {
        public string Id { get; }

        public BottomBarToolGroup(string id, string displayNameLocKey, Sprite icon)
        {
            Id = id;
            DisplayNameLocKey = displayNameLocKey;
            Icon = icon;
        }
    }
}