using System.Diagnostics.CodeAnalysis;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using TimberbornAPI.UIBuilderSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberAPIExample.Examples.UIBuilderExample
{
    public class UIBuilderFragmentExample : IEntityPanelFragment
    {
        private readonly IUIBuilder _builder;

        private VisualElement _root;

        public UIBuilderFragmentExample(IUIBuilder builder)
        {
            _builder = builder;
        }
        
        [SuppressMessage("", "Publicizer001")]
        public VisualElement InitializeFragment()
        {
            // Create a root visual element that is used as fragment
            _root = _builder.CreateComponentBuilder()
                .AddWrapper(builder => builder // Adds a wrapper to group components
                    .AddButton("First Button", name: "firstButton", width: new Length(120, Length.Unit.Pixel)) // Adds a button to the wrapper
                    .AddButton("Another one", name: "secondButton", width: new Length(120, Length.Unit.Pixel)), // Adds a button to the wrapper
                    justifyContent: Justify.SpaceAround) // Positions the buttons around the wrapper (maximum spaced between)
                .Build(); // Creates the visual element

            // Creating on click events for the buttons, using the name that is used with creating the button.
            _root.Q<Button>("firstButton").clicked += OnFirstButtonClick; // name: firstButton
            _root.Q<Button>("secondButton").clicked += OnSecondButtonClick; // name: secondButton

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