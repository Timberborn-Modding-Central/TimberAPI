using TimberApi.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolUISystem.Factories
{
    public class ToolButtonGrouplessBlueFactory : IToolButtonFactory
    {
        public string Id => "GrouplessBlue";

        private readonly ToolButtonFactory _toolButtonFactory;

        public ToolButtonGrouplessBlueFactory(ToolButtonFactory toolButtonFactory)
        {
            _toolButtonFactory = toolButtonFactory;
        }

        public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
        {
            return _toolButtonFactory.CreateGroupless(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/button-bg-02");
        }
    }
}