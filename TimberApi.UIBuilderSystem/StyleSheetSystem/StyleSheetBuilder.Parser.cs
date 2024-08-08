using System;
using System.Collections.Generic;
using System.Text;
using Timberborn.Common;
using UnityEngine;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem;

public partial class StyleSheetBuilder
{
    private static readonly char[] Delimiters = ['#', '.', ':'];

    public StyleSheetBuilder AddMultiSelector(IEnumerable<string> complexSelectors, Action<PropertyBuilder> propertyBuilder)
    {
        foreach (var complexSelector in complexSelectors)
        {
            AddSelector(complexSelector, propertyBuilder);
        }

        return this;
    }

    public StyleSheetBuilder AddSelector(string complexSelector, Action<PropertyBuilder> propertyBuilder)
    {
        _builder.BeginRule(0);

        var complexBuilder = new ComplexSelectorBuilder(_builder);

        string[] children = complexSelector.Split('>', StringSplitOptions.RemoveEmptyEntries);

        for (var childIndex = 0; childIndex < children.Length; childIndex++)
        {
            var child = children[childIndex].Trim();
            
            var commaSeparators = child.Split(',', StringSplitOptions.RemoveEmptyEntries);

            for (var commaSeparatorIndex = 0; commaSeparatorIndex < commaSeparators.Length; commaSeparatorIndex++)
            {
                var commaSeparator = commaSeparators[commaSeparatorIndex].Trim();
                
                var descendants = commaSeparator.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
                for (var descendantIndex = 0; descendantIndex < descendants.Length; descendantIndex++)
                {
                    var descendant = descendants[descendantIndex].Trim();
            
                    var stringBuilder = new StringBuilder();
            
                    var firstDelimiter = true;
                    var hasFirstDelimiter = Delimiters.FastContains(descendant[0]);
            
                    foreach (var character in descendant)
                        if (character == '*')
                        {
                            AddSelector(complexBuilder, "*");
                            stringBuilder.Clear();
                        }
                        else
                        {
                            if (Delimiters.FastContains(character))
                            {
                                if (hasFirstDelimiter && firstDelimiter)
                                    firstDelimiter = false;
                                else
                                    AddSelector(complexBuilder, stringBuilder.ToStringAndClear());
                            }
            
                            stringBuilder.Append(character);
                        }
            
                    var selector = stringBuilder.ToString();
            
                    if (!string.IsNullOrWhiteSpace(selector))
                    {
                        AddSelector(complexBuilder, selector);
                    } 
            
                    if (descendants.Length > 1 && descendants.Length - 1 != descendantIndex)
                    {
                        AddSelector(complexBuilder, " ");
                    }
                    
                }
                
                if (commaSeparators.Length > 1 && commaSeparators.Length - 1 != commaSeparatorIndex)
                {
                    AddSelector(complexBuilder, ",");
                }
            }

            if (children.Length > 1 && children.Length - 1 != childIndex)
            {
                AddSelector(complexBuilder, ">");
            } 
        }

        complexBuilder.Build();

        propertyBuilder.Invoke(_propertyBuilder);

        _builder.EndRule();

        return this;
    }

    private static void AddSelector(ComplexSelectorBuilder complexSelectorBuilder, string selector)
    {
        switch (selector[0])
        {
            case '.':
                complexSelectorBuilder.AddClass(selector[1..]);
                break;
            case '#':
                complexSelectorBuilder.AddId(selector[1..]);
                break;
            case ':':
                complexSelectorBuilder.AddPseudoClass(Enum.Parse<PseudoClass>(selector[1..], ignoreCase: true));
                break;
            case '*':
                complexSelectorBuilder.AddWildcard();
                break;
            case ' ':
                Debug.LogWarning(selector);
                complexSelectorBuilder.AddDescendant();
                break;
            case '>':
                complexSelectorBuilder.AddChild();
                break;
            case ',':
                complexSelectorBuilder.AddCommaSeparator();
                break;
            default:
                complexSelectorBuilder.AddType(Enum.Parse<SelectorType>(selector[1..], ignoreCase: true));
                break;
        }
    }
}