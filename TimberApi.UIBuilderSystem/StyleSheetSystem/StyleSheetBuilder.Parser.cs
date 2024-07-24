using System;
using System.Text;
using System.Text.RegularExpressions;
using Timberborn.Common;

namespace TimberApi.UIBuilderSystem.StyleSheetSystem;

public partial class StyleSheetBuilder
{
    private static readonly Regex DescendentRegex = new(@"\s+");

    private static readonly Regex SelectorRegex = new(@"(\b#\w+\b|\.\w+)");

    private static readonly char[] Delimiters = { '#', '.', ':' };

    public StyleSheetBuilder AddSelector(string complexSelector, Action<PropertyBuilder> propertyBuilder)
    {
        _builder.BeginRule(0);

        var complexBuilder = new ComplexSelectorBuilder(_builder);

        string[] children = complexSelector.Split('>', StringSplitOptions.RemoveEmptyEntries);

        for (var childIndex = 0; childIndex < children.Length; childIndex++)
        {
            var child = children[childIndex].Trim();

            var descendants = child.Split(' ', StringSplitOptions.RemoveEmptyEntries);

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

                if (!string.IsNullOrWhiteSpace(selector)) AddSelector(complexBuilder, selector);

                if (descendants.Length > 1 && descendants.Length - 1 != descendantIndex)
                    AddSelector(complexBuilder, " ");
            }

            if (children.Length > 1 && children.Length - 1 != childIndex) AddSelector(complexBuilder, ">");
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
                complexSelectorBuilder.AddPseudoClass(PseudoClass.Hover);
                break;
            case '*':
                complexSelectorBuilder.AddWildcard();
                break;
            case ' ':
                complexSelectorBuilder.AddDescendant();
                break;
            case '>':
                complexSelectorBuilder.AddChild();
                break;
            default:
                complexSelectorBuilder.AddType(SelectorType.VisualElement);
                break;
        }
    }

    // public StyleSheetBuilder AddSelector(string complexSelector, Action<PropertyBuilder> propertyBuilder)
    // {
    //     _builder.BeginRule(0);
    //     
    //     var complexBuilder = new ComplexSelectorBuilder(_builder);
    //     
    //     var childRelations = complexSelector.Trim().Split(">");
    //
    //     for (var i = 0; i < childRelations.Length; i++)
    //     {
    //         var childRelation = childRelations[i];
    //
    //         var descendents = DescendentRegex.Split(childRelation.Trim());
    //
    //         for (var j = 0; j < descendents.Length; j++)
    //         {
    //             var descendent = descendents[j];
    //             
    //             string[] selectors = SelectorRegex.Split(descendent.Trim()).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
    //
    //             foreach (var selector in selectors)
    //             {
    //                 switch (selector[0])
    //                 {
    //                     case '.':
    //                         complexBuilder.AddClass(selector[1..]);
    //                         break;
    //                     case '#':
    //                         complexBuilder.AddId(selector[1..]);
    //                         break;
    //                     case ':':
    //                         complexBuilder.AddPseudoClass(PseudoClass.Hover);
    //                         break;
    //                     default:
    //                         complexBuilder.AddType(SelectorType.VisualElement);
    //                         break;
    //                 }
    //             }
    //
    //             if (descendents.Length <= 1 || descendents.Length - 1 == j)
    //             {
    //                 continue;
    //             }
    //             
    //             complexBuilder.AddDescendant();
    //         }
    //         
    //         if (childRelations.Length > 1 && childRelations.Length - 1 != i)
    //         {
    //             complexBuilder.AddChild();
    //         }
    //     }
    //
    //     complexBuilder.Build();
    //     
    //     propertyBuilder.Invoke(_propertyBuilder);
    //     
    //     _builder.EndRule();
    //
    //     return this;
    // }
}