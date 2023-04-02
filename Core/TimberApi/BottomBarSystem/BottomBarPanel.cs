using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using TimberApi.BottomBarUISystem;
using Timberborn.BottomBarSystem;
using Timberborn.GameUI;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarPanel : ILoadableSingleton
    {
        private readonly ImmutableArray<BottomBarModule> _bottomBarModules;

        private readonly BottomBarService _bottomBarService;

        private readonly BottomBarUiService _bottomBarUiService;

        private readonly GameLayout _gameLayout;

        private VisualElement _bottomBarWrapper = null!;

        private readonly SortedDictionary<int, VisualElement> _mainWrapperSections = new();

        private readonly SortedDictionary<int, VisualElement> _bottomBarPanels = new();

        public BottomBarPanel(IEnumerable<BottomBarModule> bottomBarModules,
            BottomBarService bottomBarService,
            BottomBarUiService bottomBarUiService,
            GameLayout gameLayout,
            ToolButtonFactory toolButtonFactory)
        {
            _bottomBarModules = bottomBarModules.ToImmutableArray();
            _bottomBarUiService = bottomBarUiService;
            _gameLayout = gameLayout;
            _bottomBarService = bottomBarService;
        }

        public void Load()
        {
            var stopwatch1 = Stopwatch.StartNew();
            AntiCrash();
            stopwatch1.Stop();

            var stopwatch = Stopwatch.StartNew();

            SetupBottomBar();
            InitializeGroupButtons();
            InitializeSections();

            AddPanelsToWrapper();

            stopwatch.Stop();
            Debug.LogWarning($"Time to execute BottomBarPanel: {stopwatch.ElapsedMilliseconds}");
            Debug.LogWarning($"Time to execute Anti crash method: {stopwatch1.ElapsedMilliseconds}");
        }

        private void SetupBottomBar()
        {
            _bottomBarWrapper = _bottomBarUiService.CreateWrapper();
            _gameLayout.AddBottomBar(_bottomBarWrapper);
        }

        private void InitializeGroupButtons()
        {
            foreach (var bottomBarItem in _bottomBarService.ToolItemButtons.Where(button => ! button.Hidden))
            {
                if(bottomBarItem.IsGroup)
                {
                    AddElementToBottomBar(bottomBarItem.ToolGroup!.ToolGroupButton.Root, bottomBarItem.ToolGroup!.Row, bottomBarItem.ToolGroup!.Specification.GroupInformation.Section);
                    AddElementToBottomBar(bottomBarItem.ToolGroup!.ToolGroupButton.ToolButtonsElement, bottomBarItem.ToolGroup!.Row + 1, bottomBarItem.ToolGroup!.Specification.GroupInformation.Section);

                    if(bottomBarItem.ToolGroup!.Specification.GroupId != null)
                    {
                        _bottomBarService.GetToolGroup(bottomBarItem.ToolGroup!.Specification.GroupId).ToolGroupButton.AddToolGroupButton(bottomBarItem.ToolGroup!.ToolGroupButton);
                    }
                }
                else
                {
                    if(bottomBarItem.Tool!.Specification.GroupId is null)
                    {
                        continue;
                    }

                    var toolGroup = _bottomBarService.GetToolGroup(bottomBarItem.Tool!.Specification.GroupId);
                    toolGroup.ToolGroupButton.ToolButtonsElement.Add(bottomBarItem.Tool!.ToolButton.Root);
                    toolGroup.ToolGroupButton.AddTool(bottomBarItem.Tool!.ToolButton);
                }
            }
        }

        private void InitializeSections()
        {
            var mainPanel = GetOrInsertWrapper(0);

            var mainWrapper = BottomBarUiService.CreateMainSectionWrapper();

            foreach (var section in _mainWrapperSections)
            {
                mainWrapper.Add(section.Value);
            }

            mainPanel.Add(mainWrapper);
        }

        private void AddElementToBottomBar(VisualElement visualElement, int row, int section)
        {
            var element = row == 0 ? GetOrInsertSection(section) : GetOrInsertWrapper(row);

            element.Add(visualElement);
        }

        private VisualElement GetOrInsertWrapper(int row)
        {
            if(! _bottomBarPanels.ContainsKey(row))
            {
                _bottomBarPanels.Add(row, BottomBarUiService.CreateSubSectionWrapper());
            }

            return _bottomBarPanels[row];
        }

        private VisualElement GetOrInsertSection(int section)
        {
            if(! _mainWrapperSections.ContainsKey(section))
            {
                _mainWrapperSections.Add(section, BottomBarUiService.CreateSection());
            }

            return _mainWrapperSections[section];
        }

        private void AddPanelsToWrapper()
        {
            foreach (var bottomBarPanelPair in _bottomBarPanels.Reverse())
            {
                _bottomBarWrapper.Add(bottomBarPanelPair.Value);
            }
        }

        private void AntiCrash()
        {
            // var dictionary = _bottomBarModules.SelectMany((Func<BottomBarModule, IEnumerable<KeyValuePair<int, IBottomBarElementProvider>>>) (module => module.LeftElements))
            //     .ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value);
            // foreach (var key in dictionary.Keys.OrderBy(key => key))
            // {
            //     dictionary[key].GetElement();
            // }

            // foreach (IBottomBarElementsProvider elementsProvider in _bottomBarModules.SelectMany((Func<BottomBarModule, IEnumerable<IBottomBarElementsProvider>>) (module => module.MiddleElements)))
            // {
            //     foreach (BottomBarElement test in elementsProvider.GetElements())
            //     {
            //     }
            // }
        }
    }
}