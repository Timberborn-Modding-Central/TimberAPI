using System.Collections.Generic;
using System.Linq;
using Timberborn.Buildings;
using Timberborn.Goods;
using Timberborn.MechanicalSystem;
using Timberborn.PrefabSystem;
using Timberborn.SingletonSystem;
using Timberborn.Workshops;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Buildings
{
    public class BuildingChangeApplier : ILoadableSingleton
    {
        private readonly BuildingSpecificationService _buildingSpecificationService;
        private readonly ObjectCollectionService _objectCollectionService;

        public BuildingChangeApplier(ObjectCollectionService objectCollectionService, BuildingSpecificationService buildingSpecificationService)
        {
            _objectCollectionService = objectCollectionService;
            _buildingSpecificationService = buildingSpecificationService;
        }
        
        public void Load()
        {
            foreach (var building in _objectCollectionService.GetAllMonoBehaviours<Building>())
            {
                var buildingSpecification = _buildingSpecificationService.GetBuildingSpecificationByBuilding(building);

                if (buildingSpecification == null)
                {
                    continue;
                }

                ChangeBuildingProperties(building, buildingSpecification);

                if (building.TryGetComponentFast(out Manufactory manufactory))
                {
                    ChangeManufactoryRecipes(manufactory, buildingSpecification);
                }

                if (building.TryGetComponentFast(out MechanicalNodeSpecification mechanicalNodeSpecification))
                {
                    ChangeMechanicalNodeSpecification(mechanicalNodeSpecification, buildingSpecification);
                }
            }
        }

        private static void ChangeMechanicalNodeSpecification(MechanicalNodeSpecification mechanicalNodeSpecification, BuildingSpecification buildingSpecification)
        {
            if (buildingSpecification.PowerOutput != null)
            {
                mechanicalNodeSpecification._powerOutput = (int) buildingSpecification.PowerOutput;
            }

            if (buildingSpecification.PowerInput != null)
            {
                mechanicalNodeSpecification._powerInput = (int) buildingSpecification.PowerInput;
            }
        }

        private static void ChangeManufactoryRecipes(Manufactory manufactory, BuildingSpecification buildingSpecification)
        {
            manufactory._productionRecipeIds = buildingSpecification.RecipeIds.Distinct().ToArray();
        }

        private static void ChangeBuildingProperties(Building building, BuildingSpecification buildingSpecification)
        {
            if (buildingSpecification.ScienceCost != null)
            {
                building._scienceCost = (int) buildingSpecification.ScienceCost;
            }

            List<BuildingCost> reverseList = new(buildingSpecification.BuildingCosts);
            reverseList.Reverse();

            building._buildingCost = reverseList.Select(x => new GoodAmountSpecification(x.GoodId, x.Amount)).Distinct(new GoodAmountSpecificationComparer()).ToArray();
        }
    }
}