using System.Collections.Generic;
using TimberApi.Common.SingletonSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Bots
{
    internal class BotSpecificationGenerator : ITimberApiLoadableSingleton
    {
        private static readonly string SpecificationName = "BotFactionSpecification";

        private readonly SpecificationRepository _specificationRepository;

        public BotSpecificationGenerator(SpecificationRepository specificationRepository)
        {
            _specificationRepository = specificationRepository;
        }

        public void Load()
        {
            _specificationRepository.AddRange(GenerateSpecifications());
        }

        private static IEnumerable<ISpecification> GenerateSpecifications()
        {
            yield return new GeneratedSpecification(@"{""FactionId"": ""Folktails"",""BotId"": ""Folktails""}", "Folktails", SpecificationName);
            yield return new GeneratedSpecification(@"{""FactionId"": ""IronTeeth"",""BotId"": ""IronTeeth""}", "IronTeeth", SpecificationName);
        }
    }
}