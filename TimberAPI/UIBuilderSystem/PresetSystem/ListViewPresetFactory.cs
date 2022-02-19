using System;
using System.Collections;
using System.Collections.Generic;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberbornAPI.UIBuilderSystem.PresetSystem
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
        public ListView MainMenuListView(IList itemSource, Action<VisualElement, int> bindItem, Action<IEnumerable<object>> selectionChange, SelectionType selectionType = SelectionType.Single, Length width = default, Length height = default, string name = default, Action<ListViewBuilder> builder = default)
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

        public ListView ColorListView(IList itemSource, Func<VisualElement> makeItem, Action<VisualElement, int> bindItem, Action<IEnumerable<object>> selectionChange, StyleColor scrollbarColor, StyleColor dragButtonColor, SelectionType selectionType = SelectionType.Single, Length width = default, Length height = default, string name = default, Action<ListViewBuilder> builder = default)
        {
            return CustomListView(itemSource, makeItem, bindItem, selectionChange,
                scrollbarElement =>
                {
                    scrollbarElement.style.backgroundColor = scrollbarColor;
                },
                dragElement =>
                {
                    dragElement.style.backgroundColor = dragButtonColor;
                    dragElement.style.minHeight = new Length(60, Pixel);
                    dragElement.style.maxHeight = new Length(60, Pixel);
                }, selectionType, width, height, name, builder);
        }
        
        public ListView CustomListView(IList itemSource, Func<VisualElement> makeItem, Action<VisualElement, int> bindItem, Action<IEnumerable<object>> selectionChange, Action<Slider> scrollbarElement, Action<VisualElement> dragElement, SelectionType selectionType = SelectionType.Single, Length width = default, Length height = default, string name = default, Action<ListViewBuilder> builder = default)
        {
            ListViewBuilder listViewBuilder = _componentBuilder.CreateListView()
                .SetName(name)
                .SetItemSource(itemSource)
                .SetMakeItem(makeItem)
                .SetBindItem(bindItem)
                .SetSelectionChange(selectionChange)
                .SetSelectionType(selectionType)
                .ModifyVerticalScroller(scroller =>
                {
                    scrollbarElement.Invoke(scroller.slider);
                    dragElement.Invoke(scroller.slider?.dragElement);
                });
            
            if(width != default)
                listViewBuilder.SetWidth(width);
            
            if(height != default)
                listViewBuilder.SetHeight(height);
                
            builder?.Invoke(listViewBuilder);
            return listViewBuilder.Build();
        }
    }
}