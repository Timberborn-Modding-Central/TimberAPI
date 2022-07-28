using System.Collections.Generic;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    /// <summary>
    /// Stripped version on Timberborn.Buildings.Building.
    /// Only contains relevant fields
    /// </summary>
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
