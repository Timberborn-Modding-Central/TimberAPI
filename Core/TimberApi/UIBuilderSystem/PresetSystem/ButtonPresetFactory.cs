using System;
using TimberApi.UiBuilderSystem.ElementBuilders;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

#pragma warning disable CS8625

namespace TimberApi.UiBuilderSystem.PresetSystem
{
    public class ButtonPresetFactory
    {
        // public LocalizableButton Close(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.Close).AddClass(TimberApiStyle.Buttons.Hover.CloseHover)
        //         .AddClass(TimberApiStyle.Sounds.Cancel).SetName(name).SetHeight(size == default ? new Length(40, Pixel) : size).SetWidth(size == default ? new Length(40, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
    
        // /// <summary>
        // ///     Normal: width 20px, height 20px
        // ///     Small: width 18px, height 18px
        // ///     Large: width 24px, height 24px
        // /// </summary>
        // public LocalizableButton Minus(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.Minus).AddClass(TimberApiStyle.Buttons.Hover.MinusHover)
        //         .AddClass(TimberApiStyle.Buttons.Active.MinusActive).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(24, Pixel) : size)
        //         .SetWidth(size == default ? new Length(24, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // /// <summary>
        // ///     Normal: width 20px, height 20px
        // ///     Small: width 18px, height 18px
        // ///     Large: width 24px, height 24px
        // /// </summary>
        // public LocalizableButton MinusInverted(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.MinusInverted).AddClass(TimberApiStyle.Buttons.Hover.MinusHover)
        //         .AddClass(TimberApiStyle.Buttons.Active.MinusActive).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(24, Pixel) : size)
        //         .SetWidth(size == default ? new Length(24, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton Plus(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.Plus).AddClass(TimberApiStyle.Buttons.Hover.PlusHover)
        //         .AddClass(TimberApiStyle.Buttons.Active.PlusActive).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(24, Pixel) : size)
        //         .SetWidth(size == default ? new Length(24, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // /// <summary>
        // ///     Normal: width 20px, height 20px
        // ///     Small: width 18px, height 18px
        // ///     Large: width 24px, height 24px
        // /// </summary>
        // public LocalizableButton PlusInverted(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.PlusInverted).AddClass(TimberApiStyle.Buttons.Hover.PlusHover)
        //         .AddClass(TimberApiStyle.Buttons.Active.PlusActive).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(24, Pixel) : size)
        //         .SetWidth(size == default ? new Length(24, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        //
        // public LocalizableButton CyclerLeft(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.CyclerLeft).AddClass(TimberApiStyle.Buttons.Hover.CyclerLeftHover)
        //         .AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(20, Pixel) : size).SetWidth(size == default ? new Length(11, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton CyclerRight(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.CyclerRight).AddClass(TimberApiStyle.Buttons.Hover.CyclerRightHover)
        //         .AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(20, Pixel) : size).SetWidth(size == default ? new Length(11, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton CyclerLeftMain(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.CyclerLeftMain).AddClass(TimberApiStyle.Buttons.Hover.CyclerLeftMainHover)
        //         .AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(25, Pixel) : size).SetWidth(size == default ? new Length(25, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton CyclerRightMain(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.CyclerRightMain).AddClass(TimberApiStyle.Buttons.Hover.CyclerRightMainHover)
        //         .AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(25, Pixel) : size).SetWidth(size == default ? new Length(25, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton SliderHolder(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.SliderHolder).AddClass(TimberApiStyle.Buttons.Hover.SliderHolderHover)
        //         .AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(24, Pixel) : size).SetWidth(size == default ? new Length(24, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton CircleEmpty(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.CircleEmpty).AddClass(TimberApiStyle.Buttons.Hover.CircleEmptyHover)
        //         .AddClass(TimberApiStyle.Buttons.Active.CircleEmptyActive).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(24, Pixel) : size)
        //         .SetWidth(size == default ? new Length(24, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // /// <summary>
        // ///     Normal: width 20px, height 20px
        // ///     Small: width 18px, height 18px
        // ///     Large: width 24px, height 24px
        // /// </summary>
        // public LocalizableButton ResetButton(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.ResetButton).AddClass(TimberApiStyle.Buttons.Hover.ResetButtonHover)
        //         .AddClass(TimberApiStyle.Buttons.Active.ResetButtonActive).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(24, Pixel) : size)
        //         .SetWidth(size == default ? new Length(24, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton SpeedButton0(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.SpeedButton0).AddClass(TimberApiStyle.Buttons.Hover.SpeedButton0Hover)
        //         .AddClass(TimberApiStyle.Buttons.Active.SpeedButton0Active).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(24, Pixel) : size)
        //         .SetWidth(size == default ? new Length(24, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton SpeedButton1(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.SpeedButton1).AddClass(TimberApiStyle.Buttons.Hover.SpeedButton1Hover)
        //         .AddClass(TimberApiStyle.Buttons.Active.SpeedButton1Active).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(24, Pixel) : size)
        //         .SetWidth(size == default ? new Length(24, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton SpeedButton2(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.SpeedButton2).AddClass(TimberApiStyle.Buttons.Hover.SpeedButton2Hover)
        //         .AddClass(TimberApiStyle.Buttons.Active.SpeedButton2Active).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(24, Pixel) : size)
        //         .SetWidth(size == default ? new Length(24, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton SpeedButton3(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.SpeedButton3).AddClass(TimberApiStyle.Buttons.Hover.SpeedButton3Hover)
        //         .AddClass(TimberApiStyle.Buttons.Active.SpeedButton3Active).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(24, Pixel) : size)
        //         .SetWidth(size == default ? new Length(24, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton BugTracker(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.BugTracker).AddClass(TimberApiStyle.Buttons.Hover.BugTrackerHover)
        //         .AddClass(TimberApiStyle.Buttons.Active.BugTrackerActive).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(35, Pixel) : size)
        //         .SetWidth(size == default ? new Length(35, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton ClampDown(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.ClampDown).AddClass(TimberApiStyle.Buttons.Hover.ClampDownHover)
        //         .AddClass(TimberApiStyle.Buttons.Active.ClampDownActive).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(20, Pixel) : size)
        //         .SetWidth(size == default ? new Length(60, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton ClampUp(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.ClampUp).AddClass(TimberApiStyle.Buttons.Hover.ClampUpHover)
        //         .AddClass(TimberApiStyle.Buttons.Active.ClampUpActive).AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(20, Pixel) : size)
        //         .SetWidth(size == default ? new Length(120, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
        //
        // public LocalizableButton LevelVisibilityReset(string name = null, Length size = default, Action<ButtonBuilder> builder = default)
        // {
        //     ButtonBuilder button = _componentBuilder.CreateButton().AddClass(TimberApiStyle.Buttons.Normal.LevelVisibilityReset).AddClass(TimberApiStyle.Buttons.Hover.LevelVisibilityResetHover)
        //         .AddClass(TimberApiStyle.Sounds.Click).SetName(name).SetHeight(size == default ? new Length(35, Pixel) : size).SetWidth(size == default ? new Length(35, Pixel) : size);
        //     builder?.Invoke(button);
        //     return button.Build();
        // }
    }
}