using UnityEngine;

namespace TimberApi.Tools.ToolGroupSystem;

public class ApiToolGroup(
    string id,
    string? groupId,
    int order,
    string section,
    string displayNameLocKey,
    bool devMode,
    Sprite icon)
    : IToolGroup
{
    public string Id { get; } = id;

    public string? GroupId { get; } = groupId;

    public string DisplayNameLocKey { get; } = displayNameLocKey;

    public Sprite Icon { get; } = icon;
    
    public int Order { get; } = order;

    public string Section { get; } = section;

    public bool DevMode { get; } = devMode;
}
