using Timberborn.Persistence;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem
{
    public abstract class BaseToolFactory<T> : IToolFactory
    {
        public abstract string Id { get; }

        public abstract Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null);

        protected T GetToolInformation(ToolSpecification toolSpecification)
        {
            var objectLoader = ObjectLoader.CreateBasicLoader(toolSpecification.ToolInformation);

            return DeserializeToolInformation(objectLoader);
        }

        protected abstract T DeserializeToolInformation(IObjectLoader objectLoader);
    }
}