using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem;

public interface IToolFactory
{
    public string Id { get; }

    public Tool Create(ToolSpec toolSpec, ToolGroup? toolGroup = null);
}