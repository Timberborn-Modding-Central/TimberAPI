using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.Tools.ToolGroupUI;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolGroupSystem;

public class ToolGroupService(
    ToolGroupSpecificationService toolGroupSpecificationService,
    ToolGroupButtonFactoryService toolGroupButtonFactoryService,
    ToolGroupFactoryService toolGroupFactoryService)
    : ILoadableSingleton
{
    private ImmutableDictionary<string, ToolGroupButton> _toolGroupButtons = null!;

    private ImmutableDictionary<string, IToolGroup> _toolGroups = null!;

    public IEnumerable<IToolGroup> ToolGroups => _toolGroups.Select(pair => pair.Value).ToImmutableArray();

    public IEnumerable<ToolGroupButton> ToolGroupButtons =>
        _toolGroupButtons.Select(pair => pair.Value).ToImmutableArray();

    public void Load()
    {
        var toolGroups = new Dictionary<string, IToolGroup>();

        var toolGroupButtons = new Dictionary<string, ToolGroupButton>();

        foreach (var toolGroupSpecification in toolGroupSpecificationService.ToolGroupSpecifications
                     .OrderBy(x => x.Layout).ThenBy(x => x.Order))
        {
            var toolGroup = toolGroupFactoryService.Get(toolGroupSpecification.Type).Create(toolGroupSpecification);

            toolGroups.Add(toolGroupSpecification.Id.ToLower(), toolGroup);

            var button = toolGroupButtonFactoryService.Get(toolGroupSpecification.Layout)
                .Create(toolGroup, toolGroupSpecification);
            toolGroupButtons.Add(toolGroupSpecification.Id.ToLower(), button);
        }

        _toolGroups = toolGroups.ToImmutableDictionary();
        _toolGroupButtons = toolGroupButtons.ToImmutableDictionary();
    }

    public IToolGroup GetToolGroup(string id)
    {
        if (!_toolGroups.TryGetValue(id.ToLower(), out var toolGroup))
            throw new KeyNotFoundException($"The given ToolGroupId ({id.ToLower()}) cannot be found.");

        return toolGroup;
    }

    public IEnumerable<IToolGroup> GetToolGroupByGroupId(string groupId)
    {
        return _toolGroups
            .Where(pair => pair.Value.GroupId?.ToLower() == groupId.ToLower())
            .Select(pair => pair.Value);
    }

    public IEnumerable<IToolGroup> GetToolGroupBySection(string section)
    {
        return _toolGroups
            .Where(pair => pair.Value.Section.ToLower().Equals(section.ToLower()))
            .Select(pair => pair.Value);
    }

    public ToolGroupButton GetToolGroupButton(string id)
    {
        if (!_toolGroupButtons.TryGetValue(id.ToLower(), out var toolGroupButton))
            throw new KeyNotFoundException($"The given ToolGroupId ({id.ToLower()}) cannot be found.");

        return toolGroupButton;
    }

    public IEnumerable<ToolGroupButton> GetToolGroupButtonByGroupId(string groupId)
    {
        return _toolGroupButtons
            .Where(pair => ((IToolGroup)pair.Value._toolGroup).GroupId?.ToLower() == groupId.ToLower())
            .Select(pair => pair.Value);
    }
}