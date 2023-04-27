using System.Collections.Immutable;
using System.Linq;
using TimberApi.Common.SingletonSystem;
using Timberborn.FactionSystem;
using Timberborn.GameFactionSystem;
using Timberborn.Persistence;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Bots
{
    internal class BotFactionService : ITimberApiLoadableSingleton
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

        public string GetBotFactionIdByFactionId(string factionId)
        {
            var botFactionSpecification = _botFactions.FirstOrDefault(specification => specification.FactionId.Equals(factionId));
            
            if(botFactionSpecification != null)
            {
                return botFactionSpecification.BotId;
            }

            TimberApi.ConsoleWriter.Log("Bots for faction " + factionId + " doesn't exists, falling back to " + _factionSpecificationService.StartingFaction.Id);
            return _factionSpecificationService.StartingFaction.Id;
        }
    }
}