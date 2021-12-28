using Timberborn.AssetSystem;
using TimberbornAPI.UIBuilderSystem;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews
{
    public class CustomPreview : IUIBuilderPreview
    {
        private readonly UIBuilder _uiBuilder;

        private readonly IResourceAssetLoader _resourceAssetLoader;

        public CustomPreview(UIBuilder uiBuilder, IResourceAssetLoader resourceAssetLoader)
        {
            _uiBuilder = uiBuilder;
            _resourceAssetLoader = resourceAssetLoader;
        }

        public string GetPreviewKey()
        {
            return "custom";
        }

        public string GetPreviewName()
        {
            return "Custom elements";
        }
        
        public VisualElement GetPreview()
        {
            VisualElementBuilder root = _uiBuilder.CreateComponentBuilder().CreateVisualElement();

            root.AddPreset(factory => factory.Labels().DefaultHeader("preview.customs.emptycircle", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(_uiBuilder.CreateComponentBuilder().CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.CircleEmpty)
                .AddClass(TimberApiStyle.Buttons.Hover.CircleEmptyHover)
                .AddClass(TimberApiStyle.Buttons.Active.CircleEmptyActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .AddComponent(builder => builder
                    .SetBackgroundImage(
                        new StyleBackground(_resourceAssetLoader.Load<Sprite>("Ui/Images/Master/ico-clock")))
                    .SetWidth(new Length(40, Pixel))
                    .SetHeight(new Length(40, Pixel))
                    )
                .SetJustifyContent(Justify.Center)
                .SetAlignItems(Align.Center)
                .SetFlexDirection(FlexDirection.Row)
                .SetHeight(new Length(50, Pixel))
                .SetWidth(new Length(50, Pixel)).Build());
            
            root.AddPreset(factory => factory.Labels().DefaultHeader("preview.customs.custombutton", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(_uiBuilder.CreateComponentBuilder().CreateButton()
                .AddClass(TimberApiStyle.Buttons.Normal.ArrowLeftInverted)
                .AddClass(TimberApiStyle.Buttons.Hover.ArrowRightHover)
                .AddClass(TimberApiStyle.Buttons.Active.ArrowDownActive)
                .AddClass(TimberApiStyle.Sounds.Click)
                .SetHeight(new Length(50, Pixel))
                .SetWidth(new Length(50, Pixel)).Build());
            
            return root.BuildAndInitialize();
        }
    }
}