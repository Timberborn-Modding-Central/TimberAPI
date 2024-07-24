using System;
using Timberborn.AssetSystem;
using UnityEngine;
using UnityEngine.UIElements;
using UnityStyleSheetBuilder = UnityEngine.UIElements.StyleSheets.StyleSheetBuilder;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem
{
    public partial class StyleSheetBuilder
    {
        private readonly StyleSheet _styleSheet = ScriptableObject.CreateInstance<StyleSheet>();
        
        private readonly UnityStyleSheetBuilder _builder;

        private readonly PropertyBuilder _propertyBuilder;
        
        private bool _built = false;

        public StyleSheetBuilder(IAssetLoader assetLoader)
        {
            _builder = new UnityStyleSheetBuilder();
            _propertyBuilder = new PropertyBuilder(_builder, assetLoader);
        }

        public StyleSheetBuilder AddComplexSelector(Func<ComplexSelectorBuilder, ComplexSelectorBuilder> complexSelector, Action<PropertyBuilder> propertyBuilder)
        {
            _builder.BeginRule(0);
            
            var complexSelectorBuilder = new ComplexSelectorBuilder(_builder);
            
            complexSelector.Invoke(complexSelectorBuilder).Build();
            
            propertyBuilder.Invoke(_propertyBuilder);
            
            _builder.EndRule();
            
            return this;
        }
        
        public StyleSheetBuilder AddClass(string className, Action<PropertyBuilder> propertyBuilder)
        {
            return AddComplexSelector(builder => builder.AddClass(className), propertyBuilder);
        }
        
        public StyleSheetBuilder AddClass(string className, PseudoClass[] pseudoClasses, Action<PropertyBuilder> propertyBuilder)
        {
            return AddComplexSelector(builder => builder.AddClass(className).AddPseudoClass(pseudoClasses), propertyBuilder);
        }
        
        public StyleSheetBuilder AddType(SelectorType selectorType, Action<PropertyBuilder> propertyBuilder)
        {
            return AddComplexSelector(builder => builder.AddType(selectorType), propertyBuilder);
        }
        
        public StyleSheetBuilder AddType(SelectorType selectorType, PseudoClass[] pseudoClasses, Action<PropertyBuilder> propertyBuilder)
        {
            return AddComplexSelector(builder => builder.AddType(selectorType).AddPseudoClass(pseudoClasses), propertyBuilder);
        }
        
        public StyleSheetBuilder AddId(string idName, Action<PropertyBuilder> propertyBuilder)
        {
            return AddComplexSelector(builder => builder.AddId(idName), propertyBuilder);
        }
        
        public StyleSheetBuilder AddId(string idName, PseudoClass[] pseudoClasses, Action<PropertyBuilder> propertyBuilder)
        {
            return AddComplexSelector(builder => builder.AddId(idName).AddPseudoClass(pseudoClasses), propertyBuilder);
        }
        
        public StyleSheet Build()
        {
            if (_built)
            {
                throw new InvalidOperationException("The stylesheet is already built");
            }

            _built = true;
            
            _builder.BuildTo(_styleSheet);
            
            return _styleSheet;
        }
    }
}