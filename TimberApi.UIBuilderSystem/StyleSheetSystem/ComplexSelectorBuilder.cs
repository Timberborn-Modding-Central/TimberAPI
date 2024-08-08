using System;
using System.Collections.Generic;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine.UIElements;
using UnityStyleSheetBuilder = UnityEngine.UIElements.StyleSheets.StyleSheetBuilder;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem;

public class ComplexSelectorBuilder
{
    private readonly UnityStyleSheetBuilder _builder;

    private readonly List<StyleSelectorPart> _parts = new();

    private int _specificity = 1;

    private StyleSelectorRelationship _styleSelectorRelationship = StyleSelectorRelationship.None;

    public ComplexSelectorBuilder(UnityStyleSheetBuilder builder)
    {
        _builder = builder;
        _builder.BeginComplexSelector(_specificity);
    }

    public ComplexSelectorBuilder Add(string value, StyleSelectorType type, int additionalSpecificity)
    {
        _specificity += additionalSpecificity;
        _parts.Add(new StyleSelectorPart { value = value, type = type });
        return this;
    }

    public ComplexSelectorBuilder AddClass(string name)
    {
        return Add(name, StyleSelectorType.Class, 10);
    }

    public ComplexSelectorBuilder AddType(SelectorType selectorType)
    {
        return Add(selectorType.ToUnityString(), StyleSelectorType.Type, 1);
    }

    public ComplexSelectorBuilder AddId(string name)
    {
        return Add(name, StyleSelectorType.ID, 100);
    }

    public ComplexSelectorBuilder AddPseudoClass(params PseudoClass[] pseudoClasses)
    {
        _parts.AddRange(pseudoClasses.ToStyleSelectorParts());

        _specificity += pseudoClasses.Length * 10;

        return this;
    }

    public ComplexSelectorBuilder AddWildcard()
    {
        return Add("*", StyleSelectorType.Wildcard, 0);
    }

    public ComplexSelectorBuilder AddDescendant()
    {
        if (!CanAddSeparator())
            throw new InvalidOperationException("Can not add descendant separator without any selectors");

        CreateComplexSelector(StyleSelectorRelationship.Descendent);

        return this;
    }

    public ComplexSelectorBuilder AddChild()
    {
        if (!CanAddSeparator())
            throw new InvalidOperationException("Can not add child selector relationship without any selectors");

        CreateComplexSelector(StyleSelectorRelationship.Child);

        return this;
    }
    
    public ComplexSelectorBuilder AddCommaSeparator()
    {
        throw new NotImplementedException("Comma separator has not been implemented, use multiple selectors.");

        return this;
    }

    public void Build()
    {
        if (_parts.Count > 0) CreateComplexSelector(StyleSelectorRelationship.None);

        if (_styleSelectorRelationship != StyleSelectorRelationship.None && _parts.Count == 0)
            throw new InvalidOperationException(
                $"Can not end with an {_styleSelectorRelationship} selector relationship");

        _builder.m_CurrentComplexSelector.specificity = _specificity;
        _builder.EndComplexSelector();
    }

    private bool CanAddSeparator()
    {
        return _parts.Count > 0;
    }

    private void CreateComplexSelector(StyleSelectorRelationship newStyleSelectorRelationship)
    {
        _builder.AddSimpleSelector(_parts.ToArray(), _styleSelectorRelationship);

        _parts.Clear();

        _styleSelectorRelationship = newStyleSelectorRelationship;
    }
}