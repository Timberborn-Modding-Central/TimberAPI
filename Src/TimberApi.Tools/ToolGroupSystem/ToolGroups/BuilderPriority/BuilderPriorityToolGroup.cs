using UnityEngine;

namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.BuilderPriority;

public sealed class BuilderPriorityToolGroup : Timberborn.BuilderPrioritySystemUI.BuilderPriorityToolGroup, IToolGroup
{
    public BuilderPriorityToolGroup(string id, string? groupId, int order, string section, string displayNameLocKey,
        bool devMode, Sprite icon)
    {
        Id = id;
        DisplayNameLocKey = displayNameLocKey;
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