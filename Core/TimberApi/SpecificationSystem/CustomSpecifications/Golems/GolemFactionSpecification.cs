namespace TimberApi.SpecificationSystem.CustomSpecifications.Golems
{
    internal class GolemFactionSpecification
    {
        public GolemFactionSpecification(string factionId, string golemId)
        {
            FactionId = factionId;
            GolemId = golemId;
        }

        public string FactionId { get; set; }

        public string GolemId { get; set; }
    }
}