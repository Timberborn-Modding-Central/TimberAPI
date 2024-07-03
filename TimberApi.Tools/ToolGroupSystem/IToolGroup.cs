using UnityEngine;

namespace TimberApi.Tools.ToolGroupSystem;

public interface IToolGroup
{
    string DisplayNameLocKey { get; }

    Sprite Icon { get; }

    int Order { get; }

    string Id { get; }

    string? GroupId { get; }

    string Section { get; }

    bool DevMode { get; }
}