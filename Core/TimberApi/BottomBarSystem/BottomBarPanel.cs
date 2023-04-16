using System.Collections.Generic;
using System.Linq;
using TimberApi.BottomBarUISystem;
using TimberApi.Common.Extensions;
using TimberApi.ToolGroupSystem;
using TimberApi.ToolSystem;
using Timberborn.BottomBarSystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;
using Timberborn.UILayoutSystem;
using UnityEngine.UIElements;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarPanel : ILoadableSingleton
    {
        private readonly SortedDictionary<int, VisualElement> _bottomBarPanels = new();

        private readonly BottomBarService _bottomBarService;

        private readonly BottomBarUiService _bottomBarUiService;

        private readonly SortedDictionary<int, VisualElement> _mainWrapperSections = new();

        private readonly ToolGroupService _toolGroupService;
        
        private readonly ToolService _toolService;

        private readonly UILayout _uiLayout;

        private VisualElement _bottomBarWrapper = null!;

        public BottomBarPanel(IEnumerable<BottomBarModule> bottomBarModules,
            BottomBarService bottomBarService,
            BottomBarUiService bottomBarUiService,
            UILayout uiLayout,
            ToolButtonFactory toolButtonFactory, ToolService toolService, ToolGroupService toolGroupService)
        {
            _bottomBarUiService = bottomBarUiService;
            _uiLayout = uiLayout;
            _toolService = toolService;
            _toolGroupService = toolGroupService;
            _bottomBarService = bottomBarService;
        }

        public void Load()
        {
            SetupBottomBar();
            InitializeButtons();
            InitializeSections();

            AddPanelsToWrapper();
        }

        private void SetupBottomBar()
        {
            _bottomBarWrapper = _bottomBarUiService.CreateWrapper();
            _uiLayout.AddBottomBar(_bottomBarWrapper);
        }

        private void InitializeButtons()
        {
            foreach (var bottomBarButton in _bottomBarService.ToolItemButtons.Where(button => ! button.Hidden).OrderBy(button => button.Order))
                if(bottomBarButton.IsGroup)
                    HandleGroupButton(bottomBarButton);
                else
                    HandleToolButton(bottomBarButton);
        }

        private void HandleGroupButton(BottomBarButton bottomBarButton)
        {
            var toolGroupButton = _toolGroupService.GetToolGroupButton(bottomBarButton.Id);

            var section = GetBottomBarSection(bottomBarButton);

            AddElementToBottomBar(toolGroupButton.Root, _bottomBarService.GetGroupRow(bottomBarButton.Id), section);
            AddElementToBottomBar(toolGroupButton.ToolButtonsElement, _bottomBarService.GetGroupRow(bottomBarButton.Id) + 1, section);

            if(bottomBarButton.GroupId != null) _toolGroupService.GetToolGroupButton(bottomBarButton.GroupId).AddToolGroupButton(toolGroupButton);
        }

        private void HandleToolButton(BottomBarButton bottomBarButton)
        {
            var toolButton = _toolService.GetToolButton(bottomBarButton.Id);

            if(bottomBarButton.GroupId is null)
            {
                AddElementToBottomBar(toolButton.Root, 0, GetBottomBarSection(bottomBarButton));
                return;
            }

            var toolGroupButton = _toolGroupService.GetToolGroupButton(bottomBarButton.GroupId);

            toolGroupButton.ToolButtonsElement.Add(toolButton.Root);
            toolGroupButton.AddTool(toolButton);
        }

        private int GetBottomBarSection(BottomBarButton bottomBarButton)
        {
            if(bottomBarButton.ButtonInformation == null) return 1;

            var objectLoader = ObjectLoader.CreateBasicLoader(bottomBarButton.ButtonInformation);

            return objectLoader.GetValueOrDefault(new PropertyKey<int>("BottomBarSection"), 1);
        }

        private void InitializeSections()
        {
            var mainPanel = GetOrInsertWrapper(0);

            var mainWrapper = BottomBarUiService.CreateMainSectionWrapper();

            foreach (var section in _mainWrapperSections) mainWrapper.Add(section.Value);

            mainPanel.Add(mainWrapper);
        }

        private void AddElementToBottomBar(VisualElement visualElement, int row, int section)
        {
            var element = row == 0 ? GetOrInsertSection(section) : GetOrInsertWrapper(row);

            element.Add(visualElement);
        }

        private VisualElement GetOrInsertWrapper(int row)
        {
            if(! _bottomBarPanels.ContainsKey(row)) _bottomBarPanels.Add(row, BottomBarUiService.CreateSubSectionWrapper());

            return _bottomBarPanels[row];
        }

        private VisualElement GetOrInsertSection(int section)
        {
            if(! _mainWrapperSections.ContainsKey(section)) _mainWrapperSections.Add(section, BottomBarUiService.CreateSection());

            return _mainWrapperSections[section];
        }

        private void AddPanelsToWrapper()
        {
            foreach (var bottomBarPanelPair in _bottomBarPanels.Reverse()) _bottomBarWrapper.Add(bottomBarPanelPair.Value);
        }
    }
}