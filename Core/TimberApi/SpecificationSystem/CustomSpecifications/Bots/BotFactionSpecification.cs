namespace TimberApi.SpecificationSystem.CustomSpecifications.Bots
{
    internal class BotFactionSpecification
    {
        public BotFactionSpecification(string factionId, string botId)
        {
            FactionId = factionId;
            BotId = botId;
        }

        public string FactionId { get; set; }

        public string BotId { get; set; }
    }
}