using System;
using Timberborn.Persistence;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Bots
{
    internal class BotFactionSpecificationObjectDeserializer : IObjectSerializer<BotFactionSpecification>
    {
        public void Serialize(BotFactionSpecification value, IObjectSaver objectSaver)
        {
            throw new NotSupportedException();
        }

        public Obsoletable<BotFactionSpecification> Deserialize(IObjectLoader objectLoader)
        {
            return (Obsoletable<BotFactionSpecification>) new BotFactionSpecification(objectLoader.Get(new PropertyKey<string>("FactionId")), objectLoader.Get(new PropertyKey<string>("BotId")));
        }
    }
}