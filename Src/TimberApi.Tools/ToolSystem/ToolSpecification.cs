using Timberborn.SerializationSystem;

namespace TimberApi.Tools.ToolSystem;

public class ToolSpecification(
    string id,
    string? groupId,
    string section,
    string type,
    string layout,
    int order,
    string icon,
    string nameLocKey,
    string descriptionLocKey,
    bool hidden,
    bool devMode,
    ObjectSave? toolInformation)
    : ToolSpecification<ObjectSave>(id, groupId, section, type, layout, order, icon, nameLocKey, descriptionLocKey,
        hidden, devMode,
        toolInformation);

public class ToolSpecification<T>(
    string id,
    string? groupId,
    string section,
    string type,
    string layout,
    int order,
    string icon,
    string nameLocKey,
    string descriptionLocKey,
    bool hidden,
    bool devMode,
    T? toolInformation)
{
    public string Id { get; } = id;

    public string? GroupId { get; } = groupId;

    public string Section { get; } = section;

    public string Type { get; } = type;

    public string Layout { get; } = layout;

    public int Order { get; } = order;

    public string Icon { get; } = icon;

    public string NameLocKey { get; } = nameLocKey;

    public string DescriptionLocKey { get; } = descriptionLocKey;

    public bool Hidden { get; } = hidden;

    public bool DevMode { get; } = devMode;

    public T? ToolInformation { get; } = toolInformation;
}