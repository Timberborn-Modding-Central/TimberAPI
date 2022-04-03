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
    public class ObjectCollectionAddExample : IInitializableSingleton
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

        // Add a building to the custom object collection
        public void Initialize()
        {
            // Load the Building with Prefab (use Thunderkit to make a bundle)
            GameObject customObject = _assetLoader.Load<GameObject>("TimberAPIExample/testprefab.bundle/testprefab");
            Debug.Log("Loaded Building: " + customObject.name);
            // Let TimberAPI load labels for you - just add to lang/<enUS>.txt
            customObject.AddComponent<BasicLabeledPrefab>();

            // A hack to fix shaders. Unknown how to fix this at the moment
            var platformModel = _resourceAssetLoader.Load<GameObject>("Buildings/Paths/Platform/Platform.Full.Folktails");
            FixMaterialShader(customObject, platformModel.GetComponent<MeshRenderer>().materials[0].shader);

            // Tell TimberAPI to add the building
            TimberAPI.CustomObjectCollection.AddGameObject(customObject);
        }

        // Re-apply shaders based 
        static void FixMaterialShader(GameObject obj, Shader shader)
        {
            var meshRenderer = obj.GetComponent<MeshRenderer>();
            if (meshRenderer)
            {
                foreach (var mat in meshRenderer.materials)
                {
                    mat.shader = shader;
                }
            }

            foreach (Transform child in obj.transform)
            {
                if (child.gameObject)
                {
                    FixMaterialShader(child.gameObject, shader);
                }
            }
        }
    }
}

