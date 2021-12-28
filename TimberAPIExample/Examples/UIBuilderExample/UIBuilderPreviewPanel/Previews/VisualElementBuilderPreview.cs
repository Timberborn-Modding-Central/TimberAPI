using TimberbornAPI.UIBuilderSystem;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews
{
    public class VisualElementBuilderPreview : IUIBuilderPreview
    {
        private readonly UIBuilder _uiBuilder;

        public VisualElementBuilderPreview(UIBuilder uiBuilder)
        {
            _uiBuilder = uiBuilder;
        }

        public string GetPreviewKey()
        {
            return "visualelement";
        }

        public string GetPreviewName()
        {
            return "VisualElements";
        }
        
        public VisualElement GetPreview()
        {
            VisualElementBuilder root = _uiBuilder.CreateComponentBuilder().CreateVisualElement();

            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Wrap: Wrap", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder =>
            {
                builder.SetFlexDirection(FlexDirection.Row).SetFlexWrap(Wrap.Wrap);
                builder.AddPreset(factory => factory.Buttons().Button(text: "1"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "2"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "3"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "4"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "5"));
            });
            
            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Wrap: WrapReverse", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder =>
            {
                builder.SetFlexDirection(FlexDirection.Row).SetFlexWrap(Wrap.WrapReverse);
                builder.AddPreset(factory => factory.Buttons().Button(text: "1"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "2"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "3"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "4"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "5"));
            });
            
            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Justify content: Start", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder =>
            {
                builder.SetFlexDirection(FlexDirection.Row).SetJustifyContent(Justify.FlexStart);
                builder.AddPreset(factory => factory.Buttons().Button(text: "1"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "2"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "3"));
            });
            
            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Justify content: Center", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder =>
            {
                builder.SetFlexDirection(FlexDirection.Row).SetJustifyContent(Justify.Center);
                builder.AddPreset(factory => factory.Buttons().Button(text: "1"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "2"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "3"));
            });
            
            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Justify content: End", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder =>
            {
                builder.SetFlexDirection(FlexDirection.Row).SetJustifyContent(Justify.FlexEnd);
                builder.AddPreset(factory => factory.Buttons().Button(text: "1"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "2"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "3"));
            });
            
            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Justify content: Around", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder =>
            {
                builder.SetFlexDirection(FlexDirection.Row).SetJustifyContent(Justify.SpaceAround);
                builder.AddPreset(factory => factory.Buttons().Button(text: "1"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "2"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "3"));
            });
            
            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Justify content: Between", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder =>
            {
                builder.SetFlexDirection(FlexDirection.Row).SetJustifyContent(Justify.SpaceBetween);
                builder.AddPreset(factory => factory.Buttons().Button(text: "1"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "2"));
                builder.AddPreset(factory => factory.Buttons().Button(text: "3"));
            });
            return root.Build();
        }
    }
}