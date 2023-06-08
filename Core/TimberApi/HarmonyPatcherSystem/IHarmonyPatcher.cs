using HarmonyLib;
using TimberApi.SceneSystem;

namespace TimberApi.HarmonyPatcherSystem
{
    public interface IHarmonyPatcher
    {
        public string UniqueId { get; }

        public void Apply(Harmony harmony);

        public bool ShouldApply(SceneEntrypoint? sceneEntrypoint);
    }
}