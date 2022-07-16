using System.Collections.Immutable;
using System.Linq;
using Timberborn.FactionSystem;
using Timberborn.FactionSystemGame;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;
using TimberbornAPI.Internal;

namespace TimberbornAPI.SpecificationSystem.Fixes.CustomSpecifications.Golems
{
    public class GolemFactionService : ILoadableSingleton
    {
        private readonly GolemFactionSpecificationObjectDeserializer _golemFactionSpecificationObjectDeserializer;

        private readonly FactionSpecificationService _factionSpecificationService;

        private readonly ISpecificationService _specificationService;

        private ImmutableArray<GolemFactionSpecification> _golemFactions;

        public GolemFactionService(FactionService factionService, ISpecificationService specificationService, FactionSpecificationService factionSpecificationService, GolemFactionSpecificationObjectDeserializer golemFactionSpecificationObjectDeserializer)
        {
            _specificationService = specificationService;
            _factionSpecificationService = factionSpecificationService;
            _golemFactionSpecificationObjectDeserializer = golemFactionSpecificationObjectDeserializer;
        }

        public void Load()
        {
            _golemFactions = _specificationService.GetSpecifications(_golemFactionSpecificationObjectDeserializer).ToImmutableArray();
        }

        public string GetGolemFactionIdByFactionId(string factionId)
        {
            GolemFactionSpecification golemFactionSpecification = _golemFactions.FirstOrDefault(specification => specification.FactionId.Equals(factionId));
            if (golemFactionSpecification is not null)
                return golemFactionSpecification.GolemId;

            TimberAPIPlugin.Log.LogWarning("Golems for faction " + factionId + " doesn't exists, falling back to " + _factionSpecificationService.StartingFaction.Id);
            return _factionSpecificationService.StartingFaction.Id;
        }
    }
}