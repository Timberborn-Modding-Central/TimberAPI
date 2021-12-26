using System;
using TimberbornAPI.UIBuilderSystem.CustomElements;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;


namespace TimberbornAPI.UIBuilderSystem.PresetSystem
{
    public class TogglePresetFactory
    {
        private readonly ComponentBuilder _componentBuilder;

        public TogglePresetFactory(ComponentBuilder componentBuilder)
        {
            _componentBuilder = componentBuilder;
        }
        
        public LocalizableToggle Checkbox(string name = null, Length size = default, Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .AddClass(TimberApiStyle.Buttons.Normal.CheckboxOff)
                .AddClass(TimberApiStyle.Buttons.Hover.CheckboxOffHover)
                .AddClass(TimberApiStyle.Buttons.Checked.Normal.CheckboxOnChecked)
                .AddClass(TimberApiStyle.Buttons.Checked.Hover.CheckboxOnHoverChecked)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(20, Pixel) : size)
                .SetWidth(size == default ? new Length(20, Pixel) : size);
            builder?.Invoke(toggle);
            return toggle.Build();
        }
        
        public LocalizableToggle Checkmark(string name = null, Length size = default, Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .AddClass(TimberApiStyle.Buttons.Normal.Empty)
                .AddClass(TimberApiStyle.Buttons.Hover.EmptyHover)
                .AddClass(TimberApiStyle.Buttons.Active.EmptyActive)
                .AddClass(TimberApiStyle.Buttons.Checked.Normal.CheckmarkChecked)
                .AddClass(TimberApiStyle.Buttons.Checked.Hover.CheckmarkHoverChecked)
                .AddClass(TimberApiStyle.Buttons.Checked.Active.CheckmarkActiveChecked)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(20, Pixel) : size)
                .SetWidth(size == default ? new Length(20, Pixel) : size);
            builder?.Invoke(toggle);
            return toggle.Build();
        }
        
        public LocalizableToggle CheckmarkInverted(string name = null, Length size = default, Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .AddClass(TimberApiStyle.Buttons.Normal.EmptyInverted)
                .AddClass(TimberApiStyle.Buttons.Hover.EmptyHover)
                .AddClass(TimberApiStyle.Buttons.Active.EmptyActive)
                .AddClass(TimberApiStyle.Buttons.Checked.Normal.CheckmarkInvertedChecked)
                .AddClass(TimberApiStyle.Buttons.Checked.Hover.CheckmarkHoverChecked)
                .AddClass(TimberApiStyle.Buttons.Checked.Active.CheckmarkActiveChecked)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(20, Pixel) : size)
                .SetWidth(size == default ? new Length(20, Pixel) : size);
            builder?.Invoke(toggle);
            return toggle.Build();
        }
        
        public LocalizableToggle CheckmarkCross(string name = null, Length size = default, Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .AddClass(TimberApiStyle.Buttons.Normal.Cross)
                .AddClass(TimberApiStyle.Buttons.Hover.CrossHover)
                .AddClass(TimberApiStyle.Buttons.Active.CrossActive)
                .AddClass(TimberApiStyle.Buttons.Checked.Normal.CheckmarkInvertedChecked)
                .AddClass(TimberApiStyle.Buttons.Checked.Hover.CheckmarkHoverChecked)
                .AddClass(TimberApiStyle.Buttons.Checked.Active.CheckmarkActiveChecked)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(20, Pixel) : size)
                .SetWidth(size == default ? new Length(20, Pixel) : size);
            builder?.Invoke(toggle);
            return toggle.Build();
        }
        
        public LocalizableToggle CheckmarkCrossInverted(string name = null, Length size = default, Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .AddClass(TimberApiStyle.Buttons.Normal.CrossInverted)
                .AddClass(TimberApiStyle.Buttons.Hover.CrossHover)
                .AddClass(TimberApiStyle.Buttons.Active.CrossActive)
                .AddClass(TimberApiStyle.Buttons.Checked.Normal.CheckmarkInvertedChecked)
                .AddClass(TimberApiStyle.Buttons.Checked.Hover.CheckmarkHoverChecked)
                .AddClass(TimberApiStyle.Buttons.Checked.Active.CheckmarkActiveChecked)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(20, Pixel) : size)
                .SetWidth(size == default ? new Length(20, Pixel) : size);
            builder?.Invoke(toggle);
            return toggle.Build();
        }
        
        public LocalizableToggle CheckmarkAlt(string name = null, Length size = default, Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .AddClass(TimberApiStyle.Buttons.Normal.EmptyAlt)
                .AddClass(TimberApiStyle.Buttons.Checked.Normal.CheckmarkAltChecked)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(20, Pixel) : size)
                .SetWidth(size == default ? new Length(20, Pixel) : size);
            builder?.Invoke(toggle);
            return toggle.Build();
        }
        
        public LocalizableToggle Circle(string name = null, Length size = default, Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .AddClass(TimberApiStyle.Buttons.Normal.CircleOff)
                .AddClass(TimberApiStyle.Buttons.Hover.CircleOffHover)
                .AddClass(TimberApiStyle.Buttons.Checked.Normal.CircleOnChecked)
                .AddClass(TimberApiStyle.Buttons.Checked.Hover.CircleOnHoverChecked)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(40, Pixel) : size)
                .SetWidth(size == default ? new Length(40, Pixel) : size);
            builder?.Invoke(toggle);
            return toggle.Build();
        }
    }
}