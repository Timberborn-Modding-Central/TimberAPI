using System;
using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem.CustomElements;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine;
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

        public LocalizableToggle Checkbox(string name = null, Length size = default, string locKey = null,
            Length width = default, Length fontSize = default, FontStyle fontStyle = default,
            StyleColor color = default, string text = default, Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .ModifyCheckMarkElement(checkmarkBuilder => checkmarkBuilder
                    .SetHeight(size == default ? new Length(26, Pixel) : size)
                    .SetWidth(size == default ? new Length(26, Pixel) : size)
                )
                .AddClass(TimberApiStyle.CheckBox.Normal.CheckboxOff)
                .AddClass(TimberApiStyle.CheckBox.Hover.CheckboxOffHover)
                .AddClass(TimberApiStyle.CheckBox.Checked.Normal.CheckboxOn)
                .AddClass(TimberApiStyle.CheckBox.Checked.Hover.CheckboxOnHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetText(text)
                .SetLocKey(locKey)
                .SetName(name);
            if (width != default)
                toggle.SetWidth(width);
            if (fontSize != default)
                toggle.SetFontSize(fontSize);
            if (fontStyle != default)
                toggle.SetFontStyle(fontStyle);
            if (color != default)
                toggle.SetColor(color);
            builder?.Invoke(toggle);
            return toggle.Build();
        }

        public LocalizableToggle Checkmark(string name = null, Length size = default, string locKey = null,
            Length width = default, Length fontSize = default, FontStyle fontStyle = default,
            StyleColor color = default, string text = default,
            Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .ModifyCheckMarkElement(checkmarkBuilder => checkmarkBuilder
                    .SetHeight(size == default ? new Length(20, Pixel) : size)
                    .SetWidth(size == default ? new Length(20, Pixel) : size)
                    .SetMargin(new Margin(new Length(2, Pixel), 0))
                )
                .AddClass(TimberApiStyle.CheckBox.Normal.Empty)
                .AddClass(TimberApiStyle.CheckBox.Hover.EmptyHover)
                .AddClass(TimberApiStyle.CheckBox.Active.EmptyActive)
                .AddClass(TimberApiStyle.CheckBox.Checked.Normal.Checkmark)
                .AddClass(TimberApiStyle.CheckBox.Checked.Hover.CheckmarkHover)
                .AddClass(TimberApiStyle.CheckBox.Checked.Active.CheckmarkActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetText(text)
                .SetLocKey(locKey);
            if (width != default)
                toggle.SetWidth(width);
            if (fontSize != default)
                toggle.SetFontSize(fontSize);
            if (fontStyle != default)
                toggle.SetFontStyle(fontStyle);
            if (color != default)
                toggle.SetColor(color);
            builder?.Invoke(toggle);
            builder?.Invoke(toggle);
            return toggle.Build();
        }

        public LocalizableToggle CheckmarkInverted(string name = null, Length size = default, string locKey = null,
            Length width = default, Length fontSize = default, FontStyle fontStyle = default,
            StyleColor color = default, string text = default,
            Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .ModifyCheckMarkElement(checkmarkBuilder => checkmarkBuilder
                    .SetHeight(size == default ? new Length(20, Pixel) : size)
                    .SetWidth(size == default ? new Length(20, Pixel) : size)
                    .SetMargin(new Margin(new Length(2, Pixel), 0))
                )
                .AddClass(TimberApiStyle.CheckBox.Normal.EmptyInverted)
                .AddClass(TimberApiStyle.CheckBox.Hover.EmptyHover)
                .AddClass(TimberApiStyle.CheckBox.Active.EmptyActive)
                .AddClass(TimberApiStyle.CheckBox.Checked.Normal.CheckmarkInverted)
                .AddClass(TimberApiStyle.CheckBox.Checked.Hover.CheckmarkHover)
                .AddClass(TimberApiStyle.CheckBox.Checked.Active.CheckmarkActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetText(text)
                .SetLocKey(locKey);
            if (width != default)
                toggle.SetWidth(width);
            if (fontSize != default)
                toggle.SetFontSize(fontSize);
            if (fontStyle != default)
                toggle.SetFontStyle(fontStyle);
            if (color != default)
                toggle.SetColor(color);
            builder?.Invoke(toggle);
            builder?.Invoke(toggle);
            return toggle.Build();
        }

        public LocalizableToggle CheckmarkCross(string name = null, Length size = default, string locKey = null,
            Length width = default, Length fontSize = default, FontStyle fontStyle = default,
            StyleColor color = default, string text = default,
            Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .ModifyCheckMarkElement(checkmarkBuilder => checkmarkBuilder
                    .SetHeight(size == default ? new Length(20, Pixel) : size)
                    .SetWidth(size == default ? new Length(20, Pixel) : size)
                    .SetMargin(new Margin(new Length(2, Pixel), 0))
                )
                .AddClass(TimberApiStyle.CheckBox.Normal.Cross)
                .AddClass(TimberApiStyle.CheckBox.Hover.CrossHover)
                .AddClass(TimberApiStyle.CheckBox.Active.CrossActive)
                .AddClass(TimberApiStyle.CheckBox.Checked.Normal.Checkmark)
                .AddClass(TimberApiStyle.CheckBox.Checked.Hover.CheckmarkHover)
                .AddClass(TimberApiStyle.CheckBox.Checked.Active.CheckmarkActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetText(text)
                .SetLocKey(locKey);
            if (width != default)
                toggle.SetWidth(width);
            if (fontSize != default)
                toggle.SetFontSize(fontSize);
            if (fontStyle != default)
                toggle.SetFontStyle(fontStyle);
            if (color != default)
                toggle.SetColor(color);
            builder?.Invoke(toggle);
            builder?.Invoke(toggle);
            return toggle.Build();
        }

        public LocalizableToggle CheckmarkCrossInverted(string name = null, Length size = default, string locKey = null,
            Length width = default, Length fontSize = default, FontStyle fontStyle = default,
            StyleColor color = default, string text = default,
            Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .ModifyCheckMarkElement(checkmarkBuilder => checkmarkBuilder
                    .SetHeight(size == default ? new Length(20, Pixel) : size)
                    .SetWidth(size == default ? new Length(20, Pixel) : size)
                    .SetMargin(new Margin(new Length(2, Pixel), 0))
                )
                .AddClass(TimberApiStyle.CheckBox.Normal.CrossInverted)
                .AddClass(TimberApiStyle.CheckBox.Hover.CrossHover)
                .AddClass(TimberApiStyle.CheckBox.Active.CrossActive)
                .AddClass(TimberApiStyle.CheckBox.Checked.Normal.CheckmarkInverted)
                .AddClass(TimberApiStyle.CheckBox.Checked.Hover.CheckmarkHover)
                .AddClass(TimberApiStyle.CheckBox.Checked.Active.CheckmarkActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetText(text)
                .SetLocKey(locKey);
            if (width != default)
                toggle.SetWidth(width);
            if (fontSize != default)
                toggle.SetFontSize(fontSize);
            if (fontStyle != default)
                toggle.SetFontStyle(fontStyle);
            if (color != default)
                toggle.SetColor(color);
            builder?.Invoke(toggle);
            builder?.Invoke(toggle);
            return toggle.Build();
        }

        public LocalizableToggle CheckmarkAlt(string name = null, Length size = default, string locKey = null,
            Length width = default, Length fontSize = default, FontStyle fontStyle = default,
            StyleColor color = default, string text = default,
            Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                    .ModifyCheckMarkElement(checkmarkBuilder => checkmarkBuilder
                        .SetHeight(size == default ? new Length(20, Pixel) : size)
                        .SetWidth(size == default ? new Length(20, Pixel) : size)
                    )
                    .AddClass(TimberApiStyle.CheckBox.Normal.EmptyAlt)
                    .AddClass(TimberApiStyle.CheckBox.Checked.Normal.CheckmarkAlt)
                    .AddClass(TimberApiStyle.Sounds.Click)
                    .SetName(name)
                    .SetText(text)
                    .SetLocKey(locKey)
                ;
            if (width != default)
                toggle.SetWidth(width);
            if (fontSize != default)
                toggle.SetFontSize(fontSize);
            if (fontStyle != default)
                toggle.SetFontStyle(fontStyle);
            if (color != default)
                toggle.SetColor(color);
            builder?.Invoke(toggle);
            builder?.Invoke(toggle);
            return toggle.Build();
        }

        public LocalizableToggle Circle(string name = null, Length size = default, string locKey = null,
            Length width = default, Length fontSize = default, FontStyle fontStyle = default,
            StyleColor color = default, string text = default,
            Action<ToggleBuilder> builder = default)
        {
            ToggleBuilder toggle = _componentBuilder.CreateToggle()
                .ModifyCheckMarkElement(checkmarkBuilder => checkmarkBuilder
                    .SetHeight(size == default ? new Length(32, Pixel) : size)
                    .SetWidth(size == default ? new Length(32, Pixel) : size)
                )
                .AddClass(TimberApiStyle.CheckBox.Normal.CircleOff)
                .AddClass(TimberApiStyle.CheckBox.Hover.CircleOffHover)
                .AddClass(TimberApiStyle.CheckBox.Checked.Normal.CircleOn)
                .AddClass(TimberApiStyle.CheckBox.Checked.Hover.CircleOnHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetText(text)
                .SetLocKey(locKey);
            if (width != default)
                toggle.SetWidth(width);
            if (fontSize != default)
                toggle.SetFontSize(fontSize);
            if (fontStyle != default)
                toggle.SetFontStyle(fontStyle);
            if (color != default)
                toggle.SetColor(color);
            builder?.Invoke(toggle);
            builder?.Invoke(toggle);
            return toggle.Build();
        }
    }
}