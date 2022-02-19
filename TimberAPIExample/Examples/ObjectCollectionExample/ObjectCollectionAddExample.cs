using System;
using Timberborn.AssetSystem;
using Timberborn.FactionSystem;
using Timberborn.FactionSystemGame;
using Timberborn.SingletonSystem;
using TimberbornAPI;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.LocalizationSystem;
using TimberbornAPI.ObjectCollectionSystem;
using UnityEngine;

namespace TimberAPIExample.Examples.ObjectCollectionExample
{
    public class ObjectCollectionAddExample : ILoadableSingleton
    {
        private readonly IAssetLoader _assetLoader;
        private readonly IResourceAssetLoader _resourceAssetLoader;
        private readonly FactionService _factionService;
        private readonly FactionSpecificationService _factionSpecificationService;

        public ObjectCollectionAddExample(IAssetLoader assetLoader, IResourceAssetLoader resourceAssetLoader, FactionService factionService, FactionSpecificationService factionSpecificationService)
        {
            _assetLoader = assetLoader;
            _resourceAssetLoader = resourceAssetLoader;
            _factionService = factionService;
            _factionSpecificationService = factionSpecificationService;
        }

        // Get the first Unique Building from the other faction and load it
        // Then add it to the custom object collection
        public void Load()
        {
            GameObject customObject =_assetLoader.Load<GameObject>("TimberAPIExample/elec.extendedarchitecture.bundle/4x1Arch");
            Debug.Log(customObject.name);
            customObject.AddComponent<BasicLabeledPrefab>();
            TimberAPI.CustomObjectCollection.AddGameObject(customObject);
            foreach (FactionSpecification factionSpecification in _factionSpecificationService._factions)
            {
                if (factionSpecification.Id != _factionService.Current.Id)
                {
                    // Buildings/Housing/Barrack/Barrack.IronTeeth if Current=Folktails
                    string path = factionSpecification.UniqueBuildings[0];                   
                    TimberAPI.CustomObjectCollection.AddGameObject(_resourceAssetLoader.Load<GameObject>(path));
                }
            }
        }
    }
}

