namespace TimberApi.New.SpecificationSystem.CustomSpecifications.Buildings
{
    /// <summary>
    ///     Stripped version of Timberborn.Goods.GoodAmountSpecification.
    ///     Only contains relevant fields
    /// </summary>
    public class BuildingCost
    {
        public BuildingCost(string goodId, int amount)
        {
            GoodId = goodId;
            Amount = amount;
        }

        public string GoodId { get; set; }
        public int Amount { get; set; }
    }
}