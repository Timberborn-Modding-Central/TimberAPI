using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Timberborn.CoreUI;
using UnityEngine.UIElements;
using LocalizableButton = TimberbornAPI.UIBuilderSystem.CustomElements.LocalizableButton;
using LocalizableLabel = TimberbornAPI.UIBuilderSystem.CustomElements.LocalizableLabel;
using LocalizableToggle = TimberbornAPI.UIBuilderSystem.CustomElements.LocalizableToggle;

namespace TimberbornAPI.UIBuilderSystem
{
    [SuppressMessage("", "Publicizer001")]
    public class ElementFactory : IElementFactory
    {
        public Toggle Toggle(IEnumerable<string> classes = null, string name = null)
        {
            Toggle element = new Toggle();
            if (name != null)
                element.name = name;
            if (classes != null)
                element.classList.AddRange(classes);
            return element;
        }

        public LocalizableToggle LocalizedToggle(IEnumerable<string> classes = null, string name = null)
        {
            LocalizableToggle element = new LocalizableToggle();
            if (name != null)
                element.name = name;
            if (classes != null)
                element.classList.AddRange(classes);
            return element;
        }

        public SliderInt Slider(IEnumerable<string> classes = null, string name = null)
        {
            SliderInt element = new SliderInt();
            if (name != null)
                element.name = name;
            if (classes != null)
                element.classList.AddRange(classes);
            return element;
        }

        public LocalizableSlider LocalizedSlider(IEnumerable<string> classes = null, string name = null)
        {
            LocalizableSlider element = new LocalizableSlider();
            if (name != null)
                element.name = name;
            if (classes != null)
                element.classList.AddRange(classes);
            return element;
        }

        public Button Button(IEnumerable<string> classes = null, string name = null)
        {
            Button element = new Button();
            if (name != null)
                element.name = name;
            if (classes != null)
                element.classList.AddRange(classes);
            return element;
        }

        public LocalizableButton LocalizedButton(IEnumerable<string> classes = null, string name = null)
        {
            LocalizableButton element = new LocalizableButton();
            if (name != null)
                element.name = name;
            if (classes != null)
                element.classList.AddRange(classes);
            return element;
        }

        public Label Label(IEnumerable<string> classes = null, string name = null)
        {
            Label element = new Label();
            if (name != null)
                element.name = name;
            if (classes != null)
                element.classList.AddRange(classes);
            return element;
        }

        public LocalizableLabel LocalizedLabel(IEnumerable<string> classes = null, string name = null)
        {
            LocalizableLabel element = new LocalizableLabel();
            if (name != null)
                element.name = name;
            if (classes != null)
                element.classList.AddRange(classes);
            return element;
        }

        public VisualElement VisualElement(IEnumerable<string> classes = null, string name = null)
        {
            VisualElement element = new VisualElement();
            if (name != null)
                element.name = name;
            if (classes != null)
                element.classList.AddRange(classes);
            return element;
        }

        public NineSliceVisualElement NineSliceVisualElement(IEnumerable<string> classes = null, string name = null)
        {
            NineSliceVisualElement element = new NineSliceVisualElement();
            if (name != null)
                element.name = name;
            if (classes != null)
                element.classList.AddRange(classes);
            return element;
        }

        public NineSliceTextField TextField(IEnumerable<string> classes = null, string name = null)
        {
            NineSliceTextField element = new NineSliceTextField();
            if (name != null)
                element.name = name;
            if (classes != null)
                element.classList.AddRange(classes);
            return element;
        }

        public ScrollView ScrollView(IEnumerable<string> classes = null, string name = null)
        {
            ScrollView element = new ScrollView();
            if (name != null)
                element.name = name;
            if (classes != null)
                element.classList.AddRange(classes);
            return element;
        }
    }
}