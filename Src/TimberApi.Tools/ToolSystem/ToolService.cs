using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.Tools.ToolGroupSystem;
using TimberApi.Tools.ToolUI;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem;

public class ToolService(
    ToolSpecificationService toolSpecificationService,
    ToolFactoryService toolFactoryService,
    ToolButtonFactoryService toolButtonFactoryService,
    ToolGroupService toolGroupService)
    : ILoadableSingleton
{
    private ImmutableDictionary<string, ToolButton> _toolButtons = null!;

    private ImmutableDictionary<string, Tool> _tools = null!;

    public IEnumerable<Tool> Tools => _tools.Select(pair => pair.Value).ToImmutableArray();

    public IEnumerable<ToolButton> ToolButtons => _toolButtons.Select(pair => pair.Value).ToImmutableArray();

    public void Load()
    {
        var tools = new Dictionary<string, Tool>();

        var toolButtons = new Dictionary<string, ToolButton>();

        foreach (var specification in toolSpecificationService.ToolSpecifications)
        {
            var toolFactory = toolFactoryService.Get(specification.Type);

            var tool = specification.GroupId is null
                ? toolFactory.Create(specification)
                : toolFactory.Create(specification, (ToolGroup)toolGroupService.GetToolGroup(specification.GroupId));

            tools.Add(specification.Id.ToLower(), tool);

            var toolButton = toolButtonFactoryService.Get(specification.Layout).Create(tool, specification);
            toolButtons.Add(specification.Id.ToLower(), toolButton);
        }

        _tools = tools.ToImmutableDictionary();
        _toolButtons = toolButtons.ToImmutableDictionary();
    }

    public Tool GetTool(string id)
    {
        if (!_tools.TryGetValue(id.ToLower(), out var tool))
            throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");

        return tool;
    }

    public ToolButton GetToolButton(string id)
    {
        if (!_toolButtons.TryGetValue(id.ToLower(), out var toolButton))
            throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");

        return toolButton;
    }
}