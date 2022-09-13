﻿using System.Collections.Generic;
using System.Linq;
using TimberApi.Common.Extensions;
using Timberborn.EntitySystem;
using Timberborn.Goods;
using Timberborn.MechanicalSystem;
using Timberborn.SingletonSystem;
using Timberborn.Workshops;

namespace TimberApi.New.SpecificationSystem.CustomSpecifications.Buildings
{
    public class BuildingChanger : ILoadableSingleton
    {
        private readonly ObjectCollectionService _objectCollectionService;

        private readonly BuildingSpecificationService _buildingSpecificationService;

        public BuildingChanger(ObjectCollectionService objectCollectionService, BuildingSpecificationService buildingSpecificationService)
        {
            _objectCollectionService = objectCollectionService;
            _buildingSpecificationService = buildingSpecificationService;
        }

        public void Load()
        {
            foreach (Timberborn.Buildings.Building building in _objectCollectionService.GetAllMonoBehaviours<Timberborn.Buildings.Building>())
            {
                BuildingSpecification? buildingSpecification = _buildingSpecificationService.GetBuildingSpecificationByBuilding(building);

                if (buildingSpecification == null)
                {
                    continue;
                }

                ChangeBuildingProperties(building, buildingSpecification);

                if (building.TryGetComponent(out Manufactory manufactory))
                {
                    ChangeManufactoryRecipes(manufactory, buildingSpecification);
                }

                if (building.TryGetComponent(out MechanicalNodeSpecification mechanicalNodeSpecification))
                {
                    ChangeMechanicalNodeSpecification(mechanicalNodeSpecification, buildingSpecification);
                }
            }
        }

        private static void ChangeMechanicalNodeSpecification(MechanicalNodeSpecification mechanicalNodeSpecification, BuildingSpecification buildingSpecification)
        {
            if (buildingSpecification.PowerOutput != null)
            {
                mechanicalNodeSpecification.SetPrivateInstanceFieldValue("_powerOutput", buildingSpecification.PowerOutput);
            }

            if (buildingSpecification.PowerInput != null)
            {
                mechanicalNodeSpecification.SetPrivateInstanceFieldValue("_powerInput", buildingSpecification.PowerInput);
            }
        }

        private static void ChangeManufactoryRecipes(Manufactory manufactory, BuildingSpecification buildingSpecification)
        {
            manufactory.SetPrivateInstanceFieldValue("_productionRecipeIds", buildingSpecification.RecipeIds.Distinct().ToArray());
        }

        private static void ChangeBuildingProperties(Timberborn.Buildings.Building building, BuildingSpecification buildingSpecification)
        {
            if (buildingSpecification.ScienceCost != null)
            {
                building.SetPrivateInstanceFieldValue("_scienceCost", buildingSpecification.ScienceCost);
            }

            List<BuildingCost> reverseList = new(buildingSpecification.BuildingCosts);
            reverseList.Reverse();
            building.SetPrivateInstanceFieldValue("_buildingCost", reverseList.Select(x => new GoodAmountSpecification(x.GoodId, x.Amount)).Distinct(new GoodAmountSpecificationComparer()).ToArray());
        }
    }
}