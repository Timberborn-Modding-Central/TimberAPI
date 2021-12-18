using TimberbornAPI.Internal;
using TimberbornAPI.UIBuilderSystem.CustomElements;
using TimberbornAPI.UIBuilderSystem.ElementSystem;

namespace TimberbornAPI.UIBuilderSystem.PresetSystem
{
    public class ButtonPresetFactory
    {
        private readonly ComponentBuilder _componentBuilder;

        public ButtonPresetFactory(ComponentBuilder componentBuilder)
        {
            _componentBuilder = componentBuilder;
        }
        
        public LocalizableButton Menu(string text)
        {
            return _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.Button)
                .AddClass(TimberApiStyle.Buttons.Hover.ButtonHover)
                .SetText(text)
                .SetWidth(100)
                .SetHeight(40)
                .Build();
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