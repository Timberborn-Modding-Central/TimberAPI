using TimberbornAPI.UIBuilderSystem;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews
{
    public class TextFieldPreview : IUIBuilderPreview
    {
        private readonly UIBuilder _uiBuilder;
        
        public TextFieldPreview(UIBuilder uiBuilder)
        {
            _uiBuilder = uiBuilder;
        }

        public string GetPreviewKey()
        {
            return "textfields";
        }

        public string GetPreviewName()
        {
            return "TextFields";
        }
        
        public VisualElement GetPreview()
        {
            VisualElementBuilder root = _uiBuilder.CreateComponentBuilder().CreateVisualElement();

            root.AddPreset(factory => factory.Labels().DefaultHeader("preview.textfields.ingame", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddPreset(factory => factory.TextFields().InGameTextField(new Length(200, Pixel)));
            
            root.AddPreset(factory => factory.Labels().DefaultHeader("preview.textfields.ingame.multi", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddPreset(factory => factory.TextFields().InGameTextField(new Length(200, Pixel), new Length(200, Pixel), true));

            root.AddPreset(factory => factory.Labels().DefaultHeader("preview.textfields.ingame.color", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddPreset(factory => factory.TextFields().InGameTextField(new Length(200, Pixel), backgroundColor: Color.grey, fontColor: Color.blue));

            return root.BuildAndInitialize();
        }
    }
}