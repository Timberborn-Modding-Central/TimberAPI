using HarmonyLib;

namespace TimberApi.HarmonyPatcherSystem
{
    public interface IHarmonyPatcher
    {
        public string UniqueId { get; }

        public void Apply(Harmony harmony);
    }
}