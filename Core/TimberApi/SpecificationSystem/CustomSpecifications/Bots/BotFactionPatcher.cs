using System.Diagnostics.CodeAnalysis;
using System.Linq;
using HarmonyLib;
using TimberApi.DependencyContainerSystem;
using TimberApi.HarmonyPatcherSystem;
using Timberborn.Bots;
using Timberborn.GameFactionSystem;
using Timberborn.PrefabSystem;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Bots
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "RedundantAssignment")]
    internal class BotFactionPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberAPI.Bot";

        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<BotFactory>(nameof(BotFactory.Load)),
                GetHarmonyMethod(nameof(LoadPrefix))
            );
        }

        public static bool LoadPrefix(ref Bot ____botPrefab, ObjectCollectionService ____objectCollectionService, FactionService ____factionService)
        {
            var botFactionService = DependencyContainer.GetInstance<BotFactionService>();
            var botFactionId = botFactionService.GetBotFactionIdByFactionId(____factionService.Current.Id);
            ____botPrefab = ____objectCollectionService.GetAllMonoBehaviours<Bot>().Single(bot => bot.GetComponentFast<Prefab>().PrefabName.Contains(botFactionId));
            return true;
        }
    }
}