using System;
using TimberApi.ToolSystem.Tools.Planting;
using Timberborn.Persistence;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.Cursor
{
    public class CursorToolFactory : BaseToolFactory<PlantingToolToolInformation>
    {
        private readonly Timberborn.CursorToolSystem.CursorTool _cursorTool;

        public CursorToolFactory(Timberborn.CursorToolSystem.CursorTool cursorTool)
        {
            _cursorTool = cursorTool;
        }

        public override string Id => "CursorTool";

        public override Tool Create(ToolSpecification toolSpecification)
        {
            return _cursorTool;
        }

        public override Tool Create(ToolSpecification toolSpecification, ToolGroup toolGroup)
        {
            return _cursorTool;
        }

        protected override PlantingToolToolInformation DeserializeToolInformation(IObjectLoader objectLoader)
        {
            throw new NotImplementedException();
        }
    }
}