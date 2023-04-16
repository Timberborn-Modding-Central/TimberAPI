using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.Empty
{
    /// <summary>
    ///     Can be used if you only want to have a custom ToolButton without any effect
    /// </summary>
    public class EmptyTool : Tool
    {
        public override void Enter()
        {
        }

        public override void Exit()
        {
        }
    }
}