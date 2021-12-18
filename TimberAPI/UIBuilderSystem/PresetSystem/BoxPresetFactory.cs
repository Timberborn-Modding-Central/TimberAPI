using TimberbornAPI.UIBuilderSystem.CustomElements;
using TimberbornAPI.UIBuilderSystem.ElementSystem;

namespace TimberbornAPI.UIBuilderSystem.PresetSystem
{
    public class BoxPresetFactory
    {
        private readonly ComponentBuilder _componentBuilder;

        public BoxPresetFactory(ComponentBuilder componentBuilder)
        {
            _componentBuilder = componentBuilder;
        }
        
        public LocalizableButton Close(string name)
        {
            return _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.Minus)
                .AddClass(TimberApiStyle.Buttons.Active.MinusActive)
                .AddClass(TimberApiStyle.Buttons.Hover.MinusHover)
                .Build();
        }
        
        public LocalizableButton UpArrow()
        {
            return _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.UpArrow)
                .AddClass(TimberApiStyle.Buttons.Active.ArrowUpActive)
                .AddClass(TimberApiStyle.Buttons.Hover.UpArrowHover)
                .Build();
        }
    }
}