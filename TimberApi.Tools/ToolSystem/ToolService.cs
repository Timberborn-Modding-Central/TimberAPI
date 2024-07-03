using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem;

public class ToolService
{
    //
    // private readonly ToolFactoryService _toolFactoryService;
    //
    // private readonly ToolGroupService _toolGroupService;
    //
    // private readonly ToolSpecificationService _toolSpecificationService;
    //
    // private ImmutableDictionary<string, ToolButton> _toolButtons = null!;
    //
    // private ImmutableDictionary<string, Tool> _tools = null!;
    //
    // public ToolService(ToolSpecificationService toolSpecificationService, ToolFactoryService toolFactoryService, ToolGroupService toolGroupService)
    // {
    //     _toolSpecificationService = toolSpecificationService;
    //     _toolFactoryService = toolFactoryService;
    //     _toolGroupService = toolGroupService;
    // }
    //
    // public IEnumerable<Tool> Tools => _tools.Select(pair => pair.Value).ToImmutableArray();
    //
    //
    // public void Load()
    // {
    //     var tools = new Dictionary<string, Tool>();
    //
    //     foreach (var specification in _toolSpecificationService.ToolSpecifications)
    //     {
    //         var toolFactory = _toolFactoryService.Get(specification.Type);
    //
    //         var tool = specification.GroupId is null
    //             ? toolFactory.Create(specification)
    //             : toolFactory.Create(specification, (ToolGroup)_toolGroupService.GetToolGroup(specification.GroupId));
    //
    //         tools.Add(specification.Id.ToLower(), tool);
    //     }
    //
    //     _tools = tools.ToImmutableDictionary();
    // }
    //
    // public Tool GetTool(string id)
    // {
    //     if (!_tools.TryGetValue(id.ToLower(), out var tool))
    //     {
    //         throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");
    //     }
    //
    //     return tool;
    // }
}