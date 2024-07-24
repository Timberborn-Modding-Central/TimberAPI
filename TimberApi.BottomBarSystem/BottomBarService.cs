using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.Tools.ToolSystem;
using Timberborn.SingletonSystem;
using ToolGroupSpecification = TimberApi.Tools.ToolGroupSystem.ToolGroupSpecification;
using ToolGroupSpecificationService = TimberApi.Tools.ToolGroupSystem.ToolGroupSpecificationService;

namespace TimberApi.BottomBarSystem;

public class BottomBarService : ILoadableSingleton
{
    private static readonly string BottomBarSection = "BottomBar";

    private readonly Dictionary<string, int> _toolGroupRows = new();

    private readonly ToolGroupSpecificationService _toolGroupSpecificationService;

    private readonly ToolSpecificationService _toolSpecificationService;

    private ImmutableDictionary<string, ToolGroupSpecification> _toolGroupSpecifications = null!;

    private ImmutableArray<BottomBarButton> _toolItemButtons;

    public BottomBarService(
        ToolGroupSpecificationService toolGroupSpecificationService,
        ToolSpecificationService toolSpecificationService)
    {
        _toolGroupSpecificationService = toolGroupSpecificationService;
        _toolSpecificationService = toolSpecificationService;
    }

    public IEnumerable<BottomBarButton> ToolItemButtons => _toolItemButtons;

    public void Load()
    {
        _toolGroupSpecifications = _toolGroupSpecificationService
            .GetBySection(BottomBarSection)
            .ToImmutableDictionary(specification => specification.Id);

        _toolItemButtons = CreateItemButtons().ToImmutableArray().Sort();
    }


    private IEnumerable<BottomBarButton> CreateItemButtons()
    {
        foreach (var specification in _toolGroupSpecifications.Select(pair => pair.Value))
        {
            _toolGroupRows.Add(specification.Id.ToLower(), CalculateGroupRow(specification));

            yield return new BottomBarButton(
                specification.Id,
                true,
                specification.GroupId,
                specification.Hidden,
                specification.Order,
                specification.GroupInformation
            );
        }

        foreach (var specification in _toolSpecificationService.GetBySection("BottomBar"))
            yield return new BottomBarButton(
                specification.Id,
                false,
                specification.GroupId,
                specification.Hidden,
                specification.Order,
                specification.ToolInformation
            );
    }

    public int GetGroupRow(string groupId)
    {
        if (!_toolGroupRows.TryGetValue(groupId.ToLower(), out var row))
            throw new KeyNotFoundException($"The given GroupId ({groupId.ToLower()}) cannot be found.");

        return row;
    }

    private int CalculateGroupRow(ToolGroupSpecification toolGroupSpecification)
    {
        var row = 0;

        while (toolGroupSpecification.GroupId != null)
        {
            toolGroupSpecification = _toolGroupSpecifications[toolGroupSpecification.GroupId];
            row += 1;
        }

        return row;
    }
}