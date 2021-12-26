using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews;
using Timberborn.CoreUI;
using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel
{
    public class UIBuilderPreviewBox : IPanelController
    {
        public static Action OpenPreviewBoxDelegate;
        
        private readonly PanelStack _panelStack;

        private static ImmutableArray<IUIBuilderPreview> _previews;
        
        private readonly UIBuilder _uiBuilder;

        private VisualElement _previewBox;

        public UIBuilderPreviewBox(UIBuilder uiBuilder, PanelStack panelStack, IEnumerable<IUIBuilderPreview> previews)
        {
            _uiBuilder = uiBuilder;
            _panelStack = panelStack;
            _previews = previews.ToImmutableArray();
            OpenPreviewBoxDelegate = OpenPreviewBox;
        }

        private void OpenPreviewBox()
        { 
            _panelStack.HideAndPush(this);
        }

        public VisualElement GetPanel()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            
            UIBoxBuilder menu = _uiBuilder.CreateBoxBuilder()
                .SetHeight(new Length(650, Pixel))
                .SetWidth(new Length(300, Pixel))
                .ModifyBox(builder =>
                {
                    builder.SetMargin(new Margin(0,0,0,new Length(-300, Pixel)));
                    builder.SetStyle(style => style.position = Position.Absolute);
                });
            
            foreach (IUIBuilderPreview preview in _previews)
            {
                menu.AddPreset(factory => factory.Buttons().Button(text: preview.GetPreviewName(), name: preview.GetPreviewKey(), builder: builder => builder.SetWidth(new Length(100, Percent))));
            }
            
            UIBoxBuilder boxBuilder = _uiBuilder.CreateBoxBuilder()
                .SetHeight(new Length(650, Pixel))
                .SetWidth(new Length(850, Pixel))
                .ModifyWrapper(builder => builder.AddComponent(menu.Build()))
                .ModifyScrollView(builder => builder.SetName("elementPreview"));

            IUIBuilderPreview firstElement = _previews.FirstOrDefault();
            if(firstElement != null)
                boxBuilder.AddComponent(firstElement.GetPreview());
            
            VisualElement root = boxBuilder.AddCloseButton("CloseButton").SetBoxInCenter().AddHeader(text: "UI Previews").BuildAndInitialize();
            _previewBox = root.Q<VisualElement>("elementPreview");
            root.Q<Button>("CloseButton").clicked += OnUICancelled;
            
            foreach (IUIBuilderPreview uiBuilderPreview in _previews)
            {
                root.Q<Button>(uiBuilderPreview.GetPreviewKey()).clicked += delegate { SwitchPreview(uiBuilderPreview); };
            }

            watch.Stop();
            Console.WriteLine("Time elapsed (ms): {0}", watch.ElapsedMilliseconds);

            return root;
        }
        
        private void SwitchPreview(IUIBuilderPreview selectedPreview)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            _previewBox.Clear();
            _previewBox.Add(selectedPreview.GetPreview());
            watch.Stop();
            Console.WriteLine("Time elapsed (ms): {0}", watch.ElapsedMilliseconds);
        }

        public bool OnUIConfirmed()
        {
            return false;
        }

        public void OnUICancelled()
        {
            _panelStack.Pop(this);
        }
    }
}