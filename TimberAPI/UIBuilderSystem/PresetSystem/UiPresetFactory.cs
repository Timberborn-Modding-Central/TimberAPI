using TimberbornAPI.UIBuilderSystem.ElementSystem;

namespace TimberbornAPI.UIBuilderSystem.PresetSystem
{
    public class UiPresetFactory
    {
        private readonly ComponentBuilder _componentBuilder;

        public UiPresetFactory(ComponentBuilder componentBuilder)
        {
            _componentBuilder = componentBuilder;
        }
        
        public ButtonPresetFactory Buttons()
        {
            return new ButtonPresetFactory(_componentBuilder);
        }
        
        public BoxPresetFactory Boxes()
        {
            return new BoxPresetFactory(_componentBuilder);
        }
    }
}