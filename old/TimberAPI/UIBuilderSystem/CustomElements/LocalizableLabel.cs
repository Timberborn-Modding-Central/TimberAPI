using System;
using Timberborn.CoreUI;
using Timberborn.Localization;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem.CustomElements
{
    public class LocalizableLabel : Label, ILocalizableElement
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

        private readonly NineSliceBackground _nineSliceBackground = new();

        public LocalizableLabel()
        {
            Delegate[] invocationList = generateVisualContent.GetInvocationList();
            generateVisualContent += OnGenerateVisualContent;
            foreach (Delegate b in invocationList)
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

        private void OnCustomStyleResolved(CustomStyleResolvedEvent e) => _nineSliceBackground.GetDataFromStyle(customStyle);

        private new void OnGenerateVisualContent(MeshGenerationContext mgc)
        {
            if (!_nineSliceBackground.IsNineSlice)
                return;
            _nineSliceBackground.GenerateVisualContent(mgc, paddingRect);
        }
    }
}