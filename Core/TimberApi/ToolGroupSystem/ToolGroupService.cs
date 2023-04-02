using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.ToolGroupUISystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolGroupSystem
{
    public class ToolGroupService : ILoadableSingleton
    {
        private readonly ToolGroupSpecificationService _toolGroupSpecificationService;

        private readonly ToolGroupButtonFactoryService _toolGroupButtonFactoryService;

        private ImmutableDictionary<string, ApiToolGroup> _toolGroups = null!;

        private ImmutableDictionary<string, ToolGroupButton> _toolGroupButtons = null!;

        public IEnumerable<ApiToolGroup> ToolGroups => _toolGroups.Select(pair => pair.Value).ToImmutableArray();

        public IEnumerable<ToolGroupButton> ToolGroupButtons => _toolGroupButtons.Select(pair => pair.Value).ToImmutableArray();

        public ToolGroupService(ToolGroupSpecificationService toolGroupSpecificationService, ToolGroupButtonFactoryService toolGroupButtonFactoryService)
        {
            _toolGroupSpecificationService = toolGroupSpecificationService;
            _toolGroupButtonFactoryService = toolGroupButtonFactoryService;
        }

        public void Load()
        {
            var toolGroups = new Dictionary<string, ApiToolGroup>();

            var toolGroupButtons = new Dictionary<string, ToolGroupButton>();

            foreach (var toolGroupSpecification in _toolGroupSpecificationService.ToolGroupSpecifications)
            {
                var toolGroup = new ApiToolGroup(
                    toolGroupSpecification.Id,
                    toolGroupSpecification.GroupId,
                    toolGroupSpecification.Section,
                    toolGroupSpecification.NameLocKey,
                    toolGroupSpecification.DevMode,
                    toolGroupSpecification.Icon
                );
                toolGroups.Add(toolGroupSpecification.Id.ToLower(), toolGroup);

                var button = _toolGroupButtonFactoryService.Get(toolGroupSpecification.Layout).Create(toolGroup, toolGroupSpecification);
                toolGroupButtons.Add(toolGroupSpecification.Id.ToLower(), button);
            }

            _toolGroups = toolGroups.ToImmutableDictionary();
            _toolGroupButtons = toolGroupButtons.ToImmutableDictionary();
        }

        public ApiToolGroup GetToolGroup(string id)
        {
            if(! _toolGroups.TryGetValue(id.ToLower(), out var toolGroup))
            {
                throw new KeyNotFoundException($"The given ToolGroupId ({id.ToLower()}) cannot be found.");
            }

            return toolGroup;
        }

        public IEnumerable<ApiToolGroup> GetToolGroupByGroupId(string groupId)
        {
            return _toolGroups
                .Where(pair => pair.Value.GroupId?.ToLower() == groupId.ToLower())
                .Select(pair => pair.Value);
        }

        public IEnumerable<ApiToolGroup> GetToolGroupBySection(string section)
        {
            return _toolGroups
                .Where(pair => pair.Value.Section.ToLower().Equals(section.ToLower()))
                .Select(pair => pair.Value);
        }

        public ToolGroupButton GetToolGroupButton(string id)
        {
            if(! _toolGroupButtons.TryGetValue(id.ToLower(), out var toolGroupButton))
            {
                throw new KeyNotFoundException($"The given ToolGroupId ({id.ToLower()}) cannot be found.");
            }

            return toolGroupButton;
        }
    }
}