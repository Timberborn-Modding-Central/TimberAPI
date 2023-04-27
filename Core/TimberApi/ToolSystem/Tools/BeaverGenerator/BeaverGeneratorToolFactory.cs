using HarmonyLib;
using TimberApi.DependencyContainerSystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.BeaverGenerator
{
    public class BeaverGeneratorToolFactory : IToolFactory, ILoadableSingleton
    {
        public string Id => "BeaverGeneratorTool";
        
        private object _beaverGeneratorTool;

        public void Load()
        {
            _beaverGeneratorTool = DependencyContainer.GetInstance(AccessTools.TypeByName("Timberborn.BeaversUI.BeaverGeneratorTool"));
        }

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            return (Tool) _beaverGeneratorTool;
        }
    }
}