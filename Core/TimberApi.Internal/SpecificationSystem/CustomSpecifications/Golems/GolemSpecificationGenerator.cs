using System.Collections.Generic;
using TimberApi.Internal.SpecificationSystem.SpecificationTypes;

namespace TimberApi.Internal.SpecificationSystem.CustomSpecifications.Golems
{
    public class GolemSpecificationGenerator : ISpecificationGenerator
    {
        private static readonly string SpecificationName = "GolemFactionSpecification";

        public IEnumerable<ISpecification> Generate()
        {
            yield return new GeneratedSpecification(@"{""FactionId"": ""Folktails"",""GolemId"": ""Folktails""}", "Folktails", SpecificationName);
            yield return new GeneratedSpecification(@"{""FactionId"": ""IronTeeth"",""GolemId"": ""IronTeeth""}", "IronTeeth", SpecificationName);
        }
    }
}