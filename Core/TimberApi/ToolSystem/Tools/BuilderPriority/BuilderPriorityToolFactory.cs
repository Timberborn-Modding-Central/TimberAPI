using Timberborn.Persistence;
using Timberborn.ToolSystem;
using TimberbornBuilderPriorityToolFactory = Timberborn.BuilderPrioritySystemUI.BuilderPriorityToolFactory;

namespace TimberApi.ToolSystem.Tools.BuilderPriority
{
    public class BuilderPriorityToolFactory : BaseToolFactory<BuilderPriorityToolToolInformation>
    {
        public override string Id => "PriorityTool";

        private readonly TimberbornBuilderPriorityToolFactory _builderPriorityToolFactory;

        public BuilderPriorityToolFactory(TimberbornBuilderPriorityToolFactory builderPriorityToolFactory)
        {
            _builderPriorityToolFactory = builderPriorityToolFactory;
        }

        protected override Tool CreateTool(ToolSpecification toolSpecification, BuilderPriorityToolToolInformation toolInformation, ToolGroup? toolGroup)
        {
            return _builderPriorityToolFactory.Create(toolInformation.Priority);
        }

        protected override BuilderPriorityToolToolInformation DeserializeToolInformation(IObjectLoader objectLoader)
        {
            return new BuilderPriorityToolToolInformation(objectLoader.Get(new PropertyKey<string>("Priority")));
        }
    }
}