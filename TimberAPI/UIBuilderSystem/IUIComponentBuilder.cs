using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem
{
    public interface IUIComponentBuilder
    {
        IUIComponentBuilder RootStyle(Action<IStyle> style);
        IUIComponentBuilder AddLocalizedSettingToggle(string textLocKey = null, string name = null, Action<IStyle> style = null);
        IUIComponentBuilder AddSettingToggle(string text = null, string name = null, Action<IStyle> style = null);
        IUIComponentBuilder AddBox(Action<IUIComponentBuilder> children, Length width = default, Length height = default, Length padding = default, string name = null, Action<IStyle> style = null);
        IUIComponentBuilder AddScrollView(Action<IUIComponentBuilder> children, string name = null, Action<IStyle> style = null);
        IUIComponentBuilder AddLocalizedSlider(int low, int high, string textLocKey = "", Length width = default, string sliderName = null, string sliderValueName = null, string wrapperName = null, Action<IStyle> wrapperStyle = null, Action<IStyle> sliderStyle = null, Action<IStyle> labelStyle = null);
        IUIComponentBuilder AddSlider(int low, int high, string text = "", Length width = default, string sliderName = null, string sliderValueName = null, string wrapperName = null, Action<IStyle> wrapperStyle = null, Action<IStyle> sliderStyle = null, Action<IStyle> labelStyle = null);
        IUIComponentBuilder AddLocalizedBoxHeader(string textLocKey, string name = null, string wrapperName = null, Action<IStyle> style = null, Action<IStyle> wrapperStyle = null);
        IUIComponentBuilder AddBoxHeader(string text, string name = null, string wrapperName = null, Action<IStyle> style = null, Action<IStyle> wrapperStyle = null);
        IUIComponentBuilder AddSectionHeader(string text, string name = null, Action<IStyle> style = null);
        IUIComponentBuilder AddLocalizedButton(string textLocKey, Length width = default, Length height = default, Length fontsize = default, string name = null, Action<IStyle> style = null);
        IUIComponentBuilder AddButton(string text, Length width = default, Length height = default, Length fontsize = default, string name = null, Action<IStyle> style = null);
        IUIComponentBuilder AddCloseButton(Length width = default, Length height = default, Length fontsize = default, string name = null, Action<IStyle> style = null);

        IUIComponentBuilder AddButtonLeftArrow(Length width = default, Length height = default, Length fontSize = default,
            string name = null, Action<IStyle> style = null);

        IUIComponentBuilder AddButtonRightArrow(Length width = default, Length height = default, Length fontSize = default,
            string name = null, Action<IStyle> style = null);

        IUIComponentBuilder AddWrapper(Action<IUIComponentBuilder> builder, string name = null, FlexDirection flexDirection = FlexDirection.Row, Justify justifyContent = Justify.FlexStart, Wrap wrap = Wrap.Wrap, Action<IStyle> style = null);
        IUIComponentBuilder AddTextField(string nameField = null, string nameInput = null, string defaultText = "", Length width = default, Length height = default, Length fontsize = default, bool multiline = false, TextAnchor textAnchor = TextAnchor.MiddleCenter, Action<IStyle> style = null);
        IUIComponentBuilder AddLocalizedLabel(string textLocKey, Length width = default, TextAnchor textAnchor = TextAnchor.UpperLeft, string name = null, Action<IStyle> style = null);
        IUIComponentBuilder AddLabel(string text, Length width = default, TextAnchor textAnchor = TextAnchor.UpperLeft, string name = null, Action<IStyle> style = null);
        IUIComponentBuilder AddCustomComponent(VisualElement component, Action<IStyle> style = null);
        VisualElement Build();
    }
}