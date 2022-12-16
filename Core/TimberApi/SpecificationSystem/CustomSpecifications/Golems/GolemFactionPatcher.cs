using System.Linq;
using HarmonyLib;
using TimberApi.Common.SingletonSystem;
using TimberApi.DependencyContainerSystem;
using Timberborn.Bots;
using Timberborn.FactionSystemGame;
using Timberborn.PrefabSystem;

// ReSharper disable RedundantAssignment
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace TimberApi.SpecificationSystem.CustomSpecifications.Golems
{
    internal class GolemFactionPatcher : ITimberApiLoadableSingleton
    {
        public void Load()
        {
            var harmony = new Harmony("TimberAPI.bot");

            harmony.Patch(AccessTools.Method(typeof(BotFactory), nameof(BotFactory.Load)),
                new HarmonyMethod(AccessTools.Method(typeof(GolemFactionPatcher), nameof(PrefixGolemPrefab))));
        }

        public static bool PrefixGolemPrefab(ref Bot ____botPrefab, ObjectCollectionService ____objectCollectionService,
            FactionService ____factionService)
        {
            var botFactionService = DependencyContainer.GetInstance<GolemFactionService>();
            string botFactionId = botFactionService.GetGolemFactionIdByFactionId(____factionService.Current.Id);
            ____botPrefab = ____objectCollectionService.GetAllMonoBehaviours<Bot>()
                .Single(bot => bot.GetComponent<Prefab>().PrefabName.Contains(botFactionId));
            return true;
        }
    }
}