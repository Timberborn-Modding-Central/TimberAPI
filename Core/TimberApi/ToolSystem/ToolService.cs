using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.ToolGroupSystem;
using TimberApi.ToolUISystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem
{
    public class ToolService : ILoadableSingleton
    {
        private readonly ToolSpecificationService _toolSpecificationService;

        private readonly ToolFactoryService _toolFactoryService;

        private readonly ToolButtonFactoryService _toolButtonFactoryService;

        private readonly ToolGroupService _toolGroupService;

        private ImmutableDictionary<string, Tool> _tools = null!;

        private ImmutableDictionary<string, ToolButton> _toolButtons = null!;

        public IEnumerable<Tool> Tools => _tools.Select(pair => pair.Value).ToImmutableArray();

        public IEnumerable<ToolButton> ToolButtons => _toolButtons.Select(pair => pair.Value).ToImmutableArray();

        public ToolService(ToolSpecificationService toolSpecificationService, ToolFactoryService toolFactoryService, ToolButtonFactoryService toolButtonFactoryService, ToolGroupService toolGroupService)
        {
            _toolSpecificationService = toolSpecificationService;
            _toolFactoryService = toolFactoryService;
            _toolButtonFactoryService = toolButtonFactoryService;
            _toolGroupService = toolGroupService;
        }

        public void Load()
        {
            var tools = new Dictionary<string, Tool>();

            var toolButtons = new Dictionary<string, ToolButton>();

            foreach (var specification in _toolSpecificationService.ToolSpecifications)
            {
                var toolFactory = _toolFactoryService.Get(specification.Type);

                var tool = specification.GroupId is null ? toolFactory.Create(specification) : toolFactory.Create(specification, _toolGroupService.GetToolGroup(specification.GroupId));
                tools.Add(specification.Id.ToLower(), tool);

                var toolButton = _toolButtonFactoryService.Get(specification.Layout).Create(tool, specification);
                toolButtons.Add(specification.Id.ToLower(), toolButton);
            }

            _tools = tools.ToImmutableDictionary();
            _toolButtons = toolButtons.ToImmutableDictionary();
        }

        public Tool GetTool(string id)
        {
            if(! _tools.TryGetValue(id.ToLower(), out var toolGroup))
            {
                throw new KeyNotFoundException($"The given ToolGroupId ({id.ToLower()}) cannot be found.");
            }

            return toolGroup;
        }

        public ToolButton GetToolButton(string id)
        {
            if(! _toolButtons.TryGetValue(id.ToLower(), out var toolGroupButton))
            {
                throw new KeyNotFoundException($"The given ToolGroupId ({id.ToLower()}) cannot be found.");
            }

            return toolGroupButton;
        }
    }
}