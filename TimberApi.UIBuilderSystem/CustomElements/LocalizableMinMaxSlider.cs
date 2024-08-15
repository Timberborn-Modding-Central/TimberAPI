using Timberborn.CoreUI;
using Timberborn.Localization;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.CustomElements;

[UxmlElement]
public class LocalizableMinMaxSlider : MinMaxSlider, ILocalizableElement
{
    [UxmlAttribute("text-loc-key")]
    public string TextLocKey;

    public void Localize(ILoc loc) => label = loc.T(TextLocKey);
}