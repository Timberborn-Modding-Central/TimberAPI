using System.Collections.Immutable;
using System.Diagnostics;
using TimberApi.ToolGroupSystem;
using Timberborn.SingletonSystem;
using Debug = UnityEngine.Debug;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarService : ILoadableSingleton
    {
        private static readonly string BottomBarSection = "BottomBar";

        private readonly ToolGroupSpecificationService _toolGroupSpecificationService;

        private readonly BottomBarToolGroupSpecificationDeserializer _bottomBarToolGroupSpecificationDeserializer;

        public ImmutableDictionary<string, ToolGroupSpecification> ToolGroupSpecifications { get; private set; } = null!;

        public BottomBarService(
            ToolGroupSpecificationService toolGroupSpecificationService,
            BottomBarToolGroupSpecificationDeserializer bottomBarToolGroupSpecificationDeserializer)
        {
            _bottomBarToolGroupSpecificationDeserializer = bottomBarToolGroupSpecificationDeserializer;
            _toolGroupSpecificationService = toolGroupSpecificationService;
        }

        public void Load()
        {
            var stopwatch = Stopwatch.StartNew();

            ToolGroupSpecifications = _toolGroupSpecificationService
                .GetSection(BottomBarSection, _bottomBarToolGroupSpecificationDeserializer)
                .ToImmutableDictionary(specification => specification.Id, specification => specification);

            Debug.LogWarning($"Total count: {ToolGroupSpecifications.Count}");


            stopwatch.Stop();
            Debug.LogWarning($"Time to execute: {stopwatch.ElapsedMilliseconds}");
        }

        public int GetRowNumber(string? groupId)
        {
            var row = 0;

            while (true)
            {
                if (groupId == null)
                {
                    return row;
                }

                groupId = ToolGroupSpecifications[groupId].GroupId;
                row += 1;
            }
        }
    }
}