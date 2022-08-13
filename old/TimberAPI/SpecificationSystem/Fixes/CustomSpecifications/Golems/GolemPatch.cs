using System.Linq;
using HarmonyLib;
using Timberborn.EntitySystem;
using Timberborn.FactionSystemGame;
using Timberborn.Golems;

namespace TimberbornAPI.SpecificationSystem.Fixes.CustomSpecifications.Golems
{
    [HarmonyPatch(typeof(GolemFactory), "Load")]
    public static class GolemFactoryPatch
    {
        static bool Prefix(ref Golem ____golemPrefab, ObjectCollectionService ____objectCollectionService,FactionService ____factionService)
        {
            GolemFactionService specificationService = TimberAPI.DependencyContainer.GetInstance<GolemFactionService>();
            string golemFactionId = specificationService.GetGolemFactionIdByFactionId(____factionService.Current.Id);
            ____golemPrefab = ____objectCollectionService.GetAllMonoBehaviours<Golem>().Single(golem => golem.GetComponent<Prefab>().PrefabName.Contains(golemFactionId));
            return false;
        }
    }
}