using System.Collections.Generic;
using TimberApi.SpecificationSystem;
using Timberborn.PrefabGroupSystem;
using UnityEngine;

namespace Tester;

public class Generator : ISpecificationGenerator
{
    private readonly PrefabGroupService _prefabGroupService;

    public Generator(PrefabGroupService prefabGroupService)
    {
        _prefabGroupService = prefabGroupService;
    }

    public IEnumerable<GeneratedSpecification> Generate()
    {
        Debug.LogError("This is my generator");
        Debug.LogError(_prefabGroupService.AllPrefabs.Length);
        return new List<GeneratedSpecification>
        {
            new("specifications/needsaffectedbysoakedness", "NeedAffectedBySoakednessSpecification.WetFur", new
                {
                    NeedId = "WetFur",
                    PointsPerHour = 500,
                }
            )
        };
    }
}