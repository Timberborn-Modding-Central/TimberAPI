namespace BuildingSpecificationSystem;

/// <summary>
///     Stripped version of Timberborn.Goods.GoodAmountSpecification.
///     Only contains relevant fields
/// </summary>
internal class BuildingCost(string goodId, int amount)
{
    public string GoodId { get; set; } = goodId;
    public int Amount { get; set; } = amount;
}