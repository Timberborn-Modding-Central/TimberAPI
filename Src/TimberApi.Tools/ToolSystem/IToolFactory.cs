using TimberApi.Tools.ToolGroupSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem;

public interface IToolFactory
{
    public string Id { get; }

    public ITool Create(ToolSpec toolSpec, IToolGroup? toolGroup = null);
}