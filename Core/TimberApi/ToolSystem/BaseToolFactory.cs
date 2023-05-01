using Timberborn.Persistence;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem
{
    public abstract class BaseToolFactory<T> : IToolFactory
    {
        public abstract string Id { get; }

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup)
        {
            return CreateTool(toolSpecification, GetToolInformation(toolSpecification), toolGroup);
        }

        protected abstract Tool CreateTool(ToolSpecification toolSpecification, T toolInformation, ToolGroup? toolGroup);

        private T GetToolInformation(ToolSpecification toolSpecification)
        {
            var objectLoader = ObjectLoader.CreateBasicLoader(toolSpecification.ToolInformation);

            return DeserializeToolInformation(objectLoader);
        }

        protected abstract T DeserializeToolInformation(IObjectLoader objectLoader);
    }
}