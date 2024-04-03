using System;
using System.Diagnostics;
using HarmonyLib;
using TimberApi.ConsoleSystem;
using TimberApi.DependencyContainerSystem;
using TimberApi.ModSystem;
using TimberApi.UiBuilderSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using TimberApi.UiBuilderSystem.Presets.Buttons;
using Timberborn.AssetSystem;
using Timberborn.CoreUI;
using Timberborn.MainMenuScene;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

namespace DebugMod
{
    public class Mod : IModEntrypoint
    {
        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            try
            {
                new Harmony("DebugMod").PatchAll();
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                throw;
            }
        }
    }

    [HarmonyPatch(typeof(VisualElementLoader), nameof(VisualElementLoader.LoadVisualTreeAsset), typeof(string))]
    public static class MyPatcher
    {
        public static int Counter = 0;
        public static long _totalTicks = 0;

        public static Stopwatch Stopwatch = new();

        public static void Postfix(string elementName, VisualTreeAsset __result)
        {
            var resourceAssetLoader = DependencyContainer.GetInstance<IResourceAssetLoader>();
            Stopwatch.Restart();
            var tree = resourceAssetLoader.Load<VisualTreeAsset>(VisualElementLoader.ViewsDirectory + "/" +
                                                                 elementName);
            var element = tree.CloneTree().ElementAt(0);
            Stopwatch.Stop();
            var newElements = TotalElements(element);

            // Debug.LogError($"Element: {elementName}, took: {Stopwatch.ElapsedTicks}({Stopwatch.ElapsedTicks / 10_000}), element counter: {_counter} + {newElements}");
            Debug.LogError(
                $"Time spend {Stopwatch.ElapsedTicks}({Stopwatch.ElapsedTicks / 10_000}ms), total time: {_totalTicks}({_totalTicks / 10_000}ms) +{Stopwatch.ElapsedTicks}");

            Counter += newElements;
            _totalTicks += Stopwatch.ElapsedTicks;
        }

        public static int TotalElements(VisualElement visualElement, int counter = 0)
        {
            foreach (var element in visualElement.Children())
            {
                counter += TotalElements(element);
            }

            return counter + visualElement.childCount;
        }
    }

    [HarmonyPatch(typeof(WelcomeScreenBox), nameof(WelcomeScreenBox.GetPanel))]
    public static class DebugPatcher
    {
        public static void Postfix(ref VisualElement __result)
        {
            var uiBuilder = DependencyContainer.GetInstance<UIBuilder>();

            var sw = Stopwatch.StartNew();

            // for (int i = 0; i < 100_000; i++)
            // {
            //     uiBuilder.Create<ArrowDown>().Build();
            // }

            sw.Stop();

            Debug.LogWarning($"Preset builder execution time: {sw.ElapsedTicks}({sw.ElapsedTicks / 10_000}ms)");


            __result = uiBuilder.Create<ScrollViewBuilder>()
                .AddComponent<VisualElementBuilder>(builder =>
                {
                    return builder
                        .SetStyle(style =>
                        {
                            style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row);
                            style.flexWrap = new StyleEnum<Wrap>(Wrap.Wrap);
                            style.paddingLeft = 100;
                            style.paddingRight = 100;
                            
                        })
                        .AddComponent<ArrowDown>("MyArrowDownButton")
                        .AddComponent<ArrowDown>(arrow => arrow.Inverted())
                        .AddComponent<ArrowDown>(arrow => arrow.Active())
                        .AddComponent<ArrowDown>(arrow => arrow.Small())
                        .AddComponent<ArrowDown>(arrow => arrow.Large())
                        .AddComponent<ArrowDown>(arrow => arrow.SetSize(30))
                        
                        .AddComponent<ArrowLeft>()
                        .AddComponent<ArrowLeft>(arrow => arrow.Inverted())
                        .AddComponent<ArrowLeft>(arrow => arrow.Active())
                        .AddComponent<ArrowLeft>(arrow => arrow.Small())
                        .AddComponent<ArrowLeft>(arrow => arrow.Large())
                        .AddComponent<ArrowLeft>(arrow => arrow.SetSize(30))
                        ;
                })
                .BuildAndInitialize();
        }
    }
}
