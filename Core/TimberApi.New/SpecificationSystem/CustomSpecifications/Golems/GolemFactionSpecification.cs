namespace TimberApi.New.SpecificationSystem.CustomSpecifications.Golems
{
    public class GolemFactionSpecification
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