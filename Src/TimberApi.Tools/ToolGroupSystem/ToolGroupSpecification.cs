using Timberborn.SerializationSystem;
using UnityEngine;

namespace TimberApi.Tools.ToolGroupSystem;

public class ToolGroupSpecification : ToolGroupSpecification<ObjectSave>
{
    public ToolGroupSpecification(string id, string type, int order, string nameLocKey, Sprite icon, bool fallbackGroup,
        string? groupId, string layout, string section, bool devMode, bool hidden, ObjectSave? groupInformation)
        : base(id, type, order, nameLocKey, icon, fallbackGroup, groupId, layout, section, devMode, hidden,
            groupInformation)
    {
    }
}

public class ToolGroupSpecification<T> : Timberborn.ToolSystem.ToolGroupSpecification
{
    public ToolGroupSpecification(string id, string type, int order, string nameLocKey, Sprite icon, bool fallbackGroup,
        string? groupId, string layout, string section, bool devMode, bool hidden, T? groupInformation)
        : base(id, order, nameLocKey, icon, fallbackGroup)
    {
        Type = type;
        GroupId = groupId;
        Layout = layout;
        Section = section;
        DevMode = devMode;
        Hidden = hidden;
        GroupInformation = groupInformation;
    }

    public string Type { get; set; }

    public string? GroupId { get; }

    public string Layout { get; }

    public string Section { get; }

    public bool DevMode { get; }

    public bool Hidden { get; }

    public T? GroupInformation { get; }
}