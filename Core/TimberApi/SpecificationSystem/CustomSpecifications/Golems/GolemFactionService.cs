using System.Collections.Immutable;
using System.Linq;
using Timberborn.FactionSystem;
using Timberborn.GameFactionSystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Golems
{
    internal class GolemFactionService : ILoadableSingleton
    {
        private readonly FactionSpecificationService _factionSpecificationService;
        private readonly GolemFactionSpecificationObjectDeserializer _golemFactionSpecificationObjectDeserializer;

        private readonly ISpecificationService _specificationService;

        private ImmutableArray<GolemFactionSpecification> _golemFactions;

        public GolemFactionService(FactionService factionService, ISpecificationService specificationService, FactionSpecificationService factionSpecificationService,
            GolemFactionSpecificationObjectDeserializer golemFactionSpecificationObjectDeserializer)
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
            GolemFactionSpecification? golemFactionSpecification = _golemFactions.FirstOrDefault(specification => specification.FactionId.Equals(factionId));
            if (golemFactionSpecification != null)
            {
                return golemFactionSpecification.GolemId;
            }

            TimberApi.ConsoleWriter.Log("Golems for faction " + factionId + " doesn't exists, falling back to " + _factionSpecificationService.StartingFaction.Id);
            return _factionSpecificationService.StartingFaction.Id;
        }
    }
}