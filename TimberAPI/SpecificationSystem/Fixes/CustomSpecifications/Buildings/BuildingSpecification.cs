using System.Collections.Generic;

namespace TimberbornAPI.SpecificationSystem.Fixes.CustomSpecifications.Buildings
{
    /// <summary>
    /// Represents the various settings that can be changed 
    /// on Buildings using TimberAPI
    /// </summary>
    public class BuildingSpecification
    {
        public BuildingSpecification(
            string buildingId,
            List<Recipe> recipes,
            Building building,
            MechanicalNode mechanicalNode)
        {
            Id = buildingId;
            Recipes = recipes;
            Building = building;
            MechanicalNode = mechanicalNode;
        }

        public string Id;

        public List<Recipe> Recipes;

        public Building Building;

        public MechanicalNode MechanicalNode;
    }
}