using System.Collections.Generic;
using Timberborn.CoreUI;
using UnityEngine.UIElements;
using LocalizableButton = TimberbornAPI.UIBuilderSystem.CustomElements.LocalizableButton;
using LocalizableLabel = TimberbornAPI.UIBuilderSystem.CustomElements.LocalizableLabel;
using LocalizableToggle = TimberbornAPI.UIBuilderSystem.CustomElements.LocalizableToggle;

namespace TimberbornAPI.UIBuilderSystem
{
    public interface IElementFactory
    {
        Toggle Toggle(IEnumerable<string> classes = null, string name = null);
        LocalizableToggle LocalizedToggle(IEnumerable<string> classes = null, string name = null);
        SliderInt Slider(IEnumerable<string> classes = null, string name = null);
        LocalizableSlider LocalizedSlider(IEnumerable<string> classes = null, string name = null);
        Button Button(IEnumerable<string> classes = null, string name = null);
        LocalizableButton LocalizedButton(IEnumerable<string> classes = null, string name = null);
        Label Label(IEnumerable<string> classes = null, string name = null);
        LocalizableLabel LocalizedLabel(IEnumerable<string> classes = null, string name = null);
        VisualElement VisualElement(IEnumerable<string> classes = null, string name = null);
        NineSliceVisualElement NineSliceVisualElement(IEnumerable<string> classes = null, string name = null);
        NineSliceTextField TextField(IEnumerable<string> classes = null, string name = null);
        ScrollView ScrollView(IEnumerable<string> classes = null, string name = null);
    }
}