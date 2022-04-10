using Timberborn.AssetSystem;
using Timberborn.SingletonSystem;
using TimberbornAPI;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.LocalizationSystem;
using UnityEngine;
using static TimberAPIExample.TimberAPIExamplePlugin;


namespace TimberAPIExample.Examples.CustomObjectRegistryExample
{
    public class CustomObjectAddExample : IInitializableSingleton
    {
        private readonly IAssetLoader _assetLoader;
        private readonly IResourceAssetLoader _resourceAssetLoader;

        public CustomObjectAddExample(IAssetLoader assetLoader, IResourceAssetLoader resourceAssetLoader)
        {
            _assetLoader = assetLoader;
            _resourceAssetLoader = resourceAssetLoader;
        }

        // Add a building to the custom object registry
        public void Initialize()
        {
            // Load the Building with Prefab (use Thunderkit to make a bundle)
            // AssetLoader is part of TimberAPI
            GameObject customObject = _assetLoader.Load<GameObject>("TimberAPIExample/testprefab.bundle/testprefab");
            Log.LogInfo("Loaded Building: " + customObject.name);
            // Let TimberAPI load labels for you - just add to lang/<enUS>.txt
            customObject.AddComponent<BasicLabeledPrefab>();

            // A hack to fix shaders. Unknown how to fix this at the moment
            var platformModel = _resourceAssetLoader.Load<GameObject>("Buildings/Paths/Platform/Platform.Full.Folktails");
            FixMaterialShader(customObject, platformModel.GetComponent<MeshRenderer>().materials[0].shader);

            // Tell TimberAPI to add the building
            TimberAPI.CustomObjectRegistry.AddGameObject(customObject);
        }

        // Re-apply shaders to our custom object using the shaders from an in game object
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

