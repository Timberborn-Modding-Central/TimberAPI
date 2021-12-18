using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews;
using Timberborn.AssetSystem;
using Timberborn.CoreUI;
using TimberbornAPI.Internal;
using TimberbornAPI.UIBuilderSystem;
using TimberbornAPI.UIBuilderSystem.delete;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel
{
    public class UIBuilderPreviewBox : IPanelController
    {
        public static Action OpenPreviewBoxDelegate;
        
        private readonly PanelStack _panelStack;

        private static ImmutableArray<IUIBuilderPreview> _previews;


        private readonly IUIBuilder _uiBuilder;

        public UIBuilderPreviewBox(IUIBuilder uiBuilder, PanelStack panelStack, IEnumerable<IUIBuilderPreview> previews)
        {
            _uiBuilder = uiBuilder;
            _panelStack = panelStack;
            _previews = previews.ToImmutableArray();
            OpenPreviewBoxDelegate = OpenPreviewBox;
        }

        private void OpenPreviewBox()
        { 
            // _panelStack.HideAndPush(this);

            Sprite[] sprites = _resourceAssetLoader.LoadAll<Sprite>("ui");
            

            TimberAPIPlugin.Log.LogFatal(sprites?.Length);
            


            // string styling = $"Timberborn image slices: \r\n";
            // foreach (KeyValuePair<string, ImageSlice> keyValuePair in NineSlicedBackgroundPatch.ImageSlices)
            // {
            //     ImageSlice imageSlice = keyValuePair.Value;
            //     if (imageSlice.SliceBottom == imageSlice.SliceLeft && imageSlice.SliceLeft == imageSlice.SliceRight &&
            //         imageSlice.SliceRight == imageSlice.SliceTop)
            //     {
            //         styling += $".{imageSlice.Image.name} {{\r\n" +
            //                    $"   --background-image: resource('{imageSlice.ImagePath}');\r\n" +
            //                    $"   --background-slice: {imageSlice.SliceBottom};\r\n" +
            //                    $"   --background-slice-scale: {imageSlice.SliceScale};\r\n" +
            //                    // $"   --background-tint: {imageSlice.Tint}\r\n" +
            //                    $"}}\r\n";
            //     }
            //     else
            //     {
            //         styling += $".{imageSlice.Image.name} {{\r\n" +
            //                    $"   --background-image: resource('{imageSlice.ImagePath}');\r\n" +
            //                    $"   --background-slice-top: {imageSlice.SliceTop};\r\n" +
            //                    $"   --background-slice-right: {imageSlice.SliceRight};\r\n" +
            //                    $"   --background-slice-bottom: {imageSlice.SliceBottom};\r\n" +
            //                    $"   --background-slice-left: {imageSlice.SliceLeft};\r\n" +
            //                    $"   --background-slice-scale: {imageSlice.SliceScale};\r\n" +
            //                    // $"   --background-tint: {imageSlice.Tint}\r\n" +
            //                    $"}}\r\n";
            //     }
            // }
            // TimberAPIPlugin.Log.LogFatal(styling);
        }

        public VisualElement GetPanel()
        {
            IUIBoxBuilder boxBuilder = _uiBuilder.CreateBoxBuilder()
                .SetHeight(new Length(650, Pixel))
                .SetWidth(new Length(850, Pixel));

            foreach (IUIBuilderPreview preview in _previews)
            {
                boxBuilder.AddComponents(builder => builder.AddSectionHeader(preview.GetPreviewName()).AddCustomComponent(preview.GetPreview()));
            }

            VisualElement root = boxBuilder.Build();
            // root.Q<Button>("CloseButton").clicked += OnUICancelled;

            return root;
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