using Timberborn.SerializationSystem;
using UnityEngine;

namespace TimberApi.Tools.ToolSystem;

public class ToolSpecification : ToolSpecification<ObjectSave>
{
    public ToolSpecification(string id, string? groupId, string section, string type, string layout, int order,
        Sprite icon, string nameLocKey, string descriptionLocKey, bool hidden, bool devMode,
        ObjectSave? toolInformation)
        : base(id, groupId, section, type, layout, order, icon, nameLocKey, descriptionLocKey, hidden, devMode,
            toolInformation)
    {
    }
}

public class ToolSpecification<T>
{
    public ToolSpecification(string id, string? groupId, string section, string type, string layout, int order,
        Sprite icon, string nameLocKey, string descriptionLocKey, bool hidden, bool devMode, T? toolInformation)
    {
        Id = id;
        GroupId = groupId;
        Section = section;
        Type = type;
        Layout = layout;
        Order = order;
        Icon = icon;
        NameLocKey = nameLocKey;
        DescriptionLocKey = descriptionLocKey;
        DevMode = devMode;
        Hidden = hidden;
        ToolInformation = toolInformation;
    }

    public string Id { get; }

    public string? GroupId { get; }

    public string Section { get; }

    public string Type { get; }

    public string Layout { get; }

    public int Order { get; }

    public Sprite Icon { get; }

    public string NameLocKey { get; }

    public string DescriptionLocKey { get; }

    public bool Hidden { get; }

    public bool DevMode { get; }

    public T? ToolInformation { get; }
}