using Timberborn.CoreUI;
using Timberborn.Localization;
using UnityEngine.UIElements;
#pragma warning disable CS8618
// ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace TimberApi.Internal.UiBuilderSystem.CustomElements
{
    public class LocalizableSlider : Slider, ILocalizableElement
    {
        private string _textLocKey;

        public string TextLocKey
        {
            set
            {
                if (string.IsNullOrWhiteSpace(_textLocKey))
                    _textLocKey = value;
            }
        }

        public void Localize(ILoc loc)
        {
            if(_textLocKey == null)
                return;
            label = loc.T(_textLocKey);
        }
    }
}