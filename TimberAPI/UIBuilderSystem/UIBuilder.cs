using Timberborn.CoreUI;

namespace TimberbornAPI.UIBuilderSystem
{
    public class UIBuilderFactory : IUIBuilderFactory
    {
        private readonly ElementFactory _elementFactory;

        private readonly VisualElementInitializer _visualElementInitializer;

        public UIBuilderFactory(ElementFactory elementFactory, VisualElementInitializer visualElementInitializer)
        {
            this._elementFactory = elementFactory;
            this._visualElementInitializer = visualElementInitializer;
        }
        
        public IUIBoxBuilder CreateBoxBuilder()
        {
            return new UIBoxBuilder(_elementFactory, _visualElementInitializer);
        }
        
        public IUIComponentBuilder CreateComponentBuilder()
        {
            return new UIComponentBuilder(_elementFactory, _visualElementInitializer);
        }
    }
}