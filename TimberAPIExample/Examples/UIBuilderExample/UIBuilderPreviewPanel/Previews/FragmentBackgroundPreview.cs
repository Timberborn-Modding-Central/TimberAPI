using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem;
using UnityEngine.UIElements;
using Image = TimberbornAPI.UIBuilderSystem.Image;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews
{
    public class FragmentBackgroundPreview : IUIBuilderPreview
    {
        private readonly IUIBuilder _uiBuilder;

        public FragmentBackgroundPreview(IUIBuilder uiBuilder)
        {
            _uiBuilder = uiBuilder;
        }

        public string GetPreviewName()
        {
            return "Backgrounds";
        }

        public VisualElement GetPreview()
        {
            return _uiBuilder.CreateComponentBuilder()
                .AddWrapper(builder => builder
                    .AddWrapper(bg => bg.AddLabel("Image.Background.BoxBrown"), Image.Background.BoxBrown, padding: new Padding(10))
                    .AddWrapper(bg => bg.AddLabel("Image.Background.BoxGreen"), Image.Background.BoxGreen, padding: new Padding(10)))
                .AddWrapper(builder => builder
                    .AddWrapper(bg => bg.AddLabel("Image.Background.BoxRed"), Image.Background.BoxRed, padding: new Padding(10))
                    // .AddWrapper(bg => bg.AddLabel("Image.Background.StripedRed"), Image.Background.StripedRed, padding: new Padding(10))
                    )
                .AddWrapper(builder => builder
                    .AddWrapper(bg => bg.AddLabel("Image.Background.SquareRed"), Image.Background.SquareRed, padding: new Padding(10))
                    .AddWrapper(bg => bg.AddLabel("Image.Background.StripedGreen"), Image.Background.StripedGreen, padding: new Padding(10)))
                .AddWrapper(builder => builder
                    .AddWrapper(bg => bg.AddLabel("Image.Background.SquareGreen"), Image.Background.SquareGreen, padding: new Padding(10))
                    .AddWrapper(bg => bg.AddLabel("Image.Background.SquareDarkRed"), Image.Background.SquareDarkRed, padding: new Padding(10)))
                .AddWrapper(builder => builder
                    .AddWrapper(bg => bg.AddLabel("Image.Background.SquareTransparentPurple"), Image.Background.SquareTransparentPurple, padding: new Padding(10))
                    .AddWrapper(bg => bg.AddLabel("Image.Background.SubBoxBlue"), Image.Background.SubBoxBlue, padding: new Padding(10)))
                .AddWrapper(builder => builder
                    .AddWrapper(bg => bg.AddLabel("Image.Background.SubBoxFrame"), Image.Background.SubBoxFrame, padding: new Padding(10))
                    .AddWrapper(bg => bg.AddLabel("Image.Background.SubBoxGreen"), Image.Background.SubBoxGreen, padding: new Padding(10)))
                .AddWrapper(builder => builder
                    .AddWrapper(bg => bg.AddLabel("Image.Background.SubBoxPurpleStriped"), Image.Background.SubBoxPurpleStriped, padding: new Padding(10))
                    .AddWrapper(bg => bg.AddLabel("Image.Background.SubBoxPalePurple"), Image.Background.SubBoxPalePurple, padding: new Padding(10)))
                    // .AddWrapper(bg => bg.AddLabel("Image.Background.StripedDarkGreen"), Image.Background.StripedDarkGreen, padding: new Padding(10))
                .AddWrapper(builder => builder
                    .AddWrapper(bg => bg.AddLabel("Image.Background.StripedDarkRed"), Image.Background.StripedDarkRed, padding: new Padding(10))
                    // .AddWrapper(bg => bg.AddLabel("Image.Background.PixelDarkGreen"), Image.Background.PixelDarkGreen, padding: new Padding(10))
                    )
                .AddWrapper(builder => builder
                    .AddButton("X", Image.Button.CircleSmallGreen, width: 20, height: 20)
                    .AddButton("X",Image.Button.CircleSmallRed, width: 20, height: 20)
                    .AddButton("Example",Image.Button.SquareGreen, width: 60, height: 20)
                    .AddButton("Example",Image.Button.SquareRed, width: 60, height: 20)
                    .AddButton(Image.Button.SettingIncrease)
                    .AddButton(Image.Button.SettingDecrease)
                )
                .Build();
        }
    }
}