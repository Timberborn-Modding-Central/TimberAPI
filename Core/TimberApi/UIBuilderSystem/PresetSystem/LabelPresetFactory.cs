using System;
using TimberApi.UiBuilderSystem.ElementBuilders;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

#pragma warning disable CS8625

namespace TimberApi.UiBuilderSystem.PresetSystem
{
    public class LabelPresetFactory
    {
        // public LocalizableLabel Label(string locKey = default, Length fontSize = default, StyleColor color = default, FontStyle fontStyle = default, WhiteSpace whiteSpace = default,
        //     string text = default, string name = null, Action<LabelBuilder> builder = default)
        // {
        //     LabelBuilder label = _componentBuilder.CreateLabel().SetName(name).SetLocKey(locKey)
        //         .SetColor(color == default ? new StyleColor(new Color(0.800f, 0.800f, 0.800f, 1.000f)) : color).SetFontSize(fontSize == default ? new Length(13, Pixel) : fontSize)
        //         .SetFontStyle(fontStyle == default ? FontStyle.Normal : fontStyle).SetWhiteSpace(whiteSpace == default ? WhiteSpace.Normal : whiteSpace);
        //     builder?.Invoke(label);
        //     return label.BuildAndInitialize();
        // }
        //
        // public LocalizableLabel GameTextSmall(string locKey = default, string text = default, string name = null, Action<LabelBuilder> builder = default)
        // {
        //     return Label(locKey, new Length(12, Pixel), text: text, name: name, builder: builder);
        // }
        //
        // public LocalizableLabel GameText(string locKey = default, string text = default, string name = null, Action<LabelBuilder> builder = default)
        // {
        //     return Label(locKey, new Length(13, Pixel), text: text, name: name, builder: builder);
        // }
        //
        // public LocalizableLabel GameTextBig(string locKey = default, string text = default, string name = null, Action<LabelBuilder> builder = default)
        // {
        //     return Label(locKey, new Length(14, Pixel), text: text, name: name, builder: builder);
        // }
        //
        // public LocalizableLabel GameTextHeading(string locKey = default, string text = default, string name = null, Action<LabelBuilder> builder = default)
        // {
        //     return Label(locKey, new Length(15, Pixel), text: text, name: name, builder: builder);
        // }
        //
        // public LocalizableLabel GameTextTitle(string locKey = default, string text = default, string name = null, Action<LabelBuilder> builder = default)
        // {
        //     return Label(locKey, new Length(18, Pixel), text: text, name: name, builder: builder);
        // }
        //
        // public LocalizableLabel DefaultText(string locKey = default, string text = default, string name = null, Action<LabelBuilder> builder = default)
        // {
        //     return Label(locKey, new Length(14, Pixel), new StyleColor(new Color(1.00f, 1.000f, 1.000f, 1.000f)), text: text, name: name, builder: builder);
        // }
        //
        // public LocalizableLabel DefaultBold(string locKey = default, string text = default, string name = null, Action<LabelBuilder> builder = default)
        // {
        //     return Label(locKey, new Length(14, Pixel), new StyleColor(new Color(1.00f, 1.000f, 1.000f, 1.000f)), FontStyle.Bold, text: text, name: name, builder: builder);
        // }
        //
        // public LocalizableLabel DefaultBig(string locKey = default, string text = default, string name = null, Action<LabelBuilder> builder = default)
        // {
        //     return Label(locKey, new Length(17, Pixel), new StyleColor(new Color(1.00f, 1.000f, 1.000f, 1.000f)), text: text, name: name, builder: builder);
        // }
        //
        // public LocalizableLabel DefaultHeader(string locKey = default, string text = default, string name = null, Action<LabelBuilder> builder = default)
        // {
        //     return Label(locKey, new Length(22, Pixel), new StyleColor(new Color(1.00f, 1.000f, 1.000f, 1.000f)), text: text, name: name, builder: builder);
        // }
    }
}