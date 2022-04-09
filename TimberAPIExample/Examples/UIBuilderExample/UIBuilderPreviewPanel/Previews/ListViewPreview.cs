using System.Collections.Generic;
using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;
using static TimberAPIExample.TimberAPIExamplePlugin;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews
{
    public class ListViewPreview : IUIBuilderPreview
    {
        /// <summary>
        /// Example custom object to use in lists
        /// </summary>
        private class CustomSourceExample
        {
            public CustomSourceExample(string text, StyleColor color)
            {
                Text = text;
                Color = color;
            }

            public string Text { get; set; }

            public StyleColor Color { get; set; }
        }
        
        private readonly UIBuilder _uiBuilder;
        
        /// <summary>
        /// Example item list with custom object
        /// </summary>
        private static readonly List<CustomSourceExample> _list = new ()
        {
            new CustomSourceExample("Example Item 1", UnityEngine.Color.blue), 
            new CustomSourceExample("Example Item 2", UnityEngine.Color.cyan), 
            new CustomSourceExample("Example Item 3", UnityEngine.Color.gray),
            new CustomSourceExample("Example Item 4", UnityEngine.Color.green),
            new CustomSourceExample("Example Item 5", UnityEngine.Color.magenta),
            new CustomSourceExample("Example Item 6", UnityEngine.Color.white),
            new CustomSourceExample("Example Item 7", UnityEngine.Color.yellow),
            new CustomSourceExample("Example Item 8", UnityEngine.Color.red),
        };

        public ListViewPreview(UIBuilder uiBuilder)
        {
            _uiBuilder = uiBuilder;
        }

        public string GetPreviewKey()
        {
            return "listviews";
        }

        public string GetPreviewName()
        {
            return "Listviews";
        }
        
        public VisualElement GetPreview()
        {
            VisualElementBuilder root = _uiBuilder.CreateComponentBuilder().CreateVisualElement();
            root.AddPreset(factory => factory.Labels().DefaultHeader("preview.listview.main", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddPreset(factory => factory.ListViews().MainMenuListView(
                _list, // The list of items
                BindItemExample, // Change the visualElement with item specific details (example: text)
                ExampleOnSelectionChange, // Trigger when selection has changed
                height: new Length(200, Pixel)));
      
            root.AddPreset(factory => factory.Labels().DefaultHeader("preview.listview.multi", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddPreset(factory => factory.ListViews().MainMenuListView(_list, BindItemExample, ExampleOnSelectionChange, SelectionType.Multiple, height: new Length(200, Pixel)));

            root.AddPreset(factory => factory.Labels().DefaultHeader("preview.listview.color", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder => builder.SetFlexDirection(FlexDirection.Row).SetJustifyContent(Justify.SpaceBetween)
                    .AddPreset(factory => factory.ListViews().ColorListView(
                        _list,  // The list of items
                        ItemExampleElement, // Visual element that will represent all items
                        BindItemExample,    // Change the visualElement with item specific details (example: text)
                        ExampleOnSelectionChange,   // Trigger when selection has changed
                        new Color(0.44f, 0.12f, 0.13f),
                        new Color(0.79f, 0.19f, 0.14f),
                        height: new Length(200, Pixel)))
                    .AddPreset(factory => factory.ListViews().ColorListView(_list,
                        ItemExampleElement,
                        BindItemExample,
                        ExampleOnSelectionChange,
                        new Color(0.18f, 0.19f, 1f),
                        new Color(0.24f, 0.39f, 1f),
                        height: new Length(200, Pixel)))
                    .AddPreset(factory => factory.ListViews().ColorListView(_list,
                        ItemExampleElement,
                        BindItemExample,
                        ExampleOnSelectionChange,
                        new Color(0.35f, 0.67f, 0.37f),
                        new Color(0.47f, 0.88f, 0.37f),
                        height: new Length(200, Pixel)))
                .Build());
            
            root.AddPreset(factory => factory.Labels().DefaultHeader("preview.listview.custom", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddPreset(factory => factory.ListViews().CustomListView(_list,
                ItemExampleElement,
                BindItemExample,
                ExampleOnSelectionChange,
                scrollbarElement =>
                {
                    scrollbarElement.AddToClassList(TimberApiStyle.Backgrounds.ScrollBar);
                },
                dragElement =>
                {
                    dragElement.style.marginLeft = new Length(-5, Pixel);
                    dragElement.AddToClassList(TimberApiStyle.Buttons.Normal.CircleOff);
                    dragElement.AddToClassList(TimberApiStyle.Buttons.Hover.CircleOnHover);
                    dragElement.style.minHeight = new Length(26, Pixel);
                    dragElement.style.maxHeight = new Length(26, Pixel);
                    dragElement.style.width = new Length(26, Pixel);
                },
                height: new Length(200, Pixel)));
            
            return root.Build();
        }
        
        private void BindItemExample(VisualElement visualElement, int i)
        {
            CustomSourceExample item = _list[i];
            visualElement.Q<Label>("ItemLabel").text = item.Text;
            visualElement.Q<Label>("ItemLabel").style.color = item.Color;
        }
        
        private void ExampleOnSelectionChange(IEnumerable<object> selectedItemObjects)
        {
            foreach (object itemObject in selectedItemObjects)
            {
                if (itemObject is not CustomSourceExample item) 
                    return;
            
                Log.LogFatal(item.Text);
            }

        }
        
        private VisualElement ItemExampleElement()
        {
            VisualElement item = _uiBuilder.CreateComponentBuilder().CreateVisualElement()
                .AddClass(TimberApiStyle.ListViews.Hover.BgPixel3Hover)
                .AddClass(TimberApiStyle.ListViews.Selected.BgPixel3Selected)
                .SetJustifyContent(Justify.Center)
                .SetAlignItems(Align.Center)
                .SetMargin(new Margin(10, 0))
                .AddPreset(factory => factory.Labels().DefaultText(name: "ItemLabel"))
                .Build();
            return item;
        }
    }
}