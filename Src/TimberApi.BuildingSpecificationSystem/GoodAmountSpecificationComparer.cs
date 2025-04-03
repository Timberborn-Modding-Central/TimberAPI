using System.Collections.Generic;
using Timberborn.Goods;

namespace TimberApi.BuildingSpecificationSystem;

internal class GoodAmountSpecComparer : IEqualityComparer<GoodAmountSpec>
{
    public bool Equals(GoodAmountSpec gas1, GoodAmountSpec gas2)
    {
        if (gas1.Equals(default(GoodAmountSpec)) && gas2.Equals(default(GoodAmountSpec)))
        {
            return true;
        }

        if (gas1.Equals(default(GoodAmountSpec)) || gas2.Equals(default(GoodAmountSpec)))
        {
            return false;
        }

        return gas1.GoodId == gas2.GoodId;
    }

    public int GetHashCode(GoodAmountSpec gas)
    {
        return gas.GoodId.GetHashCode();
    }
}