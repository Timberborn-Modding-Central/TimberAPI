using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.Tools.ToolGroupSystem;
using TimberApi.Tools.ToolSystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;
using ToolGroupSpecificationService = TimberApi.Tools.ToolGroupSystem.ToolGroupSpecificationService;

namespace TimberApi.BottomBarSystem;

public class BottomBarService(
    ToolGroupSpecificationService toolGroupSpecificationService,
    ToolSpecService toolSpecService)
    : ILoadableSingleton
{
    private static readonly string BottomBarSection = "BottomBar";

    private readonly Dictionary<string, int> _toolGroupRows = new();

    private ImmutableDictionary<string, ToolGroupExtensionSpec> _toolGroupSpecs = null!;

    private ImmutableArray<BottomBarButton> _toolItemButtons;

    public IEnumerable<BottomBarButton> ToolItemButtons => _toolItemButtons;

    public void Load()
    {
        _toolGroupSpecs = toolGroupSpecificationService
            .GetBySection(BottomBarSection)
            .ToImmutableDictionary(spec => spec.Id, spec => spec.GetSpec<ToolGroupExtensionSpec>());

        _toolItemButtons = CreateItemButtons().ToImmutableArray().Sort();
    }


    private IEnumerable<BottomBarButton> CreateItemButtons()
    {
        foreach (var toolGroupExtensionSpec in _toolGroupSpecs.Select(pair => pair.Value))
        {
            var toolGroupSpec = toolGroupExtensionSpec.GetSpec<ToolGroupSpec>();
            
            _toolGroupRows.Add(toolGroupSpec.Id.ToLower(), CalculateGroupRow(toolGroupExtensionSpec));

            yield return new BottomBarButton(
                toolGroupSpec.GetSpec<BottomBarSpec>(),
                toolGroupSpec.Id,
                true,
                toolGroupExtensionSpec.GroupId,
                toolGroupExtensionSpec.Hidden,
                toolGroupSpec.Order
            );
        }

        foreach (var toolSpec in toolSpecService.GetBySection("BottomBar"))
            yield return new BottomBarButton(
                toolSpec.GetSpec<BottomBarSpec>(),
                toolSpec.Id,
                false,
                toolSpec.GroupId,
                toolSpec.Hidden,
                toolSpec.Order);
    }

    public int GetGroupRow(string groupId)
    {
        if (!_toolGroupRows.TryGetValue(groupId.ToLower(), out var row))
            throw new KeyNotFoundException($"The given GroupId ({groupId.ToLower()}) cannot be found.");

        return row;
    }

    private int CalculateGroupRow(ToolGroupExtensionSpec toolGroupExtensionSpec)
    {
        var row = 0;

        while (toolGroupExtensionSpec.GroupId != null)
        {
            toolGroupExtensionSpec = _toolGroupSpecs[toolGroupExtensionSpec.GroupId];
            row += 1;
        }

        return row;
    }
}