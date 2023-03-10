using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using TimberApi.ToolGroupSystem;
using TimberApi.ToolGroupUISystem;
using Timberborn.SingletonSystem;
using Debug = UnityEngine.Debug;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarService : ILoadableSingleton
    {
        private static readonly string BottomBarSection = "BottomBar";

        private readonly ToolGroupSpecificationService _toolGroupSpecificationService;

        private readonly BottomBarToolGroupSpecificationDeserializer _bottomBarToolGroupSpecificationDeserializer;

        private readonly ToolGroupButtonVisualiserService _toolGroupButtonVisualiserService;

        private ImmutableDictionary<string, BottomBarToolGroupSpecification> _toolGroupSpecifications = null!;

        private ImmutableDictionary<string, BottomBarToolGroupButton> _toolGroupButtons = null!;

        public IEnumerable<BottomBarToolGroupButton> ToolGroupButtons => _toolGroupButtons.Select(pair => pair.Value);

        public BottomBarService(
            ToolGroupSpecificationService toolGroupSpecificationService,
            BottomBarToolGroupSpecificationDeserializer bottomBarToolGroupSpecificationDeserializer,
            ToolGroupButtonVisualiserService toolGroupButtonVisualiserService)
        {
            _bottomBarToolGroupSpecificationDeserializer = bottomBarToolGroupSpecificationDeserializer;
            _toolGroupButtonVisualiserService = toolGroupButtonVisualiserService;
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

        public void Load()
        {
            var stopwatch = Stopwatch.StartNew();

            _toolGroupSpecifications = _toolGroupSpecificationService
                .GetSection(BottomBarSection, _bottomBarToolGroupSpecificationDeserializer)
                .ToImmutableDictionary(specification => specification.Id.ToLower());

            _toolGroupButtons = CreateToolGroupButtons().ToImmutableDictionary(button => button.Specification.Id.ToLower());

            stopwatch.Stop();
            Debug.LogWarning($"Time to execute BottomBarService Loading: {stopwatch.ElapsedMilliseconds}");
        }

        private IEnumerable<BottomBarToolGroupButton> CreateToolGroupButtons()
        {
            foreach (var toolGroupSpecification in _toolGroupSpecifications.Select(pair => pair.Value))
            {
                var bottomBarToolGroup = new BottomBarToolGroup(toolGroupSpecification.Id, toolGroupSpecification.NameLocKey, toolGroupSpecification.Icon);

                var button = _toolGroupButtonVisualiserService.Get(toolGroupSpecification.Layout).GetToolGroupButton(bottomBarToolGroup, toolGroupSpecification);

                var row = GetRowNumber(toolGroupSpecification);

                yield return new BottomBarToolGroupButton(toolGroupSpecification, bottomBarToolGroup, button, row);
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