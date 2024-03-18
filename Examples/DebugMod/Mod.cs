using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HarmonyLib;
using TimberApi.ConsoleSystem;
using TimberApi.DependencyContainerSystem;
using TimberApi.ModSystem;
using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using TimberApi.UiBuilderSystem.Presets.Buttons;
using Timberborn.AssetSystem;
using Timberborn.CoreUI;
using Timberborn.MainMenuScene;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using Color = UnityEngine.Color;
using Debug = UnityEngine.Debug;
using LocalizableButton = TimberApi.UiBuilderSystem.CustomElements.LocalizableButton;
using StyleSheetBuilder = UnityEngine.UIElements.StyleSheets.StyleSheetBuilder;

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
        public static int _counter = 0;
        public static long _totalTicks = 0;

        public static Stopwatch Stopwatch = new();
        
        // public static void Prefix(string elementName)
        // {
        //     Stopwatch.Restart();
        // }
        
        public static void Postfix(string elementName, VisualTreeAsset __result)
        {
            var resourceAssetLoader = DependencyContainer.GetInstance<IResourceAssetLoader>();
            Stopwatch.Restart();
            var tree = resourceAssetLoader.Load<VisualTreeAsset>(VisualElementLoader.ViewsDirectory + "/" + elementName);
            var element = tree.CloneTree().ElementAt(0);
            Stopwatch.Stop();
            var newElements = TotalElements(element);
            
            // Debug.LogError($"Element: {elementName}, took: {Stopwatch.ElapsedTicks}({Stopwatch.ElapsedTicks / 10_000}), element counter: {_counter} + {newElements}");
            Debug.LogError($"Time spend {Stopwatch.ElapsedTicks}({Stopwatch.ElapsedTicks / 10_000}ms), total time: {_totalTicks}({_totalTicks / 10_000}ms) +{Stopwatch.ElapsedTicks}");
            
            _counter += newElements;
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
        public static VisualTreeAsset
            LoadVisualTreeAsset(IResourceAssetLoader resourceAssetLoader, string elementName) =>
            resourceAssetLoader.Load<VisualTreeAsset>(VisualElementLoader.ViewsDirectory + "/" + elementName);

        public static VisualElement LoadVisualElement(VisualTreeAsset visualTreeAsset)
        {
            VisualElement visualElement = visualTreeAsset.CloneTree().ElementAt(0);
            return visualElement;
        }

        public static int counter = 1;

        public static void Postfix(ref VisualElement __result)
        {
            var resourceLoader = DependencyContainer.GetInstance<IResourceAssetLoader>();
            var elementLoader = DependencyContainer.GetInstance<VisualElementLoader>();
            var uiBuilder = DependencyContainer.GetInstance<UIBuilder>();
            var oldBuilder = DependencyContainer.GetInstance<UIBuilderOld>();

            var visualElementLoader = DependencyContainer.GetInstance<VisualElementLoader>();
            var resourceAssetLoader = DependencyContainer.GetInstance<IResourceAssetLoader>();

            var existingElement = new LocalizableButton();

            var test = resourceLoader.LoadAll<StyleSheet>(""); 
            
            var kek = new VisualElement();

            // var classNames = new List<(string, IEnumerable<string>)>();
            //
            // for (int i = 0; i < 860; i++)
            // {
            //     foreach (var pseudoClass in PseudoClassGenerator.GetAllPseudoClasses())
            //     {
            //         classNames.Add((
            //             $"image_{i}_{pseudoClass.Item1}",
            //             pseudoClass.Item2
            //         ));
            //     }
            // }

            var sw = Stopwatch.StartNew();


            for (int i = 0; i < 100_000; i++)
            {
                // new LocalizableButton();
                uiBuilder.Create<ArrowDown>().Build();
            }

            sw.Stop();

            Debug.LogWarning($"Preset builder execution time: {sw.ElapsedTicks}({sw.ElapsedTicks / 10_000}ms)");
            

            kek = uiBuilder.Create<VisualElementBuilder>()
                // .AddComponent(uiBuilder.Create<ArrowDown>().WithActive().Build())
                // .AddComponent(uiBuilder.Create<ArrowDown>().Inverted().Build())
                // .AddComponent(uiBuilder.Create<ArrowDown>().WithActive().Inverted().Build())
                .AddComponent(uiBuilder.Build(typeof(ArrowDown)))
                .AddComponent(uiBuilder.Build(typeof(ArrowDown)))
                .AddComponent(uiBuilder.Build(typeof(ArrowDown)))
                .AddComponent(uiBuilder.Build(typeof(ArrowDown)))
                .Build();
            
            uiBuilder.Initialize(kek);

            
            __result = kek;
        }

        public static string MAGIC = "I AM";

        public static Func<StyleSheet> Test()
        {
            return () =>
            {
                var styleSheet = ScriptableObject.CreateInstance<StyleSheet>();

                var builder = new StyleSheetBuilder();

builder.BeginRule(0);

    builder.BeginComplexSelector(31); // This number is important
        builder.AddSimpleSelector(new[]
        {
            new StyleSelectorPart { value = "MyFirstClass", type = StyleSelectorType.Class },
            new StyleSelectorPart { value = "MyFirstClass", type = StyleSelectorType.Class },
            new StyleSelectorPart { value = "hover", type = StyleSelectorType.PseudoClass },
            new StyleSelectorPart { value = "checked", type = StyleSelectorType.PseudoClass },
        }, StyleSelectorRelationship.Descendent);
    builder.EndComplexSelector();

    builder.BeginProperty("width");
        builder.AddValue(new Dimension(10, Dimension.Unit.Pixel));
    builder.EndProperty();
    
    builder.BeginProperty("height", 0);
        builder.AddValue(new Dimension(10, Dimension.Unit.Pixel));
    builder.EndProperty();
    
    builder.BeginProperty("padding-left", 0);
        builder.AddValue(new Dimension(10, Dimension.Unit.Pixel));
    builder.EndProperty();
    
    builder.BeginProperty("padding-right", 0);
        builder.AddValue(new Dimension(10, Dimension.Unit.Pixel));
    builder.EndProperty();

builder.EndRule();

                builder.BuildTo(styleSheet);

                MAGIC += " MAGIC";

                return styleSheet;
            };
        }
    }
}


// public class TestButtonBuilder : ButtonBuilder<TestButtonBuilder>
// {
//     protected override TestButtonBuilder BuilderInstance => this;
// }
//
// public abstract class TestButtonBuilder<TBuilder> : ButtonBuilder<TBuilder>
//     where TBuilder : ButtonBuilder<TBuilder>
// {
//     public TBuilder SetPriority()
//     {
//         return BuilderInstance;
//     }
//     
//     public override LocalizableButton Build()
//     {
//         return SetBackgroundColor(Color.green)
//             .SetPadding(10)
//             .Build();
//     }
// }

public class PseudoClassGenerator
{
    public static IEnumerable<(string, IEnumerable<string>)> GetAllPseudoClasses()
    {
        var pseudoClasses = new HashSet<string>
            { ":hover", ":active", ":inactive", ":focus", ":selected", ":disabled", ":enabled", ":checked" };
        var exclusions = new HashSet<string> { ":active:inactive", ":enabled:disabled" };

        foreach (var pseudoClass in pseudoClasses)
        {
            var items = new List<string>(pseudoClass.Split(':'));

            if (items[0] == "")
            {
                items.RemoveAt(0);
            }

            yield return (
                pseudoClass.Replace(":", "__"),
                items
            );
        }

        var combinationsOfTwo = new List<string>();
        foreach (var combination in pseudoClasses.Combinations(2))
        {
            var combined = string.Join("", combination);
            if (!exclusions.Contains(combined))
            {
                combinationsOfTwo.Add(combined);
            }
        }

        foreach (var pseudoClass in combinationsOfTwo)
        {
            var items = new List<string>(pseudoClass.Split(':'));

            if (items[0] == "")
            {
                items.RemoveAt(0);
            }

            yield return (
                pseudoClass.Replace(":", "__"),
                items
            );
        }
    }
}

// Extension method for generating combinations of two elements
public static class Extensions
{
    public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> items, int k)
    {
        return k == 0
            ? new[] { new T[0] }
            : items.SelectMany((item, i) =>
                items.Skip(i + 1).Combinations(k - 1).Select(result => (new[] { item }).Concat(result)));
    }
}