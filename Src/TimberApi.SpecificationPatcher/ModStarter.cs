namespace TimberApi.SpecificationPatcher;

// public class ModStarter : IModStarter
// {
//     public void StartMod()
//     {
//         var harmony = new Harmony("TimberApi.SpecificationPatcher");
//         Debug.LogError("SWA");
//         harmony.Patch(
//             harmony.GetMethodInfo<JsonMerger>(nameof(JsonMerger.Merge)),
//             harmony.GetHarmonyMethod<ModStarter>(nameof(Patch))
//         );
//     }
//     
//     public static bool Patch(IEnumerable<JObject> jsons, ref JObject __result, JsonMerger __instance)
//     {
//         JObject mergedJson = null;
//         foreach (var json in jsons)
//         {
//             JsonMerger.ProcessCustomTokens(json, JsonMerger.AppendKeyword, __instance._arrayAppenders);
//             JsonMerger.ProcessCustomTokens(json, JsonMerger.RemoveKeyword, __instance._arrayRemovals);
//             mergedJson = JsonMerger.MergeJsons(mergedJson, json);
//         }
//         __instance.ProcessArrayAppenders(mergedJson);
//         __instance.ProcessArrayRemovals(mergedJson);
//         
//         __result = mergedJson;
//         
//         return false;
//     }
// }