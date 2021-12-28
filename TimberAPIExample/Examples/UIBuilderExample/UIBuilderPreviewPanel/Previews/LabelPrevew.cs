using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews
{
    public class LabelPreview : IUIBuilderPreview
    {
        private readonly UIBuilder _uiBuilder;

        public LabelPreview(UIBuilder uiBuilder)
        {
            _uiBuilder = uiBuilder;
        }

        public string GetPreviewKey()
        {
            return "labels";
        }

        public string GetPreviewName()
        {
            return "Labels";
        }
        
        public VisualElement GetPreview()
        {
            VisualElementBuilder root = _uiBuilder.CreateComponentBuilder().CreateVisualElement();

            root.AddPreset(factory => factory.Labels().DefaultText("preview.labels.previewtext", builder: builder => builder.SetMargin(new Margin(0,0,new Length(10, Pixel),0))));
            root.AddPreset(factory => factory.Labels().DefaultBold("preview.labels.previewtext", builder: builder => builder.SetMargin(new Margin(0,0,new Length(10, Pixel),0))));
            root.AddPreset(factory => factory.Labels().DefaultBig("preview.labels.previewtext", builder: builder => builder.SetMargin(new Margin(0,0,new Length(10, Pixel),0))));
            root.AddPreset(factory => factory.Labels().DefaultHeader("preview.labels.previewtext", builder: builder => builder.SetMargin(new Margin(0,0,new Length(10, Pixel),0))));
            root.AddPreset(factory => factory.Labels().GameTextSmall("preview.labels.previewtext", builder: builder => builder.SetMargin(new Margin(0,0,new Length(10, Pixel),0))));
            root.AddPreset(factory => factory.Labels().GameText("preview.labels.previewtext", builder: builder => builder.SetMargin(new Margin(0,0,new Length(10, Pixel),0))));
            root.AddPreset(factory => factory.Labels().GameTextBig("preview.labels.previewtext", builder: builder => builder.SetMargin(new Margin(0,0,new Length(10, Pixel),0))));
            root.AddPreset(factory => factory.Labels().GameTextHeading("preview.labels.previewtext", builder: builder => builder.SetMargin(new Margin(0,0,new Length(10, Pixel),0))));
            root.AddPreset(factory => factory.Labels().GameTextTitle("preview.labels.previewtext", builder: builder => builder.SetMargin(new Margin(0,0,new Length(10, Pixel),0))));

            return root.BuildAndInitialize();
        }
    }
}