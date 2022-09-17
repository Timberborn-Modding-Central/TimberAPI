using System.Reflection;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews
{
    public class BackgroundPreview : IUIBuilderPreview
    {
        private readonly UIBuilder _uiBuilder;

        public BackgroundPreview(UIBuilder uiBuilder)
        {
            _uiBuilder = uiBuilder;
        }

        public string GetPreviewKey()
        {
            return "backgrounds";
        }

        public string GetPreviewName()
        {
            return "Backgrounds + scale";
        }

        public VisualElement GetPreview()
        {
            FieldInfo[] backgrounds = typeof(TimberApiStyle.Backgrounds).GetFields(BindingFlags.Static | BindingFlags.Public);
            FieldInfo[] scales = typeof(TimberApiStyle.Scales).GetFields(BindingFlags.Static | BindingFlags.Public);

            VisualElementBuilder root = _uiBuilder.CreateComponentBuilder().CreateVisualElement();

            foreach (FieldInfo scaleInfo in scales)
            {
                VisualElementBuilder scaleSection = _uiBuilder.CreateComponentBuilder().CreateVisualElement()
                    .SetFlexDirection(FlexDirection.Row)
                    .SetFlexWrap(Wrap.Wrap)
                    .SetJustifyContent(Justify.Center)
                    .AddComponent(builder => builder.SetWidth(new Length(100, Percent))
                        .SetAlignItems(Align.Center)
                        .AddPreset(factory => factory.Labels().DefaultHeader(text: scaleInfo.Name)));
                foreach (FieldInfo backgroundInfo in backgrounds)
                {
                    scaleSection.AddComponent(elementBuilder => elementBuilder
                        .AddPreset(factory => factory.Labels().DefaultText(text: backgroundInfo.Name))
                        .SetJustifyContent(Justify.Center)
                        .SetAlignContent(Align.Center)
                        .SetPadding(2)
                        .SetMargin(2)
                        .AddClass(backgroundInfo.GetValue(null).ToString())
                        .AddClass(scaleInfo.GetValue(null).ToString())
                        .SetHeight(new Length(100, Pixel))
                        .SetWidth(new Length(125, Pixel))
                        .SetFlexDirection(FlexDirection.Row)
                    );
                }

                root.AddComponent(scaleSection.Build());
            }
            
            return root.Build();
        }
    }
}