using static TimberAPIExample.TimberAPIExamplePlugin;

namespace TimberAPIExample.Examples.AssetLoaderExample
{
    public class AssetLoaderExampleTool : Tool
    {
        public override void Enter()
        {
            Log.LogInfo("Selected");
        }

        public override void Exit()
        {
            Log.LogInfo("Deselected");
        }
    }
}