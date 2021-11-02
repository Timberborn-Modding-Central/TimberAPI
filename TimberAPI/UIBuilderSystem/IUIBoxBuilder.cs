using System;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem
{
    public interface IUIBoxBuilder
    {
        IUIBoxBuilder AddComponents(Action<IUIComponentBuilder> action);
        IUIBoxBuilder AddHeader(string text, string name = null, string wrapperName = null, Action<IStyle> style = null, Action<IStyle> wrapperStyle = null);
        IUIBoxBuilder AddCloseButton(Length width = default, Length height = default, Length fontsize = default, string name = null, Action<IStyle> style = null);
        IUIBoxBuilder BoxStyle(Action<IStyle> style);
        IUIBoxBuilder BoxWrapperStyle(Action<IStyle> style);
        IUIBoxBuilder SetWidth(Length width);
        IUIBoxBuilder SetHeight(Length height);
        IUIBoxBuilder SetPadding(Length padding);
        IUIBoxBuilder SetName(string name);
        VisualElement Build();
    }
}