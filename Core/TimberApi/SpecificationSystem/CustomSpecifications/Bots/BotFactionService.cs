using System.Collections.Immutable;
using System.Linq;
using Timberborn.FactionSystem;
using Timberborn.GameFactionSystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Bots
{
    internal class BotFactionService : ILoadableSingleton
    {
        private readonly FactionSpecificationService _factionSpecificationService;
        private readonly BotFactionSpecificationObjectDeserializer _botFactionSpecificationObjectDeserializer;

        private readonly ISpecificationService _specificationService;

        private ImmutableArray<BotFactionSpecification> _botFactions;

        public BotFactionService(FactionService factionService, ISpecificationService specificationService, FactionSpecificationService factionSpecificationService,
            BotFactionSpecificationObjectDeserializer botFactionSpecificationObjectDeserializer)
        {
            _specificationService = specificationService;
            _factionSpecificationService = factionSpecificationService;
            _botFactionSpecificationObjectDeserializer = botFactionSpecificationObjectDeserializer;
        }

        public void Load()
        {
            _botFactions = _specificationService.GetSpecifications(_botFactionSpecificationObjectDeserializer).ToImmutableArray();
        }

        public string GetGolemFactionIdByFactionId(string factionId)
        {
            BotFactionSpecification? golemFactionSpecification = _botFactions.FirstOrDefault(specification => specification.FactionId.Equals(factionId));
            if(golemFactionSpecification != null)
            {
                return golemFactionSpecification.BotId;
            }

            TimberApi.ConsoleWriter.Log("Golems for faction " + factionId + " doesn't exists, falling back to " + _factionSpecificationService.StartingFaction.Id);
            return _factionSpecificationService.StartingFaction.Id;
        }
    }
}