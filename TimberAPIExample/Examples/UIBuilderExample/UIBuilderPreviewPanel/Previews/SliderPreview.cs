using System;
using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews
{
    public class SliderPreview : IUIBuilderPreview
    {
        private readonly UIBuilder _uiBuilder;

        public SliderPreview(UIBuilder uiBuilder)
        {
            _uiBuilder = uiBuilder;
        }

        public string GetPreviewKey()
        {
            return "sliders";
        }

        public string GetPreviewName()
        {
            return "Sliders";
        }
        
        public VisualElement GetPreview()
        {
            VisualElementBuilder rootBuilder = _uiBuilder.CreateComponentBuilder().CreateVisualElement();

            rootBuilder.AddPreset(factory => factory.Labels().DefaultHeader(text: "Float sliders", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold(text: "Normal"));
            rootBuilder.AddPreset(factory => factory.Sliders().Slider(1, 100));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold(text: "Starting value: 30"));
            rootBuilder.AddPreset(factory => factory.Sliders().Slider(1, 100, 30));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold(text: "Fixed width"));
            rootBuilder.AddPreset(factory => factory.Sliders().Slider(1, 100, width: new Length(250, Pixel)));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold(text: "Labeled"));
            rootBuilder.AddPreset(factory => factory.Sliders().Slider(1, 100, text: "Label"));
            rootBuilder.AddPreset(factory => factory.Sliders().Slider(1, 100, text: "Label long"));
            rootBuilder.AddPreset(factory => factory.Sliders().Slider(1, 100, text: "Label super long"));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold(text: "Progress text"));
            rootBuilder.AddComponent(builder => builder
                .SetName("controlledSlider")
                .AddPreset(factory => factory.Sliders().Slider(1, 10, name: "Slider",builder: sliderBuilder => sliderBuilder.SetStyle(style => style.flexGrow = 1f)))
                .AddPreset(factory => factory.Labels().DefaultText(name: "Value", text: "1.00", builder: labelBuilder => labelBuilder.SetMargin(new Margin(new Length(8, Pixel), 0))))
                .SetFlexDirection(FlexDirection.Row));
            
            rootBuilder.AddPreset(factory => factory.Labels().DefaultHeader(text: "Int sliders", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold(text: "Normal"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderInt(1, 25));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold(text: "Starting value: 10"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderInt(1, 25, 10));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold(text: "Fixed width"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderInt(1, 25, width: new Length(250, Pixel)));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold(text: "Labeled"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderInt(1, 25, text: "Label"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderInt(1, 25, text: "Label long"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderInt(1, 25, text: "Label super long"));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold(text: "Progress text"));
            rootBuilder.AddComponent(builder => builder
                .SetName("controlledSliderInt")
                .AddPreset(factory => factory.Sliders().SliderInt(1, 10, name: "Slider",builder: sliderBuilder => sliderBuilder.SetStyle(style => style.flexGrow = 1f)))
                .AddPreset(factory => factory.Labels().DefaultText(name: "Value", text: "1", builder: labelBuilder => labelBuilder.SetMargin(new Margin(new Length(8, Pixel), 0))))
                .SetFlexDirection(FlexDirection.Row));

            VisualElement root = rootBuilder.Build();
            InitializeSlider(root, "controlledSlider");
            InitializeSliderInt(root, "controlledSliderInt");
            return root;
        }
        
        private void InitializeSlider(
            VisualElement root,
            string name)
        {
            VisualElement e = root.Q<VisualElement>(name, (string) null);
            Slider control = e.Q<Slider>("Slider", (string) null);
            Label valueLabel = e.Q<Label>("Value", (string) null);
            control.RegisterValueChangedCallback (v =>
            {
                valueLabel.text = v.newValue.ToString("N");
            });
        }
        
        private void InitializeSliderInt(
            VisualElement root,
            string name)
        {
            VisualElement e = root.Q<VisualElement>(name, (string) null);
            SliderInt control = e.Q<SliderInt>("Slider", (string) null);
            Label valueLabel = e.Q<Label>("Value", (string) null);
            control.RegisterValueChangedCallback (v =>
            {
                valueLabel.text = v.newValue.ToString("0");
            });
        }
    }
}