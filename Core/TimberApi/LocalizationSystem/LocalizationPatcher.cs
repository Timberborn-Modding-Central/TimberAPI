using System.Collections.Generic;
using HarmonyLib;
using TimberApi.HarmonyPatcherSystem;
using Timberborn.Localization;

namespace TimberApi.LocalizationSystem
{
    public class LocalizationPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberApi.Localization";

        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<LocalizationRepository>(nameof(LocalizationRepository.GetLocalization)),
                postfix: GetHarmonyMethod(nameof(GetLocalizationPatch))
            );
        }

        public static void GetLocalizationPatch(string localizationKey, ref IDictionary<string, string> __result)
        {
            IDictionary<string, string> localization = LocalizationFetcher.GetLocalization(localizationKey);

            TimberApi.ConsoleWriter.Log($"Loaded {localization.Count} custom labels");

            foreach (var (key, value) in localization)
            {
                __result[key] = value;
            }
        }
    }
}