using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem
{
    public interface IUIComponentBuilder
    {
        /// <summary>
        /// Customize the root element style
        /// </summary>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder RootStyle(Action<IStyle> style);
        
        /// <summary>
        /// Add toggle that's used in settings with localized label
        /// </summary>
        /// <param name="textLocKey">Localization key</param>
        /// <param name="name">Element name</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddLocalizedSettingToggle(string textLocKey = null, string name = null, Action<IStyle> style = null);
        
        /// <summary>
        /// Add toggle that's used in settings with label
        /// </summary>
        /// <param name="text"></param>
        /// <param name="name">Element name</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddSettingToggle(string text = null, string name = null, Action<IStyle> style = null);
        
        /// <summary>
        /// Add box that is used in the menu screen
        /// </summary>
        /// <param name="children">Components inside the box</param>
        /// <param name="width">box width</param>
        /// <param name="height">box height</param>
        /// <param name="padding">box padding</param>
        /// <param name="name">Element name</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddBox(Action<IUIComponentBuilder> children, Length width = default, Length height = default, Length padding = default, string name = null, Action<IStyle> style = null);
        
        /// <summary>
        /// Add scroll view used in settings view
        /// </summary>
        /// <param name="children">Components inside the scroll view</param>
        /// <param name="name">Element name</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddScrollView(Action<IUIComponentBuilder> children, string name = null, Action<IStyle> style = null);
        
        /// <summary>
        /// Adds a slider with percent value label and localized name
        /// </summary>
        /// <param name="low">lowest value</param>
        /// <param name="high">highest value</param>
        /// <param name="textLocKey">Localization key</param>
        /// <param name="width">Total width (default 100%)</param>
        /// <param name="sliderName">slider element name</param>
        /// <param name="sliderValueName">slider value element name</param>
        /// <param name="wrapperName">wrapper element name</param>
        /// <param name="wrapperStyle">Customize wrapper style</param>
        /// <param name="sliderStyle">Customize slider style</param>
        /// <param name="labelStyle">Customize label style</param>
        IUIComponentBuilder AddLocalizedSlider(int low, int high, string textLocKey = "", Length width = default, string sliderName = null, string sliderValueName = null, string wrapperName = null, Action<IStyle> wrapperStyle = null, Action<IStyle> sliderStyle = null, Action<IStyle> labelStyle = null);
        
        /// <summary>
        /// Adds a slider with percent value label and name
        /// </summary>
        /// <param name="low">lowest value</param>
        /// <param name="high">highest value</param>
        /// <param name="text">Text left from slider</param>
        /// <param name="width">Total width (default 100%)</param>
        /// <param name="sliderName">slider element name</param>
        /// <param name="sliderValueName">slider value element name</param>
        /// <param name="wrapperName">wrapper element name</param>
        /// <param name="wrapperStyle">Customize wrapper style</param>
        /// <param name="sliderStyle">Customize slider style</param>
        /// <param name="labelStyle">Customize label style</param>
        IUIComponentBuilder AddSlider(int low, int high, string text = "", Length width = default, string sliderName = null, string sliderValueName = null, string wrapperName = null, Action<IStyle> wrapperStyle = null, Action<IStyle> sliderStyle = null, Action<IStyle> labelStyle = null);
        
        /// <summary>
        /// Add header that is used in boxes with localization
        /// </summary>
        /// <param name="textLocKey">Localization key</param>
        /// <param name="name">Element name</param>
        /// <param name="wrapperName"></param>
        /// <param name="style">Customize component style</param>
        /// <param name="wrapperStyle"></param>
        IUIComponentBuilder AddLocalizedBoxHeader(string textLocKey, string name = null, string wrapperName = null, Action<IStyle> style = null, Action<IStyle> wrapperStyle = null);
        
        /// <summary>
        /// Add header that is used in boxes
        /// </summary>
        /// <param name="text"></param>
        /// <param name="name">Element name</param>
        /// <param name="wrapperName">wrapper element name</param>
        /// <param name="style">Customize component style</param>
        /// <param name="wrapperStyle">Customize wrapper style</param>
        IUIComponentBuilder AddBoxHeader(string text, string name = null, string wrapperName = null, Action<IStyle> style = null, Action<IStyle> wrapperStyle = null);
        
        /// <summary>
        /// Add a centered label for menu sections
        /// </summary>
        /// <param name="text"></param>
        /// <param name="name">Element name</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddSectionHeader(string text, string name = null, Action<IStyle> style = null);
        
        /// <summary>
        /// Add a normal menu localized button with localization key
        /// </summary>
        /// <param name="textLocKey">Localization key</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fontsize"></param>
        /// <param name="name">Element name</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddLocalizedButton(string textLocKey, Length width = default, Length height = default, Length fontsize = default, string name = null, Action<IStyle> style = null);
        
        /// <summary>
        /// Add a normal menu button
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fontsize"></param>
        /// <param name="name">Element name</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddButton(string text, Length width = default, Length height = default, Length fontsize = default, string name = null, Action<IStyle> style = null);
        
        /// <summary>
        /// Add a button with a cross icon
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fontsize"></param>
        /// <param name="name">Element name</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddCloseButton(Length width = default, Length height = default, Length fontsize = default, string name = null, Action<IStyle> style = null);

        /// <summary>
        /// Add a button with a left arrow icon
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fontSize"></param>
        /// <param name="name">Element name</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddButtonLeftArrow(Length width = default, Length height = default, Length fontSize = default,
            string name = null, Action<IStyle> style = null);

        /// <summary>
        /// Add button with a right arrow icon
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fontSize"></param>
        /// <param name="name">Element name</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddButtonRightArrow(Length width = default, Length height = default, Length fontSize = default,
            string name = null, Action<IStyle> style = null);

        /// <summary>
        /// Add wrapper for other components
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="name">Element name</param>
        /// <param name="flexDirection"></param>
        /// <param name="justifyContent"></param>
        /// <param name="wrap"></param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddWrapper(Action<IUIComponentBuilder> builder, string name = null, FlexDirection flexDirection = FlexDirection.Row, Justify justifyContent = Justify.FlexStart, Wrap wrap = Wrap.Wrap, Action<IStyle> style = null);
        
        /// <summary>
        /// Add a input text field
        /// </summary>
        /// <param name="fieldName">field element name</param>
        /// <param name="inputName">input element name</param>
        /// <param name="defaultText">Default text when created</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fontsize"></param>
        /// <param name="multiline">Can input use enters</param>
        /// <param name="textAnchor"></param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddTextField(string fieldName = null, string inputName = null, string defaultText = "", Length width = default, Length height = default, Length fontsize = default, bool multiline = false, TextAnchor textAnchor = TextAnchor.MiddleCenter, Action<IStyle> style = null);
        
        /// <summary>
        /// Add a label localized with localization key
        /// </summary>
        /// <param name="textLocKey">Localization key</param>
        /// <param name="width"></param>
        /// <param name="textAnchor"></param>
        /// <param name="name">Element name</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddLocalizedLabel(string textLocKey, Length width = default, TextAnchor textAnchor = TextAnchor.UpperLeft, string name = null, Action<IStyle> style = null);
        
        /// <summary>
        /// Add a label of text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <param name="textAnchor"></param>
        /// <param name="name">Element name</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddLabel(string text, Length width = default, TextAnchor textAnchor = TextAnchor.UpperLeft, string name = null, Action<IStyle> style = null);
        
        /// <summary>
        /// Add a custom component
        /// </summary>
        /// <param name="component">Custom visual element</param>
        /// <param name="style">Customize component style</param>
        IUIComponentBuilder AddCustomComponent(VisualElement component, Action<IStyle> style = null);
        
        /// <summary>
        /// Visual element that can be used in timberborn UI
        /// </summary>
        VisualElement Build();
    }
}