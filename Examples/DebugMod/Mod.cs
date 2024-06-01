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


            var test = uiBuilder.Build<ButtonMenu>();
            test.SetEnabled(false);
            
            
            __result = uiBuilder.Create<ScrollViewBuilder>()
                .AddComponent<VisualElementBuilder>(builder =>
                {
                    return builder
                        .SetStyle(style =>
                        {
                            style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row);
                            style.flexWrap = new StyleEnum<Wrap>(Wrap.Wrap);
                            style.paddingLeft = 100;
                            style.paddingTop = 100;
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
                        
                        .AddComponent<ArrowUp>()
                        .AddComponent<ArrowUp>(arrow => arrow.Inverted())
                        .AddComponent<ArrowUp>(arrow => arrow.Active())
                        .AddComponent<ArrowUp>(arrow => arrow.Small())
                        .AddComponent<ArrowUp>(arrow => arrow.Large())
                        .AddComponent<ArrowUp>(arrow => arrow.SetSize(30))
                        
                        .AddComponent<ArrowRight>()
                        .AddComponent<ArrowRight>(arrow => arrow.Inverted())
                        .AddComponent<ArrowRight>(arrow => arrow.Active())
                        .AddComponent<ArrowRight>(arrow => arrow.Small())
                        .AddComponent<ArrowRight>(arrow => arrow.Large())
                        .AddComponent<ArrowRight>(arrow => arrow.SetSize(30))
                        
                        .AddComponent<ButtonMenu>(button => button.SetLocKey("Hello World"))
                        .AddComponent<ButtonMenu>(button => button.SetLocKey("Hello World").Medium())
                        .AddComponent<ButtonMenu>(button => button.SetLocKey("Hello World").SetWidth(500))
                        
                        
                        .AddComponent<ButtonGame>(button => button.SetLocKey("Hello World").SetWidth(200).SetHeight(100))
                        .AddComponent<ButtonGame>(button => button.SetLocKey("Hello World").SetWidth(200).SetHeight(100).District())
                        .AddComponent<ButtonGame>(button => button.SetLocKey("Hello World").SetWidth(200).SetHeight(100).Destructive())
                        .AddComponent<ButtonGame>(button => button.SetLocKey("Hello World").SetWidth(200).SetHeight(100).Highlight())
                        .AddComponent<ButtonGame>(button => button.SetLocKey("Hello World").SetWidth(200).SetHeight(100).Active())
                        
                        .AddComponent<ButtonEmpty>(button => button.SetWidth(100).SetHeight(100))
                        .AddComponent<ButtonEmpty>(button => button.SetWidth(100).SetHeight(100).Red())
                        .AddComponent<ButtonEmpty>(button => button.SetWidth(100).SetHeight(100).Inverted())
                        .AddComponent<ButtonEmpty>(button => button.SetWidth(100).SetHeight(100).Batch())
                        .AddComponent<ButtonEmpty>(button => button.SetWidth(100).SetHeight(100).Active())
                        
                        .AddComponent<ButtonEmptyText>(button => button.SetLocKey("Hello World").SetWidth(100).SetHeight(100))
                        .AddComponent<ButtonEmptyText>(button => button.SetLocKey("Hello World").SetWidth(100).SetHeight(100).Red())
                        .AddComponent<ButtonEmptyText>(button => button.SetLocKey("Hello World").SetWidth(100).SetHeight(100).Inverted())
                        .AddComponent<ButtonEmptyText>(button => button.SetLocKey("Hello World").SetWidth(100).SetHeight(100).Batch())
                        .AddComponent<ButtonEmptyText>(button => button.SetLocKey("Hello World").SetWidth(100).SetHeight(100).Active())
                        
                        .AddComponent<ButtonNewGame>(button => button.SetLocKey("Hello World"))
                        .AddComponent<ButtonNewGame>(button => button.SetLocKey("Hello World").Active())
                        
                        .AddComponent<ButtonNewGame>(button => button.SetLocKey("Hello World").Normal())
                        .AddComponent<ButtonNewGame>(button => button.SetLocKey("Hello World").Normal().Active())
                        
                        .AddComponent<ClampUp>(button => button)
                        .AddComponent<ClampUp>(button => button.Active())
                        
                        .AddComponent<ClampDown>(button => button)
                        .AddComponent<ClampDown>(button => button.Active())
                        
                        .AddComponent<PlusButton>(button => button)
                        .AddComponent<PlusButton>(button => button.Active())
                        .AddComponent<PlusButton>(button => button.Inverted())
                        .AddComponent<PlusButton>(button => button.Small())
                        .AddComponent<PlusButton>(button => button.Large())
                        
                        .AddComponent<PlusBatchButton>(button => button)
                        .AddComponent<PlusBatchButton>(button => button.Small())
                        .AddComponent<PlusBatchButton>(button => button.Large())
                        
                        .AddComponent<PlusBatchMultiButton>(button => button)
                        .AddComponent<PlusBatchMultiButton>(button => button.Small())
                        .AddComponent<PlusBatchMultiButton>(button => button.Large())
                        
                        .AddComponent<MinusButton>(button => button)
                        .AddComponent<MinusButton>(button => button.Active())
                        .AddComponent<MinusButton>(button => button.Inverted())
                        .AddComponent<MinusButton>(button => button.Small())
                        .AddComponent<MinusButton>(button => button.Large())
                        
                        .AddComponent<MinusBatchButton>(button => button)
                        .AddComponent<MinusBatchButton>(button => button.Small())
                        .AddComponent<MinusBatchButton>(button => button.Large())
                        
                        .AddComponent<MinusBatchMultiButton>(button => button)
                        .AddComponent<MinusBatchMultiButton>(button => button.Small())
                        .AddComponent<MinusBatchMultiButton>(button => button.Large())
                        
                        .AddComponent<CircleButton>(button => button)
                        .AddComponent<CircleButton>(button => button.Active())
                        .AddComponent<CircleButton>(button => button.Small())
                        .AddComponent<CircleButton>(button => button.Large())
                        
                        .AddComponent<CloseButton>(button => button)
                        
                        .AddComponent<CrossButton>(button => button)
                        .AddComponent<CrossButton>(button => button.Active())
                        .AddComponent<CrossButton>(button => button.Inverted())
                        .AddComponent<CrossButton>(button => button.Small())
                        .AddComponent<CrossButton>(button => button.Large())
                        
                        .AddComponent<WideButton>(button => button.SetLocKey("Hello World"))
                        .AddComponent<WideButton>(button => button.SetLocKey("Hello World").Active())
                        
                        
                        .AddComponent<MigrationArrowLeftButton>(button => button)
                        .AddComponent<MigrationArrowRightButton>(button => button)
                        
                        .AddComponent<CyclerRight>(button => button)
                        .AddComponent<CyclerLeft>(button => button)
                        
                        .AddComponent<CyclerMainRight>(button => button.Small())
                        .AddComponent<CyclerMainRight>(button => button)
                        .AddComponent<CyclerMainRight>(button => button.Large())
                        
                        .AddComponent<CyclerMainLeft>(button => button.Small())
                        .AddComponent<CyclerMainLeft>(button => button)
                        .AddComponent<CyclerMainLeft>(button => button.Large())
                        
                        ;
                })
                .BuildAndInitialize();
        }
    }
}
