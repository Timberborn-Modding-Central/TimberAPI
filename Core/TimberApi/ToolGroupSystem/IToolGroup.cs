using UnityEngine;

namespace TimberApi.ToolGroupSystem
{
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
}