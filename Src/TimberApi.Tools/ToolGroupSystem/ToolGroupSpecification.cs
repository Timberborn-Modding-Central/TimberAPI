using Timberborn.SerializationSystem;
using UnityEngine;

namespace TimberApi.Tools.ToolGroupSystem;

public class ToolGroupSpecification(
    string id,
    string type,
    int order,
    string nameLocKey,
    Sprite icon,
    bool fallbackGroup,
    string? groupId,
    string layout,
    string section,
    bool devMode,
    bool hidden,
    ObjectSave? groupInformation)
    : ToolGroupSpecification<ObjectSave>(id, type, order, nameLocKey, icon, fallbackGroup, groupId, layout, section,
        devMode, hidden,
        groupInformation);

public class ToolGroupSpecification<T>(
    string id,
    string type,
    int order,
    string nameLocKey,
    Sprite icon,
    bool fallbackGroup,
    string? groupId,
    string layout,
    string section,
    bool devMode,
    bool hidden,
    T? groupInformation)
    : Timberborn.ToolSystem.ToolGroupSpecification(id, order, nameLocKey, icon, fallbackGroup)
{
    public string Type { get; set; } = type;

    public string? GroupId { get; } = groupId;

    public string Layout { get; } = layout;

    public string Section { get; } = section;

    public bool DevMode { get; } = devMode;

    public bool Hidden { get; } = hidden;

    public T? GroupInformation { get; } = groupInformation;
}