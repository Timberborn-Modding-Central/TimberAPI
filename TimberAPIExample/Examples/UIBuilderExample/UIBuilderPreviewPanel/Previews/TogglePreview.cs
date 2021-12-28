using TimberbornAPI.UIBuilderSystem;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews
{
    public class TogglePreview : IUIBuilderPreview
    {
        private readonly UIBuilder _uiBuilder;

        public TogglePreview(UIBuilder uiBuilder)
        {
            _uiBuilder = uiBuilder;
        }

        public string GetPreviewKey()
        {
            return "toggles";
        }

        public string GetPreviewName()
        {
            return "Toggles";
        }
        
        public VisualElement GetPreview()
        {
            VisualElementBuilder root = _uiBuilder.CreateComponentBuilder().CreateVisualElement();

            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Toggles(checkboxes)", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder =>
            {
                builder.SetFlexDirection(FlexDirection.Row).SetFlexWrap(Wrap.Wrap).SetJustifyContent(Justify.SpaceAround);
                builder.AddPreset(factory => factory.Toggles().Checkbox());
                builder.AddPreset(factory => factory.Toggles().Checkmark());
                builder.AddPreset(factory => factory.Toggles().CheckmarkInverted());
                builder.AddPreset(factory => factory.Toggles().CheckmarkCross());
                builder.AddPreset(factory => factory.Toggles().CheckmarkCrossInverted());
                builder.AddPreset(factory => factory.Toggles().Circle());
                builder.AddPreset(factory => factory.Toggles().CheckmarkAlt());
            });
            root.AddPreset(factory => factory.Toggles().Checkbox(text: "Re have text"));
            root.AddPreset(factory => factory.Toggles().Checkmark(text: "Re have text"));
            root.AddPreset(factory => factory.Toggles().CheckmarkInverted(text: "We have text"));
            root.AddPreset(factory => factory.Toggles().CheckmarkCross(text: "We have text"));
            root.AddPreset(factory => factory.Toggles().CheckmarkCrossInverted(text: "We have text"));
            root.AddPreset(factory => factory.Toggles().Circle(text: "We have text"));
            root.AddPreset(factory => factory.Toggles().CheckmarkAlt(text: "We have text"));

            return root.Build();
        }
    }
}