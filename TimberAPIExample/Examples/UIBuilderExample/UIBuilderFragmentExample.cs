using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberAPIExample.Examples.UIBuilderExample
{
    public class UIBuilderFragmentExample : IEntityPanelFragment
    {
        private readonly UIBuilder _builder;

        private VisualElement _root;

        public UIBuilderFragmentExample(UIBuilder builder)
        {
            _builder = builder;
        }

        public VisualElement InitializeFragment()
        {
            // Create a root visual element that is used as fragment
            _root = _builder.CreateComponentBuilder().CreateVisualElement()
                // Create a fragment with the default background and scaling.
                .AddComponent(_builder.CreateFragmentBuilder()
                    .AddPreset(factory => factory.Toggles().CheckmarkInverted( "firstButton", locKey: "fragment.example.button1", builder: builder => builder.SetMargin(new Margin(0,0,new Length(3, Pixel),0))))
                    .AddPreset(factory => factory.Toggles().CheckmarkInverted( "firstButton", locKey: "fragment.example.button2"))
                    .Build())
                // Create a fragment with the default scaling and other background.
                .AddComponent(_builder.CreateFragmentBuilder()
                    .SetBackground(TimberApiStyle.Backgrounds.Bg1)
                    .AddPreset(factory => factory.Toggles().CheckmarkInverted( locKey: "fragment.example.button1", builder: builder => builder.SetMargin(new Margin(0,0,new Length(3, Pixel),0))))
                    .AddPreset(factory => factory.Toggles().CheckmarkInverted( locKey: "fragment.example.button2"))
                    .Build())
                // Create a fragment with the different background and scaling
                .AddComponent(_builder.CreateFragmentBuilder()
                    .SetBackground(TimberApiStyle.Backgrounds.Bg7)
                    .SetScale(TimberApiStyle.Scales.Scale7)
                    .AddPreset(factory => factory.Toggles().CheckmarkInverted( locKey: "fragment.example.button1", builder: builder => builder.SetMargin(new Margin(0,0,new Length(3, Pixel),0))))
                    .AddPreset(factory => factory.Toggles().CheckmarkInverted( locKey: "fragment.example.button2"))
                    .Build())
                // Builds the element and initializes them, adding sounds effects etc.
                .BuildAndInitialize();
            
            // This is enough for one fragment, the example previews 3 fragments in one.
            // _root = _builder.CreateFragmentBuilder()
            //     .AddPreset(factory => factory.Toggles().Checkmark( "firstButton", locKey: "fragment.example.button1"))
            //     .AddPreset(factory => factory.Toggles().Checkmark( "firstButton", locKey: "fragment.example.button2"))
            //     .BuildAndInitialize();

            // Creating on click events for the buttons, using the name that is used with creating the button.
            // _root.Q<Button>("firstButton").clicked += OnFirstButtonClick; // name: firstButton
            // _root.Q<Button>("secondButton").clicked += OnSecondButtonClick; // name: secondButton

            return _root;
        }

        public void ShowFragment(GameObject entity)
        {
            
        }

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