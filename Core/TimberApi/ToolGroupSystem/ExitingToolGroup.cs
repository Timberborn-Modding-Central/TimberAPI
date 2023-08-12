using Timberborn.ConstructionMode;
using Timberborn.ToolSystem;

namespace TimberApi.ToolGroupSystem
{
    /// <summary>
    ///     Requires IConstructionModeEnabler to disable construction mode even when it's in the other ToolGroups, reason is unknown.
    /// </summary>
    public class ExitingToolGroup : ToolGroup, IConstructionModeEnabler
    {
    }
}