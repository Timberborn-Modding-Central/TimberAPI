using HarmonyLib;
using TimberApi.HarmonyPatcherSystem;
using TimberApi.SceneSystem;
using Timberborn.TutorialSystem;
using Timberborn.TutorialSystemInitialization;

namespace TimberApi.BottomBarSystem.Patchers
{
    public class BottomBarConfiguratorPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberApi.BottomBarConfigurator";

        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<Timberborn.BottomBarSystem.BottomBarSystemConfigurator>(
                    nameof(Timberborn.BottomBarSystem.BottomBarSystemConfigurator.Configure)),
                GetHarmonyMethod(nameof(ConfiguratorPatch))
            );
            
            harmony.Patch(
                GetMethodInfo<TutorialConfigurationProvider>(nameof(TutorialConfigurationProvider.CreateFolktailsConfiguration)),
                GetHarmonyMethod(nameof(CreateFolktailsConfigurationPatch))
            );
        }

        public override bool ShouldApply(SceneEntrypoint? sceneEntrypoint)
        {
            return sceneEntrypoint == SceneEntrypoint.InGame;
        }

        public static bool ConfiguratorPatch()
        {
            return TimberApiSceneManager.CurrentScene != SceneEntrypoint.InGame;
        }
        
        public static bool CreateFolktailsConfigurationPatch(ref TutorialConfiguration __result)
        {
            __result = TutorialConfiguration.CreateEmpty();

            return false;
        }
    }
}