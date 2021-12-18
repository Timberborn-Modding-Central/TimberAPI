namespace TimberbornAPI.UIBuilderSystem
{
    public class UIBuilder
    {
        private readonly ComponentBuilder _componentBuilder;

        public UIBuilder(ComponentBuilder componentBuilder)
        {
            _componentBuilder = componentBuilder;
        }
        
        public UIBoxBuilder CreateBoxBuilder()
        {
            return new UIBoxBuilder(_componentBuilder);
        }
        
        public ComponentBuilder CreateComponentBuilder()
        {
            return _componentBuilder;
        }
    }
}