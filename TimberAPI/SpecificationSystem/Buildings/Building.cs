using System;
using System.Collections.Generic;
using System.Text;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class Building
    {
        public Building(int scienceCost, List<BuildingCost> buildingCost)
        {
            ScienceCost = scienceCost;
            BuildingCost = buildingCost;
        }

        public int ScienceCost { get; set; }
        public List<BuildingCost> BuildingCost { get; set; }
    }
}
