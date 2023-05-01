using HarmonyLib;
using TimberApi.Common.Extensions;
using TimberApi.DependencyContainerSystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.BuilderPriority
{
    public class BuilderPriorityToolFactory : BaseToolFactory<BuilderPriorityToolToolInformation>, ILoadableSingleton
    {
        private object _builderPriorityToolFactory = null!;
        
        public override string Id => "PriorityTool";

        public void Load()
        {
            _builderPriorityToolFactory = DependencyContainer.GetInstance(AccessTools.TypeByName("Timberborn.BuilderPrioritySystemUI.BuilderPriorityToolFactory"));
        }

        protected override Tool CreateTool(ToolSpecification toolSpecification, BuilderPriorityToolToolInformation toolInformation, ToolGroup? toolGroup)
        {
            return (Tool) _builderPriorityToolFactory.InvokeInternalInstanceMember("Create", new object[]
            {
                toolInformation.Priority
            });
        }

        protected override BuilderPriorityToolToolInformation DeserializeToolInformation(IObjectLoader objectLoader)
        {
            return new BuilderPriorityToolToolInformation(objectLoader.Get(new PropertyKey<string>("Priority")));
        }
    }
}