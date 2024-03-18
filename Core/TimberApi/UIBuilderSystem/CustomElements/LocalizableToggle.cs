using System;
using Timberborn.CoreUI;
using Timberborn.Localization;
using UnityEngine.UIElements;

#pragma warning disable CS8618
// ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace TimberApi.UiBuilderSystem.CustomElements
{
    public class LocalizableToggle : Toggle, ILocalizableElement
    {
        private readonly NineSliceBackground _nineSliceBackground = new();
        private string _textLocKey;

        public LocalizableToggle()
        {
            Delegate[] delegateArray = generateVisualContent?.GetInvocationList() ?? new Delegate[0];
            generateVisualContent += OnGenerateVisualContent;
            foreach (Delegate b in delegateArray)
            {
                generateVisualContent = (Action<MeshGenerationContext>) Delegate.Remove(generateVisualContent, b)!;
                generateVisualContent = (Action<MeshGenerationContext>) Delegate.Combine(generateVisualContent, b);
            }

            RegisterCallback(new EventCallback<CustomStyleResolvedEvent>(OnCustomStyleResolved));
        }

        public string TextLocKey
        {
            set
            {
                if (string.IsNullOrWhiteSpace(_textLocKey))
                {
                    _textLocKey = value;
                }
            }
        }

        public void Localize(ILoc loc)
        {
            if (_textLocKey == null)
            {
                return;
            }

            text = loc.T(_textLocKey);
        }
#pragma warning disable CS0108, CS0114
        private void OnCustomStyleResolved(CustomStyleResolvedEvent e)
        {
            _nineSliceBackground.GetDataFromStyle(customStyle);
        }

        private void OnGenerateVisualContent(MeshGenerationContext mgc)
        {
            if (!_nineSliceBackground.IsNineSlice)
            {
                return;
            }

            _nineSliceBackground.GenerateVisualContent(mgc, paddingRect);
        }
    }
}