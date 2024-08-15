using System.Collections.Generic;
using Timberborn.Goods;

namespace BuildingSpecificationSystem;

internal class GoodAmountSpecificationComparer : IEqualityComparer<GoodAmountSpecification>
{
    public bool Equals(GoodAmountSpecification gas1, GoodAmountSpecification gas2)
    {
        if (gas1.Equals(default(GoodAmountSpecification)) && gas2.Equals(default(GoodAmountSpecification)))
        {
            return true;
        }

        if (gas1.Equals(default(GoodAmountSpecification)) || gas2.Equals(default(GoodAmountSpecification)))
        {
            return false;
        }

        return gas1.GoodId == gas2.GoodId;
    }

    public int GetHashCode(GoodAmountSpecification gas)
    {
        return gas.GoodId.GetHashCode();
    }
}