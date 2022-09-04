using System;
using System.Collections;
using System.Collections.Generic;
using TimberApi.Internal.UiBuilderSystem.ElementSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
#pragma warning disable CS8625

namespace TimberApi.Internal.UiBuilderSystem.PresetSystem
{
    public class ListViewPresetFactory
    {
        private readonly ComponentBuilder _componentBuilder;
        
        public ListViewPresetFactory(ComponentBuilder componentBuilder)
        {
            _componentBuilder = componentBuilder;
        }
        

        /// <summary>
        /// Item text label name: ItemLabel
        /// </summary>
        public ListView MainMenuListView(IList itemSource = default, Action<VisualElement, int> bindItem = default, Action<IEnumerable<object>> selectionChange = default, SelectionType selectionType = SelectionType.Single, Length width = default, Length height = default, string name = default, Action<ListViewBuilder> builder = default)
        {
            return CustomListView(
                itemSource,
                () => _componentBuilder.CreateVisualElement()
                    .SetJustifyContent(Justify.Center)
                    .SetAlignItems(Align.Center)
                    .AddClass(TimberApiStyle.ListViews.Hover.ScrollTabHover)
                    .AddClass(TimberApiStyle.ListViews.Selected.ScrollTabSelected)
                    .AddPreset(factory => factory.Labels().DefaultText(name: "ItemLabel"))
                    .Build(),
                bindItem,
                selectionChange,
                scrollbarElement =>
                {
                    scrollbarElement.AddToClassList(TimberApiStyle.Backgrounds.ScrollBar);
                },
                dragElement =>
                {
                    dragElement.AddToClassList(TimberApiStyle.Backgrounds.ScrollButton);
                    dragElement.style.minHeight = new Length(60, Pixel);
                    dragElement.style.maxHeight = new Length(60, Pixel);
                }, selectionType, width, height, name, builder);
        }

        public ListView ColorListView(IList itemSource = default, Func<VisualElement> makeItem = default, Action<VisualElement, int> bindItem = default, Action<IEnumerable<object>> selectionChange = default, StyleColor scrollbarColor = default, StyleColor dragButtonColor = default, SelectionType selectionType = SelectionType.Single, Length width = default, Length height = default, string name = default, Action<ListViewBuilder> builder = default)
        {
            return CustomListView(itemSource, makeItem, bindItem, selectionChange,
                scrollbarElement =>
                {
                    scrollbarElement.style.backgroundColor = scrollbarColor == default ? Color.gray : scrollbarColor;
                },
                dragElement =>
                {
                    dragElement.style.backgroundColor = dragButtonColor == default ? Color.black : dragButtonColor;
                    dragElement.style.minHeight = new Length(60, Pixel);
                    dragElement.style.maxHeight = new Length(60, Pixel);
                }, selectionType, width, height, name, builder);
        }
        
        public ListView CustomListView(IList itemSource = default, Func<VisualElement> makeItem = default, Action<VisualElement, int> bindItem = default, Action<IEnumerable<object>> selectionChange = default, Action<Slider> scrollbarElement = default, Action<VisualElement> dragElement = default, SelectionType selectionType = SelectionType.Single, Length width = default, Length height = default, string name = default, Action<ListViewBuilder> builder = default)
        {
            ListViewBuilder listViewBuilder = _componentBuilder.CreateListView()
                .SetName(name)
                .ModifyVerticalScroller(scroller =>
                {
                    scrollbarElement?.Invoke(scroller.slider);
                    dragElement?.Invoke(scroller.slider?.dragElement!);
                });
            
            if(selectionType != default)
                listViewBuilder.SetSelectionType(selectionType);

            if(selectionChange != default)
                listViewBuilder.SetSelectionChange(selectionChange);
            
            if(bindItem != default)
                listViewBuilder.SetBindItem(bindItem);
            
            if(makeItem != default)
                listViewBuilder.SetMakeItem(makeItem);
            
            if(itemSource != default)
                listViewBuilder.SetItemSource(itemSource);
            
            if(width != default)
                listViewBuilder.SetWidth(width);
            
            if(height != default)
                listViewBuilder.SetHeight(height);
                
            builder?.Invoke(listViewBuilder);
            return listViewBuilder.Build();
        }
    }
}