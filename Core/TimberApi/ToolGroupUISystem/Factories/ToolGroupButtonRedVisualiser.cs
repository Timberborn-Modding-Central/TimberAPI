using TimberApi.Common.Extensions;
using Timberborn.ToolSystem;

namespace TimberApi.ToolGroupUISystem
{
    public class ToolGroupButtonRedVisualiser : IToolGroupButtonVisualiser
    {
        private static readonly string RedButtonClass = "bottom-bar-button--red";

        public string Id => "Red";

        private readonly ToolGroupButtonFactory _toolGroupButtonFactory;

        public ToolGroupButtonRedVisualiser(ToolGroupButtonFactory toolGroupButtonFactory)
        {
            _toolGroupButtonFactory = toolGroupButtonFactory;
        }

        public ToolGroupButton GetToolGroupButton(ToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
        {
            return _toolGroupButtonFactory.InvokePrivateInstanceMember<ToolGroupButton>("Create", new object[] { toolGroup, RedButtonClass });
        }
    }
}