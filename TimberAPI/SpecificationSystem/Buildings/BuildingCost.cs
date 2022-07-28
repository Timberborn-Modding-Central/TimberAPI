using System;
using System.Collections.Generic;
using System.Text;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
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
