using System;
using Timberborn.ToolSystem;

namespace TimberAPIExample.Examples.AssetLoaderExample
{
    public class AssetLoaderExampleTool : Tool
    {
        public override void Enter()
        {
            Console.WriteLine("Selected");
        }

        public override void Exit()
        {
            Console.WriteLine("Deselected");
        }
    }
}