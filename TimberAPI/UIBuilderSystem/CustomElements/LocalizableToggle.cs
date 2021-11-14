using System;
using Timberborn.CoreUI;
using Timberborn.Localization;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem.CustomElements
{
    public class LocalizableToggle : Toggle, ILocalizableElement
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

        private readonly NineSliceBackground _nineSliceBackground = new NineSliceBackground();

        public LocalizableToggle()
        {
            Delegate[] delegateArray = this.generateVisualContent?.GetInvocationList() ?? new Delegate[0];
            this.generateVisualContent = this.generateVisualContent + new Action<MeshGenerationContext>(this.OnGenerateVisualContent);
            foreach (Delegate b in delegateArray)
            {
                this.generateVisualContent = (Action<MeshGenerationContext>)Delegate.Remove((Delegate)this.generateVisualContent, b);
                this.generateVisualContent = (Action<MeshGenerationContext>)Delegate.Combine((Delegate)this.generateVisualContent, b);
            }
            this.RegisterCallback<CustomStyleResolvedEvent>(new EventCallback<CustomStyleResolvedEvent>(this.OnCustomStyleResolved));
        }

        public void Localize(ILoc loc) => this.text = loc.T(this._textLocKey);

        private void OnCustomStyleResolved(CustomStyleResolvedEvent e) => this._nineSliceBackground.GetDataFromStyle(this.customStyle);

        private void OnGenerateVisualContent(MeshGenerationContext mgc)
        {
            if (!this._nineSliceBackground.IsNineSlice)
                return;
            this._nineSliceBackground.GenerateVisualContent(mgc, this.paddingRect);
        }
    }
}