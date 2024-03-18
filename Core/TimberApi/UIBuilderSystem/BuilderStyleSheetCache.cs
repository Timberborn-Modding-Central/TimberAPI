using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UIElements;

namespace TimberApi.UiBuilderSystem
{
    public class BuilderStyleSheetCache
    {
        private readonly Dictionary<Type, StyleSheet> _builderStyleSheets = new();
        
        public bool TryGet(Type builder, [MaybeNullWhen(false)] out StyleSheet styleSheet)
        {
            return _builderStyleSheets.TryGetValue(builder, out styleSheet);
        }
        
        public void Add(Type builder, StyleSheet styleSheet)
        {
            _builderStyleSheets.Add(builder, styleSheet);
        }
    }
}