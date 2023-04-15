using TimberApi.ToolGroupSystem;
using Timberborn.ToolSystem;
using UnityEngine;
using ToolGroupSpecification = Timberborn.ToolSystem.ToolGroupSpecification;

namespace TimberApi.ToolGroupUISystem.Factories
{
    public class ToolGroupButtonBlueFactory : IToolGroupButtonFactory
    {
        public string Id => "Blue";

        private readonly ToolGroupButtonFactory _toolGroupButtonFactory;

        public ToolGroupButtonBlueFactory(ToolGroupButtonFactory toolGroupButtonFactory)
        {
            _toolGroupButtonFactory = toolGroupButtonFactory;
        }

        public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
        {
            return _toolGroupButtonFactory.Create((ToolGroup) toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-02");
        }
    }
}