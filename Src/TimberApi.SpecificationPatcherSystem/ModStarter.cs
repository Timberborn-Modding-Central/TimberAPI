using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Newtonsoft.Json.Linq;
using TimberApi.HarmonySystem;
using Timberborn.ModManagerScene;
using Timberborn.SerializationSystem;
using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.SpecificationPatcherSystem;

public class ModStarter : IModStarter
{
    public void StartMod(IModEnvironment modEnvironment)
    {
        var harmony = new Harmony("TimberApi.SpecificationModifierSystem");
        
        harmony.Patch(
            harmony.GetMethodInfo<JsonMerger>(nameof(JsonMerger.ProcessCustomTokens)),
            harmony.GetHarmonyMethod<SpecificationModifierApplier>(nameof(SpecificationModifierApplier.ProcessCustomTokens))
        );


        // harmony.Patch(
        //     harmony.GetMethodInfo<JsonMerger>(nameof(JsonMerger.ProcessCustomTokens)),
        //     harmony.GetHarmonyMethod<ModStarter>(nameof(Test)),
        // harmony.GetHarmonyMethod<ModStarter>(nameof(Test2))
        // );
    }
    
    public static readonly List<JsonMerger.ArrayModification> ArrayModifications = [];
    
    
    public static void Test(JToken parentToken, string keyword, ICollection<JsonMerger.ArrayModification> arrayModifications)
    {
        foreach (var modifyingProperty in parentToken.Children<JProperty>().ToList())
        {
            if (modifyingProperty.Name.Contains("@"))
            {
                Debug.LogWarning("I HAVE A @");
            }
            
            if (modifyingProperty.Name.Contains("@true"))
            {
                Debug.LogWarning(modifyingProperty.Name);
                JsonMerger.CreateArrayModification(modifyingProperty, "@true", ArrayModifications);
            }
            
            if (modifyingProperty.Name.Contains("@false"))
            {
                modifyingProperty.Remove();
            }
        }
    
        JObject tester = (JObject)parentToken;
        
        foreach (JsonMerger.ArrayModification arrayAppender in ArrayModifications)
        {
            JToken existingArray = tester.SelectToken(arrayAppender.Path);
            if (existingArray != null)
            {
                Debug.LogWarning("HIER KOM IK NIET");
                JsonMerger.AddToExistingArrayProperty(existingArray, arrayAppender.JProperty);
            }
            else
                JsonMerger.AddNewArrayProperty(tester, arrayAppender);
        }
        
        ArrayModifications.Clear();
    }
    
    public static void Test2(JToken parentToken, string keyword,
        ICollection<JsonMerger.ArrayModification> arrayModifications)
    {
        foreach (var modifyingProperty in parentToken.Children<JProperty>().ToList())
        {
            if (modifyingProperty.Name.Contains("@false"))
            {
                Debug.LogWarning("IK BEN NIET MEER IN DE ARRAY");
            }
        }
    }

}