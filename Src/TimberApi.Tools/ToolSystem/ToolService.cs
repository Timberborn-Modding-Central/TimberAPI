using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.Tools.ToolGroupSystem;
using TimberApi.Tools.ToolUI;
using Timberborn.SingletonSystem;
using Timberborn.ToolButtonSystem;
using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.Tools.ToolSystem;

public class ToolService(
    ToolSpecService toolSpecService,
    ToolFactoryService toolFactoryService,
    ToolButtonFactoryService toolButtonFactoryService,
    TimberApi.Tools.ToolGroupSystem.ToolGroupService toolGroupService)
    : ILoadableSingleton
{
    private ImmutableDictionary<string, ToolButton> _toolButtons = null!;

    private ImmutableDictionary<string, ITool> _tools = null!;

    public IEnumerable<ITool> Tools => _tools.Select(pair => pair.Value).ToImmutableArray();

    public IEnumerable<ToolButton> ToolButtons => _toolButtons.Select(pair => pair.Value).ToImmutableArray();

    public void Load()
    {
        var tools = new Dictionary<string, ITool>();

        var toolButtons = new Dictionary<string, ToolButton>();

        foreach (var specification in toolSpecService.ToolSpecifications)
        {
            var toolFactory = toolFactoryService.Get(specification.Type);
            
            var tool = specification.GroupId is null
                ? toolFactory.Create(specification)
                : toolFactory.Create(specification, (IToolGroup)toolGroupService.GetToolGroup(specification.GroupId));

            tools.Add(specification.Id.ToLower(), tool);

            var toolButton = toolButtonFactoryService.Get(specification.Layout).Create(tool, specification);
            toolButtons.Add(specification.Id.ToLower(), toolButton);
        }

        _tools = tools.ToImmutableDictionary();
        _toolButtons = toolButtons.ToImmutableDictionary();
    }

    public ITool GetTool(string id)
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