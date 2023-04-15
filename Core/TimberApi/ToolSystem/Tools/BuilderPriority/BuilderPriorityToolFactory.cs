using System;
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
        public override string Id => "PriorityTool";
        
        private object _builderPriorityToolFactory = null!;
        
        public override Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            var toolInformation = GetToolInformation(toolSpecification);
    
            return (Tool) _builderPriorityToolFactory.InvokeInternalInstanceMember("Create", new object[]
            {
                toolInformation.Priority
            });
        }
    
        protected override BuilderPriorityToolToolInformation DeserializeToolInformation(IObjectLoader objectLoader)
        {
            return new BuilderPriorityToolToolInformation(objectLoader.Get(new PropertyKey<string>("Priority")));
        }
    
        public void Load()
        {
            _builderPriorityToolFactory = DependencyContainer.GetInstance(AccessTools.TypeByName("Timberborn.BuilderPrioritySystemUI.BuilderPriorityToolFactory"));
        }
    }
}