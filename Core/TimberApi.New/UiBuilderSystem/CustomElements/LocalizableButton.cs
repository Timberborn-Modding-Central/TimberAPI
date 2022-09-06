using System;
using Timberborn.CoreUI;
using Timberborn.Localization;
using UnityEngine.UIElements;

#pragma warning disable CS8618
// ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace TimberApi.New.UiBuilderSystem.CustomElements
{
    public class LocalizableButton : Button, ILocalizableElement
    {
        private string _textLocKey;

        public string TextLocKey
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _textLocKey = value;
            }
        }

        private readonly NineSliceBackground _nineSliceBackground = new();

        public LocalizableButton()
        {
            Delegate[] invocationList = generateVisualContent.GetInvocationList();
            generateVisualContent += new Action<MeshGenerationContext>(OnGenerateVisualContent);
            foreach (Delegate b in invocationList)
            {
                generateVisualContent = (Action<MeshGenerationContext>)Delegate.Remove(generateVisualContent, b)!;
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