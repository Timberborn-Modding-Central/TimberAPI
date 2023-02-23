using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.ToolSystem
{
    public class TestTool : Tool
    {
        public override void Enter()
        {
            Debug.LogError("IM ENTERING YOUR DUNGEON!!");
        }

        public override void Exit()
        {
            Debug.LogError("IM LEAVING YOUR DUNGEON!!");
        }
    }
}