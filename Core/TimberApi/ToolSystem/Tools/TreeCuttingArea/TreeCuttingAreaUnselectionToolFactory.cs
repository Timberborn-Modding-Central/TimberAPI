using HarmonyLib;
using TimberApi.DependencyContainerSystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.TreeCuttingArea
{
    public class TreeCuttingAreaUnselectionToolFactory : ILoadableSingleton, IToolFactory
    {
        public string Id => "TreeCuttingAreaUnselectionTool";
        
        private object _treeCuttingAreaUnselectionTool = null!;

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            return (Tool) _treeCuttingAreaUnselectionTool;
        }

        public void Load()
        {
            _treeCuttingAreaUnselectionTool = DependencyContainer.GetInstance(AccessTools.TypeByName("Timberborn.ForestryUI.TreeCuttingAreaUnselectionTool"));
        }
    }
}