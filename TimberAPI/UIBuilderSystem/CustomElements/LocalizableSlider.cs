using Timberborn.CoreUI;
using Timberborn.Localization;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem.CustomElements
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
            this.label = loc.T(this._textLocKey);
        }
    }
}