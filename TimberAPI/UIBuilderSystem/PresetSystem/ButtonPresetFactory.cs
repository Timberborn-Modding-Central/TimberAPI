using System;
using TimberbornAPI.UIBuilderSystem.CustomElements;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberbornAPI.UIBuilderSystem.PresetSystem
{
    public class ButtonPresetFactory
    {
        private readonly ComponentBuilder _componentBuilder;

        public ButtonPresetFactory(ComponentBuilder componentBuilder)
        {
            _componentBuilder = componentBuilder;
        }
        
        /// <summary>
        /// Normal: width 20px, height 20px
        /// Small: width 18px, height 18px
        /// Large: width 24px, height 24px
        /// </summary>
        public LocalizableButton ArrowDown(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ArrowDown)
                .AddClass(TimberApiStyle.Buttons.Hover.ArrowDownHover)
                .AddClass(TimberApiStyle.Buttons.Active.ArrowDownActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetStyle(style => style.unityBackgroundScaleMode = ScaleMode.StretchToFill)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        /// <summary>
        /// Normal: width 20px, height 20px
        /// Small: width 18px, height 18px
        /// Large: width 24px, height 24px
        /// </summary>
        public LocalizableButton ArrowDownInverted(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ArrowDownInverted)
                .AddClass(TimberApiStyle.Buttons.Hover.ArrowDownHover)
                .AddClass(TimberApiStyle.Buttons.Active.ArrowDownActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        /// <summary>
        /// Normal: width 20px, height 20px
        /// Small: width 18px, height 18px
        /// Large: width 24px, height 24px
        /// </summary>
        public LocalizableButton ArrowLeft(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ArrowLeft)
                .AddClass(TimberApiStyle.Buttons.Hover.ArrowLeftHover)
                .AddClass(TimberApiStyle.Buttons.Active.ArrowLeftActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        /// <summary>
        /// Normal: width 20px, height 20px
        /// Small: width 18px, height 18px
        /// Large: width 24px, height 24px
        /// </summary>
        public LocalizableButton ArrowLeftInverted(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ArrowLeftInverted)
                .AddClass(TimberApiStyle.Buttons.Hover.ArrowLeftHover)
                .AddClass(TimberApiStyle.Buttons.Active.ArrowLeftActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        /// <summary>
        /// Normal: width 20px, height 20px
        /// Small: width 18px, height 18px
        /// Large: width 24px, height 24px
        /// </summary>
        public LocalizableButton ArrowRight(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ArrowRight)
                .AddClass(TimberApiStyle.Buttons.Hover.ArrowRightHover)
                .AddClass(TimberApiStyle.Buttons.Active.ArrowRightActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        /// <summary>
        /// Normal: width 20px, height 20px
        /// Small: width 18px, height 18px
        /// Large: width 24px, height 24px
        /// </summary>
        public LocalizableButton ArrowRightInverted(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ArrowRightInverted)
                .AddClass(TimberApiStyle.Buttons.Hover.ArrowRightHover)
                .AddClass(TimberApiStyle.Buttons.Active.ArrowRightActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        /// <summary>
        /// Normal: width 20px, height 20px
        /// Small: width 18px, height 18px
        /// Large: width 24px, height 24px
        /// </summary>
        public LocalizableButton ArrowUp(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ArrowUp)
                .AddClass(TimberApiStyle.Buttons.Hover.ArrowUpHover)
                .AddClass(TimberApiStyle.Buttons.Active.ArrowUpActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        /// <summary>
        /// Normal: width 20px, height 20px
        /// Small: width 18px, height 18px
        /// Large: width 24px, height 24px
        /// </summary>
        public LocalizableButton ArrowUpInverted(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ArrowUpInverted)
                .AddClass(TimberApiStyle.Buttons.Hover.ArrowUpHover)
                .AddClass(TimberApiStyle.Buttons.Active.ArrowUpActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        
        public LocalizableButton Close(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.Close)
                .AddClass(TimberApiStyle.Buttons.Hover.CloseHover)
                .AddClass(TimberApiStyle.Sounds.Cancel)
                .SetName(name)
                .SetHeight(size == default ? new Length(40, Pixel) : size)
                .SetWidth(size == default ? new Length(40, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        
        public LocalizableButton DownArrow(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.DownArrow)
                .AddClass(TimberApiStyle.Buttons.Hover.DownArrowHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(34, Pixel) : size)
                .SetWidth(size == default ? new Length(57, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton LeftArrow(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.LeftArrow)
                .AddClass(TimberApiStyle.Buttons.Hover.LeftArrowHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(57, Pixel) : size)
                .SetWidth(size == default ? new Length(34, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton RightArrow(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.RightArrow)
                .AddClass(TimberApiStyle.Buttons.Hover.RightArrowHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(57, Pixel) : size)
                .SetWidth(size == default ? new Length(34, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton UpArrow(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.UpArrow)
                .AddClass(TimberApiStyle.Buttons.Hover.UpArrowHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(34, Pixel) : size)
                .SetWidth(size == default ? new Length(57, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        /// <summary>
        /// Normal: width 20px, height 20px
        /// Small: width 18px, height 18px
        /// Large: width 24px, height 24px
        /// </summary>
        public LocalizableButton Minus(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.Minus)
                .AddClass(TimberApiStyle.Buttons.Hover.MinusHover)
                .AddClass(TimberApiStyle.Buttons.Active.MinusActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        /// <summary>
        /// Normal: width 20px, height 20px
        /// Small: width 18px, height 18px
        /// Large: width 24px, height 24px
        /// </summary>
        public LocalizableButton MinusInverted(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.MinusInverted)
                .AddClass(TimberApiStyle.Buttons.Hover.MinusHover)
                .AddClass(TimberApiStyle.Buttons.Active.MinusActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton Plus(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.Plus)
                .AddClass(TimberApiStyle.Buttons.Hover.PlusHover)
                .AddClass(TimberApiStyle.Buttons.Active.PlusActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        /// <summary>
        /// Normal: width 20px, height 20px
        /// Small: width 18px, height 18px
        /// Large: width 24px, height 24px
        /// </summary>
        public LocalizableButton PlusInverted(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.PlusInverted)
                .AddClass(TimberApiStyle.Buttons.Hover.PlusHover)
                .AddClass(TimberApiStyle.Buttons.Active.PlusActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        
        public LocalizableButton CyclerLeft(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.CyclerLeft)
                .AddClass(TimberApiStyle.Buttons.Hover.CyclerLeftHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(20, Pixel) : size)
                .SetWidth(size == default ? new Length(11, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton CyclerRight(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.CyclerRight)
                .AddClass(TimberApiStyle.Buttons.Hover.CyclerRightHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(20, Pixel) : size)
                .SetWidth(size == default ? new Length(11, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton CyclerLeftMain(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.CyclerLeftMain)
                .AddClass(TimberApiStyle.Buttons.Hover.CyclerLeftMainHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(25, Pixel) : size)
                .SetWidth(size == default ? new Length(25, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton CyclerRightMain(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.CyclerRightMain)
                .AddClass(TimberApiStyle.Buttons.Hover.CyclerRightMainHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(25, Pixel) : size)
                .SetWidth(size == default ? new Length(25, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton SliderHolder(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.SliderHolder)
                .AddClass(TimberApiStyle.Buttons.Hover.SliderHolderHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton CircleEmpty(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.CircleEmpty)
                .AddClass(TimberApiStyle.Buttons.Hover.CircleEmptyHover)
                .AddClass(TimberApiStyle.Buttons.Active.CircleEmptyActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        /// <summary>
        /// Normal: width 20px, height 20px
        /// Small: width 18px, height 18px
        /// Large: width 24px, height 24px
        /// </summary>
        public LocalizableButton ResetButton(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ResetButton)
                .AddClass(TimberApiStyle.Buttons.Hover.ResetButtonHover)
                .AddClass(TimberApiStyle.Buttons.Active.ResetButtonActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton SpeedButton0(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.SpeedButton0)
                .AddClass(TimberApiStyle.Buttons.Hover.SpeedButton0Hover)
                .AddClass(TimberApiStyle.Buttons.Active.SpeedButton0Active)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton SpeedButton1(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.SpeedButton1)
                .AddClass(TimberApiStyle.Buttons.Hover.SpeedButton1Hover)
                .AddClass(TimberApiStyle.Buttons.Active.SpeedButton1Active)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton SpeedButton2(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.SpeedButton2)
                .AddClass(TimberApiStyle.Buttons.Hover.SpeedButton2Hover)
                .AddClass(TimberApiStyle.Buttons.Active.SpeedButton2Active)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton SpeedButton3(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.SpeedButton3)
                .AddClass(TimberApiStyle.Buttons.Hover.SpeedButton3Hover)
                .AddClass(TimberApiStyle.Buttons.Active.SpeedButton3Active)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(24, Pixel) : size)
                .SetWidth(size == default ? new Length(24, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton BugTracker(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.BugTracker)
                .AddClass(TimberApiStyle.Buttons.Hover.BugTrackerHover)
                .AddClass(TimberApiStyle.Buttons.Active.BugTrackerActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(35, Pixel) : size)
                .SetWidth(size == default ? new Length(35, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton ClampDown(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ClampDown)
                .AddClass(TimberApiStyle.Buttons.Hover.ClampDownHover)
                .AddClass(TimberApiStyle.Buttons.Active.ClampDownActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(20, Pixel) : size)
                .SetWidth(size == default ? new Length(60, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton ClampUp(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ClampUp)
                .AddClass(TimberApiStyle.Buttons.Hover.ClampUpHover)
                .AddClass(TimberApiStyle.Buttons.Active.ClampUpActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(20, Pixel) : size)
                .SetWidth(size == default ? new Length(120, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton LevelVisibilityReset(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.LevelVisibilityReset)
                .AddClass(TimberApiStyle.Buttons.Hover.LevelVisibilityResetHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetHeight(size == default ? new Length(35, Pixel) : size)
                .SetWidth(size == default ? new Length(35, Pixel) : size);
            builder?.Invoke(button);
            return button.Build();
        }

        /// <summary>
        /// Medium: height 33px, width 184px, font-size 13px
        /// Large text: font-size 17px
        /// </summary>
        public LocalizableButton Button(string locKey = null, Length width = default, Length height = default, Length fontSize = default, FontStyle fontStyle = default, StyleColor color = default, string name = null, string text = null, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.Button)
                .AddClass(TimberApiStyle.Buttons.Hover.ButtonHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetName(name)
                .SetLocKey(locKey)
                .SetText(text)
                .SetColor(color == default ? new StyleColor(new Color(1,1,1,1)) : color)
                .SetFontSize(fontSize == default ? new Length(14, Pixel) : fontSize)
                .SetFontStyle(fontStyle == default ? FontStyle.Bold : fontStyle)
                .SetHeight(height == default ? new Length(44, Pixel) : height)
                .SetWidth(width == default ? new Length(254, Pixel) : width);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton ButtonGame(string locKey = null, Length width = default, Length height = default, Length fontSize = default, FontStyle fontStyle = default, StyleColor color = default, string scale = default, string name = null, string text = null, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ButtonGame)
                .AddClass(TimberApiStyle.Buttons.Hover.ButtonGameHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .AddClass(scale ?? TimberApiStyle.Scales.Scale5)
                .SetName(name)
                .SetLocKey(locKey)
                .SetText(text)
                .SetColor(color == default ? new StyleColor(new Color(1,1,1,1)) : color)
                .SetFontSize(fontSize == default ? new Length(13, Pixel) : fontSize)
                .SetFontStyle(fontStyle == default ? FontStyle.Bold : fontStyle)
                .SetHeight(height == default ? new Length(33, Pixel) : height)
                .SetWidth(width == default ? new Length(184, Pixel) : width);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton NewGameCustom(string locKey = null, Length width = default, Length height = default, Length fontSize = default, FontStyle fontStyle = default, StyleColor color = default, string scale = default, string name = null, string text = null, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.NewGameCustom)
                .AddClass(TimberApiStyle.Buttons.Hover.NewGameCustomHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .AddClass(scale ?? TimberApiStyle.Scales.Scale5)
                .SetName(name)
                .SetLocKey(locKey)
                .SetText(text)
                .SetColor(color == default ? new StyleColor(new Color(1,1,1,1)) : color)
                .SetFontSize(fontSize == default ? new Length(13, Pixel) : fontSize)
                .SetFontStyle(fontStyle == default ? FontStyle.Bold : fontStyle)
                .SetHeight(height == default ? new Length(80, Pixel) : height)
                .SetWidth(width == default ? new Length(184, Pixel) : width);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton NewGameEasy(string locKey = null, Length width = default, Length height = default, Length fontSize = default, FontStyle fontStyle = default, StyleColor color = default, string scale = default, string name = null, string text = null, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.NewGameEasy)
                .AddClass(TimberApiStyle.Buttons.Hover.NewGameEasyHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .AddClass(scale ?? TimberApiStyle.Scales.Scale5)
                .SetName(name)
                .SetLocKey(locKey)
                .SetText(text)
                .SetColor(color == default ? new StyleColor(new Color(1,1,1,1)) : color)
                .SetFontSize(fontSize == default ? new Length(13, Pixel) : fontSize)
                .SetFontStyle(fontStyle == default ? FontStyle.Bold : fontStyle)
                .SetHeight(height == default ? new Length(80, Pixel) : height)
                .SetWidth(width == default ? new Length(184, Pixel) : width);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton NewGameNormal(string locKey = null, Length width = default, Length height = default, Length fontSize = default, FontStyle fontStyle = default, StyleColor color = default, string scale = default, string name = null, string text = null, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.NewGameNormal)
                .AddClass(TimberApiStyle.Buttons.Hover.NewGameNormalHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .AddClass(scale ?? TimberApiStyle.Scales.Scale5)
                .SetName(name)
                .SetLocKey(locKey)
                .SetText(text)
                .SetColor(color == default ? new StyleColor(new Color(1,1,1,1)) : color)
                .SetFontSize(fontSize == default ? new Length(13, Pixel) : fontSize)
                .SetFontStyle(fontStyle == default ? FontStyle.Bold : fontStyle)
                .SetHeight(height == default ? new Length(80, Pixel) : height)
                .SetWidth(width == default ? new Length(184, Pixel) : width);
            builder?.Invoke(button);
            return button.Build();
        }
        
        public LocalizableButton NewGameHard(string locKey = null, Length width = default, Length height = default, Length fontSize = default, FontStyle fontStyle = default, StyleColor color = default, string scale = default, string name = null, string text = null, Action<ButtonBuilder> builder = default)
        {
            ButtonBuilder button = _componentBuilder.CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.NewGameHard)
                .AddClass(TimberApiStyle.Buttons.Hover.NewGameHardHover)
                .AddClass(TimberApiStyle.Sounds.Click)
                .AddClass(scale ?? TimberApiStyle.Scales.Scale5)
                .SetName(name)
                .SetLocKey(locKey)
                .SetText(text)
                .SetColor(color == default ? new StyleColor(new Color(1,1,1,1)) : color)
                .SetFontSize(fontSize == default ? new Length(13, Pixel) : fontSize)
                .SetFontStyle(fontStyle == default ? FontStyle.Bold : fontStyle)
                .SetHeight(height == default ? new Length(80, Pixel) : height)
                .SetWidth(width == default ? new Length(184, Pixel) : width);
            builder?.Invoke(button);
            return button.Build();
        }
    }
}