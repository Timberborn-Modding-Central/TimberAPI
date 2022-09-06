using System;
using Timberborn.Persistence;

namespace TimberApi.New.SpecificationSystem.CustomSpecifications.Golems
{
    public class GolemFactionSpecificationObjectDeserializer : IObjectSerializer<GolemFactionSpecification>
    {
        public void Serialize(GolemFactionSpecification value, IObjectSaver objectSaver)
        {
            throw new NotSupportedException();
        }

        public Obsoletable<GolemFactionSpecification> Deserialize(IObjectLoader objectLoader)
        {
            return (Obsoletable<GolemFactionSpecification>) new GolemFactionSpecification(objectLoader.Get(new PropertyKey<string>("FactionId")), objectLoader.Get(new PropertyKey<string>("GolemId")));
        }
    }
}