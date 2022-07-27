using System;
using System.Collections.Generic;
using System.Text;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class BuildingSpecification
    {
        public BuildingSpecification(
            string buildingId,
            List<Recipe> recipes,
            Building building)
        {
            BuildingId = buildingId;
            Recipes = recipes;
            Building = building;
        }

        public string BuildingId;

        public List<Recipe> Recipes;

        public Building Building;
    }

    public class Recipe
    {
        public string Id;

        public Recipe(string id)
        {
            Id = id;
        }
    }

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