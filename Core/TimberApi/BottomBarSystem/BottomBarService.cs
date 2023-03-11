using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using TimberApi.ToolGroupUISystem;
using TimberApi.ToolSystem;
using TimberApi.ToolUISystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;
using Debug = UnityEngine.Debug;
using ToolGroupSpecification = TimberApi.ToolGroupSystem.ToolGroupSpecification;
using ToolGroupSpecificationService = TimberApi.ToolGroupSystem.ToolGroupSpecificationService;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarService : ILoadableSingleton
    {
        private static readonly string BottomBarSection = "BottomBar";

        private readonly ToolFactoryRepository _toolFactoryRepository;

        private readonly ToolGroupSpecificationService _toolGroupSpecificationService;

        private readonly ToolSpecificationService _toolSpecificationService;

        private readonly BottomBarToolGroupSpecificationDeserializer _bottomBarToolGroupSpecificationDeserializer;

        private readonly ToolGroupButtonFactoryService _toolGroupButtonFactoryService;

        private readonly ToolButtonFactoryService _toolButtonFactoryService;

        private ImmutableDictionary<string, BottomBarToolGroupSpecification> _toolGroupSpecifications = null!;

        private ImmutableDictionary<string, BottomBarToolGroupButton> _toolGroupButtons = null!;

        private ImmutableDictionary<string, BottomBarToolButton> _toolButtons = null!;

        private ImmutableArray<BottomBarItemButton> _toolItemButtons;

        public IEnumerable<BottomBarItemButton> ToolItemButtons => _toolItemButtons;

        public BottomBarService(
            ToolFactoryRepository toolFactoryRepository,
            ToolGroupSpecificationService toolGroupSpecificationService,
            BottomBarToolGroupSpecificationDeserializer bottomBarToolGroupSpecificationDeserializer,
            ToolGroupButtonFactoryService toolGroupButtonFactoryService,
            ToolSpecificationService toolSpecificationService,
            ToolButtonFactoryService toolButtonFactoryService)
        {
            _toolFactoryRepository = toolFactoryRepository;
            _bottomBarToolGroupSpecificationDeserializer = bottomBarToolGroupSpecificationDeserializer;
            _toolGroupButtonFactoryService = toolGroupButtonFactoryService;
            _toolSpecificationService = toolSpecificationService;
            _toolButtonFactoryService = toolButtonFactoryService;
            _toolGroupSpecificationService = toolGroupSpecificationService;
        }

        public BottomBarToolGroupButton GetToolGroup(string groupId)
        {
            if(! _toolGroupButtons.TryGetValue(groupId.ToLower(), out var toolGroupButton))
            {
                throw new KeyNotFoundException($"BottomBarToolGroup with the ID({groupId.ToLower()}) was not found.");
            }

            return toolGroupButton;
        }

        public BottomBarToolButton GetTool(string toolId)
        {
            if(! _toolButtons.TryGetValue(toolId.ToLower(), out var toolButton))
            {
                throw new KeyNotFoundException($"BottomBarTool with the ID({toolId.ToLower()}) was not found.");
            }

            return toolButton;
        }

        public void Load()
        {
            var stopwatch = Stopwatch.StartNew();

            _toolGroupSpecifications = _toolGroupSpecificationService
                .GetSection(BottomBarSection, _bottomBarToolGroupSpecificationDeserializer)
                .ToImmutableDictionary(specification => specification.Id.ToLower());

            _toolGroupButtons = CreateToolGroupButtons().ToImmutableDictionary(button => button.Specification.Id.ToLower());

            _toolButtons = CreateToolButtons().ToImmutableDictionary(button => button.Specification.Id.ToLower());

            _toolItemButtons = CreateItemButtons().ToImmutableArray().Sort();

            stopwatch.Stop();
            Debug.LogWarning($"Time to execute BottomBarService Loading: {stopwatch.ElapsedMilliseconds}");
        }

        private IEnumerable<BottomBarToolGroupButton> CreateToolGroupButtons()
        {
            foreach (var toolGroupSpecification in _toolGroupSpecifications.Select(pair => pair.Value))
            {
                var bottomBarToolGroup = new BottomBarToolGroup(toolGroupSpecification.Id, toolGroupSpecification.NameLocKey, toolGroupSpecification.DevModeTool, toolGroupSpecification.Icon);

                var button = _toolGroupButtonFactoryService.Get(toolGroupSpecification.Layout).Create(bottomBarToolGroup, toolGroupSpecification);

                var row = GetRowNumber(toolGroupSpecification);

                yield return new BottomBarToolGroupButton(toolGroupSpecification, bottomBarToolGroup, button, row);
            }
        }

        private IEnumerable<BottomBarToolButton> CreateToolButtons()
        {
            foreach (var specification in _toolSpecificationService.ToolSpecifications)
            {
                var toolFactory = _toolFactoryRepository.Get(specification.Type);

                Tool tool;

                if(specification.GroupId is null)
                {
                    tool = toolFactory.Create(specification);
                }
                else
                {
                    tool = toolFactory.Create(specification, GetToolGroup(specification.GroupId).ToolGroup);
                }

                var toolButton = _toolButtonFactoryService.Get(specification.Layout).Create(tool, specification);

                yield return new BottomBarToolButton(specification, toolButton, tool);
            }
        }

        private IEnumerable<BottomBarItemButton> CreateItemButtons()
        {
            foreach (var toolButton in _toolGroupButtons.Select(pair => pair.Value))
            {
                yield return new BottomBarItemButton(toolButton, toolButton.Specification.Order, toolButton.Specification.Hidden);
            }

            foreach (var toolButton in _toolButtons.Select(pair => pair.Value))
            {
                yield return new BottomBarItemButton(toolButton, toolButton.Specification.Order, toolButton.Specification.Hidden);
            }
        }

        private int GetRowNumber(ToolGroupSpecification toolGroupSpecification)
        {
            var row = 0;

            while (true)
            {
                if(toolGroupSpecification.GroupId == null)
                {
                    return row;
                }

                toolGroupSpecification = _toolGroupSpecifications[toolGroupSpecification.GroupId.ToLower()];
                row += 1;
            }
        }
    }
}