namespace TimberbornAPI.UIBuilderSystem.PresetSystem
{
    public class UiPresetFactory
    {
        private readonly ButtonPresetFactory _buttonPresetFactory;

        private readonly TogglePresetFactory _togglePresetFactory;

        private readonly ScrollPresetFactory _scrollPresetFactory;
        
        private readonly LabelPresetFactory _labelPresetFactory;
        
        private readonly SliderPresetFactory _sliderPresetFactory;
        
        private readonly TextFieldPresetFactory _textFieldPresetFactory;

        private readonly ListViewPresetFactory _listViewPresetFactory;

        public UiPresetFactory(ComponentBuilder componentBuilder)
        {
            _listViewPresetFactory = new ListViewPresetFactory(componentBuilder);
            _buttonPresetFactory = new ButtonPresetFactory(componentBuilder);
            _togglePresetFactory = new TogglePresetFactory(componentBuilder);
            _labelPresetFactory = new LabelPresetFactory(componentBuilder);
            _textFieldPresetFactory = new TextFieldPresetFactory(componentBuilder);
            _sliderPresetFactory = new SliderPresetFactory(componentBuilder);
            _scrollPresetFactory = new ScrollPresetFactory(componentBuilder);
        }
        
        public ButtonPresetFactory Buttons()
        {
            return _buttonPresetFactory;
        }
        
        public TogglePresetFactory Toggles()
        {
            return _togglePresetFactory;
        }
        
        public ScrollPresetFactory ScrollViews()
        {
            return _scrollPresetFactory;
        }
        
        public LabelPresetFactory Labels()
        {
            return _labelPresetFactory;
        }
        
        public SliderPresetFactory Sliders()
        {
            return _sliderPresetFactory;
        }
        
        public TextFieldPresetFactory TextFields()
        {
            return _textFieldPresetFactory;
        }
        
        public ListViewPresetFactory ListViews()
        {
            return _listViewPresetFactory;
        }
    }
}