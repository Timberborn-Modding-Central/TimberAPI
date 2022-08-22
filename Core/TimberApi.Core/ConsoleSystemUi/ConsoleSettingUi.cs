using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Core.ConsoleSystemUi
{
    public class ConsoleSettingUi
    {
        public static VisualElement Create()
        {
            var settings = new VisualElement();

            settings.Add(new SliderInt("Font size", 10,40) { name = "fontSizeSlider" ,style = { fontSize = 25, color = Color.white }});
            settings.Add(new Slider("Opacity", 0,1) { name = "opacitySlider", style = { fontSize = 25, color = Color.white }});
            settings.Add(new Toggle("Compress duplicated errors") { name = "compressDuplicateToggle", style = { fontSize = 25, color = Color.white }});

            return settings;
        }
    }
}