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
            rootBuilder.AddPreset(factory => factory.Labels().DefaultHeader("preview.sliders.variants", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderDiamond(1, 100));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderIntDiamond(1, 10));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderCircle(1, 100));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderIntCircle(1, 10));
            

            rootBuilder.AddPreset(factory => factory.Labels().DefaultHeader("preview.sliders.floatslider", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold("preview.sliders.normal"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderDiamond(1, 100));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold("preview.sliders.starting30"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderDiamond(1, 100, 30));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold("preview.sliders.fixedwidth"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderDiamond(1, 100, width: new Length(250, Pixel)));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold("preview.sliders.labeled"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderDiamond(1, 100, locKey: "preview.sliders.labeled.short"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderDiamond(1, 100, locKey: "preview.sliders.labeled.long"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderDiamond(1, 100, locKey: "preview.sliders.labeled.superlong"));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold("preview.sliders.progress"));
            rootBuilder.AddComponent(builder => builder
                .SetName("controlledSlider")
                .AddPreset(factory => factory.Sliders().SliderDiamond(1, 10, name: "Slider",builder: sliderBuilder => sliderBuilder.SetStyle(style => style.flexGrow = 1f)))
                .AddPreset(factory => factory.Labels().DefaultText(name: "Value", text: "1.00", builder: labelBuilder => labelBuilder.SetMargin(new Margin(new Length(8, Pixel), 0))))
                .SetFlexDirection(FlexDirection.Row));
            
            rootBuilder.AddPreset(factory => factory.Labels().DefaultHeader("preview.sliders.intslider", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold("preview.sliders.normal"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderIntDiamond(1, 25));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold("preview.sliders.starting10"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderIntDiamond(1, 25, 10));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold("preview.sliders.fixedwidth"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderIntDiamond(1, 25, width: new Length(250, Pixel)));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold("preview.sliders.labeled"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderIntDiamond(1, 25, locKey: "preview.sliders.labeled.short"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderIntDiamond(1, 25, locKey: "preview.sliders.labeled.long"));
            rootBuilder.AddPreset(factory => factory.Sliders().SliderIntDiamond(1, 25, locKey: "preview.sliders.labeled.superlong"));
            rootBuilder.AddPreset(factory => factory.Labels().DefaultBold("preview.sliders.progress"));
            rootBuilder.AddComponent(builder => builder
                .SetName("controlledSliderInt")
                .AddPreset(factory => factory.Sliders().SliderIntDiamond(1, 10, name: "Slider",builder: sliderBuilder => sliderBuilder.SetStyle(style => style.flexGrow = 1f)))
                .AddPreset(factory => factory.Labels().DefaultText(name: "Value", text: "1", builder: labelBuilder => labelBuilder.SetMargin(new Margin(new Length(8, Pixel), 0))))
                .SetFlexDirection(FlexDirection.Row));

            VisualElement root = rootBuilder.BuildAndInitialize();
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