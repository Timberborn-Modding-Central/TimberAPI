using System;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem
{
    public interface IUIBoxBuilder
    {
        /// <summary>
        /// Add components using the IUIComponentBuilder
        /// </summary>
        /// <param name="action">Component builder</param>
        IUIBoxBuilder AddComponents(Action<IUIComponentBuilder> action);

        /// <summary>
        /// Add header on the box
        /// </summary>
        /// <param name="text"></param>
        /// <param name="name"></param>
        /// <param name="wrapperName"></param>
        /// <param name="style"></param>
        /// <param name="wrapperStyle"></param>
        IUIBoxBuilder AddHeader(string text, string name = null, string wrapperName = null, Action<IStyle> style = null, Action<IStyle> wrapperStyle = null);

        /// <summary>
        /// Add header with localized key
        /// </summary>
        /// <param name="textLocKey">localized key</param>
        /// <param name="name">label name</param>
        /// <param name="wrapperName">wrapper name</param>
        /// <param name="style">Customize label style</param>
        /// <param name="wrapperStyle">Customize wrapper style</param>
        IUIBoxBuilder AddLocalizedHeader(string textLocKey, string name = null, string wrapperName = null, Action<IStyle> style = null, Action<IStyle> wrapperStyle = null);

        /// <summary>
        /// Add a close button on the box
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fontsize"></param>
        /// <param name="name">Button name</param>
        /// <param name="style">Customize component style</param>
        IUIBoxBuilder AddCloseButton(Length width = default, Length height = default, Length fontsize = default, string name = null, Action<IStyle> style = null);

        /// <summary>
        /// Change the box styling
        /// </summary>
        /// <param name="style"></param>
        IUIBoxBuilder BoxStyle(Action<IStyle> style);

        /// <summary>
        /// Change the box wrapper style
        /// </summary>
        /// <param name="style"></param>
        IUIBoxBuilder BoxWrapperStyle(Action<IStyle> style);

        /// <summary>
        /// Sets the width of the box
        /// </summary>
        /// <param name="width"></param>
        IUIBoxBuilder SetWidth(Length width);

        /// <summary>
        /// Sets the height of the box
        /// </summary>
        /// <param name="height"></param>
        IUIBoxBuilder SetHeight(Length height);

        /// <summary>
        /// Sets the padding of the box
        /// </summary>
        /// <param name="padding"></param>
        IUIBoxBuilder SetPadding(Length padding);

        /// <summary>
        /// Sets the name of the box element
        /// </summary>
        /// <param name="name"></param>
        IUIBoxBuilder SetName(string name);

        /// <summary>
        /// Creates the box visual element with all added parts
        /// </summary>
        VisualElement Build();
    }
}