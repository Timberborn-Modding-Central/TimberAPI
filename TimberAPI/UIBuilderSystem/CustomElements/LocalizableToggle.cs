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
            Delegate[] delegateArray = generateVisualContent?.GetInvocationList() ?? new Delegate[0];
            generateVisualContent += new Action<MeshGenerationContext>(OnGenerateVisualContent);
            foreach (Delegate b in delegateArray)
            {
                generateVisualContent = (Action<MeshGenerationContext>)Delegate.Remove(generateVisualContent, b);
                generateVisualContent = (Action<MeshGenerationContext>)Delegate.Combine(generateVisualContent, b);
            }
            RegisterCallback(new EventCallback<CustomStyleResolvedEvent>(OnCustomStyleResolved));
        }

        public void Localize(ILoc loc)
        {
            if(_textLocKey == null)
                return;
            text = loc.T(_textLocKey);
        }

        #pragma warning disable CS0108, CS0114
        private void OnCustomStyleResolved(CustomStyleResolvedEvent e) => _nineSliceBackground.GetDataFromStyle(customStyle);

        private void OnGenerateVisualContent(MeshGenerationContext mgc)
        {
            if (!_nineSliceBackground.IsNineSlice)
                return;
            _nineSliceBackground.GenerateVisualContent(mgc, paddingRect);
        }
    }
}