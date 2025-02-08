using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Timberborn.SerializationSystem;
using Timberborn.TimbermeshMaterials;
using UnityEngine.UIElements;

namespace TimberApi.SpecificationPatcherSystem;

internal class SpecificationModifierApplier
{
    private static IDictionary<string, ISpecificationModifierResolver> _specificationModifierResolvers = null!;
    
    public static readonly List<JsonMerger.ArrayModification> ArrayModifications = [];

    public SpecificationModifierApplier(IEnumerable<ISpecificationModifierResolver> specificationModifierResolvers)
    {
        _specificationModifierResolvers = specificationModifierResolvers.ToDictionary(resolver => resolver.Modifier.ToCamelCase());
    }
    
    public static void ProcessCustomTokens(JToken parentToken, string keyword, ICollection<JsonMerger.ArrayModification> arrayModifications)
    {
        if (keyword == JsonMerger.AppendKeyword)
        {
            return;
        }
        
        // Debug.LogWarning(parentToken);
        
        foreach (var modifyingProperty in parentToken.Children<JProperty>().Where(modifyingProperty => modifyingProperty.Name.Contains("@")).ToList())
        {
            // Debug.LogError(modifyingProperty.Name);

            var propertyModifiers = ExtractPropertyModifiers(modifyingProperty);

            ProcessPropertyModifiers(modifyingProperty, propertyModifiers);
            
            modifyingProperty.Remove();
        }
        

        foreach (var arrayAppender in ArrayModifications)
        {
            var existingProperty = ((JObject)parentToken).SelectToken(arrayAppender.Path);
            
            if (existingProperty == null)
            {
                JsonMerger.AddNewArrayProperty((JObject)parentToken, arrayAppender);
            }
            else
            {
                if (existingProperty.Type == JTokenType.Array)
                {
                    JsonMerger.AddToExistingArrayProperty(existingProperty, arrayAppender.JProperty);
                }
                else
                {
                    ((JValue)existingProperty).Value = (string)arrayAppender.JProperty.Value!;
                }
            }
        }
        
        // Debug.LogWarning(parentToken);

        
        ArrayModifications.Clear();
    }

    private static void ProcessPropertyModifiers(JProperty modifyingProperty,
        IEnumerable<PropertyModifier> propertyModifiers)
    {
        var propertyKeywords = new List<string>();
        
        foreach (var propertyModifier in propertyModifiers)
        {
            propertyKeywords.Add($"@{propertyModifier.Modifier}({propertyModifier.Argument})");
            
            if (!_specificationModifierResolvers.ContainsKey(propertyModifier.Modifier))
            {
                throw new Exception($"Modifier (@{propertyModifier.Modifier}) does not have a resolver.");
            }
            
            if (! _specificationModifierResolvers[propertyModifier.Modifier].Resolve(propertyModifier.Argument))
            {
                return;
            }
        }
        
        CreateArrayModification(modifyingProperty, propertyKeywords, ArrayModifications);
    }

    private static void CreateArrayModification(
        JProperty modifyingProperty,
        IReadOnlyCollection<string> keywords,
        ICollection<JsonMerger.ArrayModification> arrayModifications)
    {
        var path = ReplaceMany(modifyingProperty.Path, keywords, string.Empty, StringComparison.OrdinalIgnoreCase);
        var parentPath = modifyingProperty.Parent == null ? string.Empty : modifyingProperty.Parent.Path;
        var content = modifyingProperty.Value;
        modifyingProperty.Value = null!;
        var jProperty = new JProperty(ReplaceMany(modifyingProperty.Name, keywords, string.Empty, StringComparison.OrdinalIgnoreCase), content);
        
        arrayModifications.Add(new JsonMerger.ArrayModification(jProperty, path, parentPath));
    }

    private static IEnumerable<PropertyModifier> ExtractPropertyModifiers(JProperty property)
    {
        foreach (var modifierString in property.Name.Split("@").Skip(1))
        {
            if (! modifierString.EndsWith(")") || ! modifierString.Contains("("))
            {
                throw new Exception($"Modifier pattern invalid, example pattern \"@example(argument)\". Current: @{modifierString}");
            }

            var argumentStartIndex = modifierString.IndexOf('(');

            var modifier = modifierString[..argumentStartIndex];
            
            var argument = modifierString.Substring(argumentStartIndex + 1, modifierString.Length - argumentStartIndex - 2);
            
            yield return new PropertyModifier(modifier, argument);
        }
    }
    
    private static void AddToExistingProperty(JToken existingProperty, JProperty propertyModification)
    {
        if (propertyModification.Type == JTokenType.Array)
        {
            JsonMerger.AddToExistingArrayProperty(existingProperty, propertyModification);
        }
        
        ((JProperty)existingProperty).Value = "POPKEK";
    }
    
    private static string ReplaceMany(string value, IEnumerable<string> oldValues, string newValue, StringComparison comparisonType)
    {
        return oldValues.Aggregate(value, (current, oldValue) => current.Replace(oldValue, newValue, comparisonType));
    }
}