using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using TimberApi.BottomBarUISystem;
using TimberApi.Common.Extensions;
using TimberApi.ToolGroupUISystem;
using TimberApi.ToolSystem;
using Timberborn.AssetSystem;
using Timberborn.BlockObjectTools;
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

        private readonly ToolGroupButtonVisualiserService _toolGroupButtonVisualiserService;

        private readonly BottomBarService _bottomBarService;

        private readonly BottomBarUiService _bottomBarUiService;

        private readonly GameLayout _gameLayout;

        private readonly ToolButtonFactory _toolButtonFactory;

        private readonly ToolFactoryRepository _toolFactoryRepository;

        private readonly ToolSpecificationRepository _toolSpecificationRepository;

        private VisualElement _bottomBarWrapper = null!;

        private readonly SortedDictionary<int, VisualElement> _mainWrapperSections = new();

        private readonly SortedDictionary<int, VisualElement> _bottomBarPanels = new();

        private readonly List<KeyValuePair<BottomBarToolGroupSpecification, ToolGroupButton>> _sortedToolGroupButtons = new();

        private readonly Dictionary<string, ToolGroupButton> _toolGroupButtons = new();

        public BottomBarPanel(
            IEnumerable<BottomBarModule> bottomBarModules,
            BottomBarUiService bottomBarUiService,
            GameLayout gameLayout,
            BottomBarService bottomBarService,
            ToolGroupButtonVisualiserService toolGroupButtonVisualiserService, ToolButtonFactory toolButtonFactory, ToolFactoryRepository toolFactoryRepository, ToolSpecificationRepository toolSpecificationRepository,
            IResourceAssetLoader resourceAssetLoader, BlockObjectToolGroupSpecificationService blockObjectToolGroupSpecificationService)
        {
            _bottomBarModules = bottomBarModules.ToImmutableArray();
            _bottomBarUiService = bottomBarUiService;
            _gameLayout = gameLayout;
            _bottomBarService = bottomBarService;
            _toolGroupButtonVisualiserService = toolGroupButtonVisualiserService;
            _toolButtonFactory = toolButtonFactory;
            _toolFactoryRepository = toolFactoryRepository;
            _toolSpecificationRepository = toolSpecificationRepository;
        }

        public void Load()
        {
            var stopwatch1 = Stopwatch.StartNew();
            AntiCrash();
            stopwatch1.Stop();

            var stopwatch = Stopwatch.StartNew();

            SetupBottomBar();
            CreateToolGroupButtons();
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
            _bottomBarPanels.Add(0, BottomBarUiService.CreateMainSectionWrapper());

            _gameLayout.AddBottomBar(_bottomBarWrapper);
        }

        private void CreateToolGroupButtons()
        {
            foreach (var toolGroupSpecification in _bottomBarService.ToolGroupSpecifications.Select(pair => pair.Value))
            {
                var apiToolGroup = new BottomBarToolGroup(toolGroupSpecification.Id, toolGroupSpecification.NameLocKey, toolGroupSpecification.Icon);

                var button = _toolGroupButtonVisualiserService.Get(toolGroupSpecification.Layout).GetToolGroupButton(apiToolGroup, toolGroupSpecification);

                _toolGroupButtons.Add(toolGroupSpecification.Id, button);
                _sortedToolGroupButtons.Add(new KeyValuePair<BottomBarToolGroupSpecification, ToolGroupButton>(toolGroupSpecification, button));
            }

            _sortedToolGroupButtons.Sort((pair, valuePair) => pair.Key.Order.CompareTo(valuePair.Key.Order));
        }

        private void InitializeGroupButtons()
        {
            foreach (var keyValuePair in _sortedToolGroupButtons.Where(pair => ! pair.Key.Hidden))
            {
                var buttonRow = _bottomBarService.GetRowNumber(keyValuePair.Key.GroupId);

                foreach (var toolSpecification in _toolSpecificationRepository.GetAllFromGroup(keyValuePair.Key.Id))
                {
                    var tool = _toolFactoryRepository.Get(toolSpecification.Type).Create(toolSpecification, keyValuePair.Value.GetPrivateInstanceFieldValue<ToolGroup>("_toolGroup"));

                    var toolButton = _toolButtonFactory.Create(tool, toolSpecification.Icon, keyValuePair.Value.ToolButtonsElement);

                    keyValuePair.Value.AddTool(toolButton);
                }


                AddElementToBottomBar(keyValuePair.Value.Root, buttonRow, keyValuePair.Key.GroupInformation.Section);
                AddElementToBottomBar(keyValuePair.Value.ToolButtonsElement, buttonRow + 1, keyValuePair.Key.GroupInformation.Section);

                if(keyValuePair.Key.GroupId != null)
                {
                    _toolGroupButtons[keyValuePair.Key.GroupId].AddToolGroupButton(keyValuePair.Value);
                }
            }
        }

        private void InitializeSections()
        {
            var mainWrapper = GetOrInsertWrapper(0);

            foreach (var section in _mainWrapperSections)
            {
                mainWrapper.Add(section.Value);
            }
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
            var dictionary = _bottomBarModules.SelectMany((Func<BottomBarModule, IEnumerable<KeyValuePair<int, IBottomBarElementProvider>>>) (module => module.LeftElements))
                .ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value);
            foreach (var key in dictionary.Keys.OrderBy(key => key))
            {
                dictionary[key].GetElement();
            }

            // foreach (IBottomBarElementsProvider elementsProvider in _bottomBarModules.SelectMany((Func<BottomBarModule, IEnumerable<IBottomBarElementsProvider>>) (module => module.MiddleElements)))
            // {
            //     foreach (BottomBarElement test in elementsProvider.GetElements())
            //     {
            //     }
            // }
        }
    }
}