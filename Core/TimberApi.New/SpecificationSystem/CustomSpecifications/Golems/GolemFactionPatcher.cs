using System.Linq;
using HarmonyLib;
using TimberApi.Common.SingletonSystem.Singletons;
using Timberborn.EntitySystem;
using Timberborn.FactionSystemGame;
using Timberborn.Golems;

// ReSharper disable RedundantAssignment
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace TimberApi.New.SpecificationSystem.CustomSpecifications.Golems
{
    public class GolemFactionPatcher : ITimberApiLoadableSingleton
    {
        public void Load()
        {
            Harmony harmony = new Harmony("TimberAPI.golem");

            harmony.Patch(
                original: AccessTools.Method(typeof(GolemFactory), nameof(GolemFactory.Load)),
                prefix: new HarmonyMethod(AccessTools.Method(typeof(GolemFactionPatcher), nameof(PrefixGolemPrefab)))
            );
        }

        public static bool PrefixGolemPrefab(ref Golem ____golemPrefab, ObjectCollectionService ____objectCollectionService, FactionService ____factionService)
        {
            GolemFactionService golemFactionService = TimberApiInternal.Container.GetInstance<GolemFactionService>();
            string golemFactionId = golemFactionService.GetGolemFactionIdByFactionId(____factionService.Current.Id);
            ____golemPrefab = ____objectCollectionService.GetAllMonoBehaviours<Golem>().Single(golem => golem.GetComponent<Prefab>().PrefabName.Contains(golemFactionId));
            return false;
        }
    }
}