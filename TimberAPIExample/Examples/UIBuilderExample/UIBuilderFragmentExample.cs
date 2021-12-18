using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using TimberbornAPI;
using TimberbornAPI.Common;
using TimberbornAPI.Internal;
using TimberbornAPI.UIBuilderSystem;
using TimberbornAPI.UIBuilderSystem.delete;
using UnityEngine;
using UnityEngine.UIElements;
using Image = TimberbornAPI.UIBuilderSystem.Image;

namespace TimberAPIExample.Examples.UIBuilderExample
{
    public class UIBuilderFragmentExample : IEntityPanelFragment
    {
        private readonly VisualElementLoader _visualElementLoader;

        private readonly IElementFactory _elementFactory;
        
        private readonly IUIBuilder _builder;

        private VisualElement _root;
        
        public static Dictionary<string, string> GetFieldValues(object obj)
        {
            return obj.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(string))
                .ToDictionary(f => f.Name,
                    f => (string) f.GetValue(null));
        }

        public UIBuilderFragmentExample(IUIBuilder builder, VisualElementLoader visualElementLoader, IElementFactory elementFactory)
        {
            _builder = builder;
            _visualElementLoader = visualElementLoader;
            _elementFactory = elementFactory;
        }
        
        [SuppressMessage("", "Publicizer001")]
        public VisualElement InitializeFragment()
        {
            UIFragmentBuilder builder = _builder.CreateFragmentBuilder()
                .SetBackground(Image.Background.SubBoxBlue)
                .AddComponents(componentBuilder => componentBuilder
                    .AddWrapper(builder => builder
                            .AddButton("timber-api-sound-click", Image.Button.SquareGreen, 200, padding: new Padding(10))
                            .AddButton("timber-api-sound-cancel", Image.Button.SquareGreen, 200, padding: new Padding(10))
                            .AddButton("timber-api-test-button__button--red ", Array.Empty<string>(), 200, padding: new Padding(10))
                            .AddButton("timber-api-test-button__button", Array.Empty<string>(), 200, padding: new Padding(10))
                            .AddButton("timber-api-test-button", Array.Empty<string>(), 200, padding: new Padding(10))
                            .AddButton("timber-api-test-button-pog", Array.Empty<string>(), 200, padding: new Padding(10))
                        , FlexDirection.Column)
                    // .AddLabel("POGGERS")
                    // .AddButton("X", Image.Button.CircleSmallGreen, 50, 50)
                    // .AddButton("X", Image.Button.CircleSmallRed, 50, 50)
                    // .AddButton("BONK", Image.Button.SquareRed, 120, padding: new Padding(10))
                );
            
            _root = builder.Build();


            // // Create a root visual element that is used as fragment
            // _root = _builder.CreateComponentBuilder()
            //     .AddWrapper(builder => builder // Adds a wrapper to group components
            //         .AddButton("First Button", name: "firstButton", width: new Length(120, Length.Unit.Pixel)) // Adds a button to the wrapper
            //         .AddButton("Another one", name: "secondButton", width: new Length(120, Length.Unit.Pixel)), // Adds a button to the wrapper
            //         justifyContent: Justify.SpaceAround) // Positions the buttons around the wrapper (maximum spaced between)
            //     .Build(); // Creates the visual element
            //
            // // Creating on click events for the buttons, using the name that is used with creating the button.
            // _root.Q<Button>("firstButton").clicked += OnFirstButtonClick; // name: firstButton
            // _root.Q<Button>("secondButton").clicked += OnSecondButtonClick; // name: secondButton

            return _root;
        }

        public void ShowFragment(GameObject entity) { }

        public void ClearFragment()
        {
            // Disable fragment when building is deselected.
            _root.ToggleDisplayStyle(false);
        }

        public void UpdateFragment()
        {
            // Enable fragment when selected.
            _root.ToggleDisplayStyle(true);
        }

        private void OnFirstButtonClick()
        {
            // Do some action when button is clicked
            TimberAPIExamplePlugin.Log.LogFatal("Clicked on first button");
        }

        private void OnSecondButtonClick()
        {
            // Do some action when button is clicked
            TimberAPIExamplePlugin.Log.LogFatal("Clicked on second button");
        }
    }
}