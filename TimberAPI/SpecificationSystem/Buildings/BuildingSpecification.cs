using System.Collections.Generic;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class BuildingSpecification
    {
        public BuildingSpecification(
            string buildingId,
            List<Recipe> recipes,
            Building building,
            MechanicalNode mechanicalNode)
        {
            BuildingId = buildingId;
            Recipes = recipes;
            Building = building;
            MechanicalNode = mechanicalNode;
        }

        public string BuildingId;

        public List<Recipe> Recipes;

        public Building Building;

        public MechanicalNode MechanicalNode;
    }
}